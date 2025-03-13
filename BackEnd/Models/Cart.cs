using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    [Table("cart")]
    public class Cart
    {
        public int? id { get; set; }
        public int? uid { get; set; }
        public int? pid { get; set; }
        public int? quantity { get; set; }
        public Product Product { get; set; }
    }

}