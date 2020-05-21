namespace CurrencySite.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=CurrencyModel")
        {
        }

        public virtual DbSet<CurrencyEntry> CurrencyEntries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CurrencyEntry>()
                .Property(e => e.FromCurrency)
                .IsUnicode(false);

            modelBuilder.Entity<CurrencyEntry>()
                .Property(e => e.ToCurrency)
                .IsUnicode(false);

            modelBuilder.Entity<CurrencyEntry>()
                .Property(e => e.Rate)
                .HasPrecision(15, 2);
        }
    }
}
