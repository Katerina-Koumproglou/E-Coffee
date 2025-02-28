using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string? name { get; set; }
        [Required]
        public string? surname { get; set; }
        public string? address { get; set; }
        public string? phone { get; set; }
        [Required, EmailAddress]
        public string? email { get; set; }
        [Required]
        public string? password { get; set; }
    }
}