using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models
{
    public class StockPurchase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Tracker { get; set; }

        [Required]
        [Display(Name = "Price per share")]
        public double PricePerShare { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        [Display(Name = "Long or Short")]
        [RegularExpression("Long|Short", ErrorMessage = "Please enter 'Long' or 'Short'")]
        public string LongOrShort { get; set; }
        [Required]
        [Display(Name = "Buy or sell")]
        [RegularExpression("Buy|Sell", ErrorMessage = "Please enter 'Buy' or 'Sell'")]
        public string BuyOrSell { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        [Display(Name = "Purchase date")]
        public DateTime PurchaseDate { get; set; }

    }
}
