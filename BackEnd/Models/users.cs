using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    [Table("users")]
    public class users
    {
        public int? id_user { get; set; }
        public string? name { get; set; }
        public string? surname { get; set; }
        public string? address { get; set; }
        public string? phone { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
    }
}