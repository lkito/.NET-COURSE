namespace DNetFinalProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CurrencyRate
    {
        public int ID { get; set; }

        [Required]
        [StringLength(3)]
        public string CurrencyCode { get; set; }

        public decimal BuyRateGEL { get; set; }

        public decimal SellRateGEL { get; set; }
    }
}
