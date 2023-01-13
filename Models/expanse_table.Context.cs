

namespace expanseApigateway.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class apiexpanseEntities3 : DbContext
    {
        public apiexpanseEntities3()
            : base("name=apiexpanseEntities3")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<expanse_table> expanse_table { get; set; }
    }
}
