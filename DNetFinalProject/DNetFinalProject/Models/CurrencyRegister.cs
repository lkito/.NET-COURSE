namespace DNetFinalProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CurrencyRegister")]
    public partial class CurrencyRegister
    {
        [Key]
        [StringLength(3)]
        public string CurrencyCode { get; set; }

        [Required]
        [StringLength(20)]
        public string CurrencyName { get; set; }

        [Required]
        [StringLength(20)]
        public string CurrencyLatinName { get; set; }

        public int OrderNum { get; set; }
    }
}
