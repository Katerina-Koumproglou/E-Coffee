using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    [Table("accessories")]
    public class Accessory
    {
        public int? ID { get; set; }
        public string? brand { get; set; }
        public string? image { get; set; }
        public string? name { get; set; }
        public decimal? price { get; set; }
        public string? slug { get; set; }
    }
}