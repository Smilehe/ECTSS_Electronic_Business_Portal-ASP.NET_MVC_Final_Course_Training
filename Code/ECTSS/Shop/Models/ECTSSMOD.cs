namespace Shop.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ECTSSMOD : DbContext
    {
        public ECTSSMOD()
            : base("name=ECTSSMOD")
        {
        }

        public virtual DbSet<AUser> AUsers { get; set; }
        public virtual DbSet<CategoryI> CategoryIs { get; set; }
        public virtual DbSet<CategoryII> CategoryIIs { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Shops> Shops { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryII>()
                .Property(e => e.Categoryl)
                .IsFixedLength();
        }
    }
}
