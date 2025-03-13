using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    [Table("products")]
    public class Product
    {
        public int? id { get; set; }
        public string? brand { get; set; }
        public string? image { get; set; }
        public string? name { get; set; }
        public decimal? price { get; set; }
        public string? slug { get; set; }
        public string? category { get; set; }
        public int stock { get; set; }
    }
}