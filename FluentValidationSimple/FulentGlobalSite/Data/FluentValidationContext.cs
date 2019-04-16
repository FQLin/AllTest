using System.Data.Entity;

namespace FulentGlobalSite.Data
{
    public class FluentValidationContext:DbContext
    {
        public FluentValidationContext():base("FulentGlobalSiteContext") { }
        public DbSet<FulentGlobalSite.Models.Account.LoginViewModel> Students { get; set; }
    }
}