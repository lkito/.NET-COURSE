namespace CurrencyHistory
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<DayRate> DayRates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DayRate>()
                .Property(e => e.FromCurrency)
                .IsUnicode(false);

            modelBuilder.Entity<DayRate>()
                .Property(e => e.ToCurrencies)
                .IsUnicode(false);

            modelBuilder.Entity<DayRate>()
                .Property(e => e.Rate)
                .HasPrecision(15, 2);
        }
    }
}
