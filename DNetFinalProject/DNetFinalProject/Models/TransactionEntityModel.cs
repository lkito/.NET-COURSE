namespace DNetFinalProject.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TransactionEntityModel : DbContext
    {
        public TransactionEntityModel()
            : base("name=FinalProjectCon")
        {
        }

        public virtual DbSet<TransactionHistory> TransactionHistories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransactionHistory>()
                .Property(e => e.IncomingCurrencyCode)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionHistory>()
                .Property(e => e.OutgoingCurrencyCode)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionHistory>()
                .Property(e => e.Comment)
                .IsUnicode(true);
        }
    }
}
