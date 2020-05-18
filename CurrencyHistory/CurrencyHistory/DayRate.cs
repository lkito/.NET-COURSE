namespace CurrencyHistory
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DayRate
    {
        public int id { get; set; }

        [Required]
        [StringLength(3)]
        public string FromCurrency { get; set; }

        [Required]
        [StringLength(3)]
        public string ToCurrencies { get; set; }

        public decimal Rate { get; set; }

        public DateTime Date { get; set; }
    }
}
