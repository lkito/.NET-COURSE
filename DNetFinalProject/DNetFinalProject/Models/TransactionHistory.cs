namespace DNetFinalProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TransactionHistory")]
    public partial class TransactionHistory
    {
        public int ID { get; set; }

        [Required]
        [StringLength(3)]
        public string IncomingCurrencyCode { get; set; }

        [Required]
        [StringLength(3)]
        public string OutgoingCurrencyCode { get; set; }

        public int IncomingAmount { get; set; }

        public int OutgoingAmount { get; set; }

        public DateTime TransactionDate { get; set; }

        [StringLength(4000)]
        public string Comment { get; set; }
    }
}
