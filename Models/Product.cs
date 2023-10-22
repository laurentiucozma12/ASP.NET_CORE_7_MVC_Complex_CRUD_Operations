using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learn_ASP.NET_CRUD.Models
{
    public class Product
    {
        [Key]
        [StringLength(6)]
        public string? Code { get; set; }
        [Required]
        [StringLength(75)]
        public string? Name { get; set; }
        [Required]
        [StringLength(255)]
        public string? Description { get; set; }
        [Required]
        [Column(TypeName = "smallmoney")]
        public decimal Cost {  get; set; }
    }
}
