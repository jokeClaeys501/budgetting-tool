using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    public class StockPurchase
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Tracker { get; set; }
        [Required]
        public int Amount { get; set; }

        public double Value { get; set; }
    }
}
