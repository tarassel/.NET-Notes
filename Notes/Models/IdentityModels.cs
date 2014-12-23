using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Globalization;
using System.Web;
using Microsoft.AspNet.Identity.Owin;

namespace Notes.Models
{

	public class ApplicationUserConverter : ExpandableObjectConverter
	{
		public override bool CanConvertFrom(
			ITypeDescriptorContext context, Type sourceType)
		{
			if (sourceType == typeof(System.String))
			{
				return true;
			}
			return base.CanConvertFrom(context, sourceType);
		}

		public override object ConvertFrom(ITypeDescriptorContext
			context, CultureInfo culture, object value)
		{
			if (value == null)
			{
				throw new ArgumentException("User ID cannot be null");
			}

			if (value is System.String)
			{
				return HttpContext.Current.GetOwinContext().GetUserManager<Notes.Models.ApplicationDbContext>().Users.Find(value);
			}

			return base.ConvertFrom(context, culture, value);
		}
	}
	
	// You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
	[TypeConverter(typeof(ApplicationUserConverter))]
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Note> SharedNotes { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Note> Notes { get; set; }
//        public DbSet<NoteSharing> NoteSharings { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}