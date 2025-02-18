using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    [Table("capsules")]
    public class Capsule
    {
        public int ID { get; set; }
        public string Brand { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Slug { get; set; }
    }
}