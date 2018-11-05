using Microsoft.AspNet.Identity.EntityFramework;

namespace NLayerMovie.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ClientProfile ClientProfile { get; set; }
    }
}
