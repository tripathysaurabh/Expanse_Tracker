

namespace expanseApigateway.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class apiexpanseEntities : DbContext
    {
        internal object apiexpanseEntitie;
        internal object category;

        public apiexpanseEntities()
            : base("name=apiexpanseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<expanse_table> expanse_table { get; set; }

        public System.Data.Entity.DbSet<expanseApigateway.Models.category> categories { get; set; }

        
    }
}
