namespace DNetFinalProject.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RateEntityModel : DbContext
    {
        public RateEntityModel()
            : base("name=FinalProjectCon")
        {
        }

        public virtual DbSet<CurrencyRate> CurrencyRates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CurrencyRate>()
                .Property(e => e.CurrencyCode)
                .IsUnicode(false);

            modelBuilder.Entity<CurrencyRate>()
                .Property(e => e.BuyRateGEL)
                .HasPrecision(15, 2);

            modelBuilder.Entity<CurrencyRate>()
                .Property(e => e.SellRateGEL)
                .HasPrecision(15, 2);
        }
    }
}
