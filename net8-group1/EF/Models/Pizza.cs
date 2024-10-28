using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models
{

    [Table("Pizza")]
    public class Pizza
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; } = "";

        [Required]
        public decimal Price { get; set; }

        [MaxLength(400)]
        public string? Description { get; set; }
    }
}
