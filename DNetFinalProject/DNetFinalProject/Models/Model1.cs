namespace DNetFinalProject.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=FinalProjectCon")
        {
        }

        public virtual DbSet<CurrencyRegister> CurrencyRegisters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CurrencyRegister>()
                .Property(e => e.CurrencyCode)
                .IsUnicode(false);

            modelBuilder.Entity<CurrencyRegister>()
                .Property(e => e.CurrencyName)
                .IsUnicode(false);

            modelBuilder.Entity<CurrencyRegister>()
                .Property(e => e.CurrencyLatinName)
                .IsUnicode(false);
        }
    }
}
