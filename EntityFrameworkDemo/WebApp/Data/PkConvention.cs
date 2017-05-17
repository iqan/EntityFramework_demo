using System.Data.Entity.ModelConfiguration.Conventions;

namespace WebApp.Data
{
    public class PkConvention : Convention
    {
        public PkConvention()
        {
            this.Properties()
            .Where(p => p.Name == p.DeclaringType.Name + "_ID")
            .Configure(p => p.IsKey());
        }
    }
}