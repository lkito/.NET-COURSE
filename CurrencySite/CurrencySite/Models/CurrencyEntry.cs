namespace CurrencySite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CurrencyEntry")]
    public partial class CurrencyEntry
    {
        public int id { get; set; }

        [Required]
        [StringLength(3)]
        public string FromCurrency { get; set; }

        [Required]
        [StringLength(3)]
        public string ToCurrency { get; set; }

        public decimal Rate { get; set; }

        public bool Enabled { get; set; }

        [DisplayFormat(DataFormatString = "{0:hh:mm | dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime DateCreated { get; set; }

        [DisplayFormat(DataFormatString = "{0:hh:mm | dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime DateUpdated { get; set; }

    }
}
