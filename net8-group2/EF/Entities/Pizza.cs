using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Entities
{

    [Table("Pizza")]
    public class Pizza
    {
        [Key]       // Primary Key
        [Required] // Not null
        public int Id { get; set; }

        [MaxLength(100)]   // nvarchar(max)
        [Required]
        public string Name { get; set; } = "";

        [Required]
        public decimal Price { get; set; }

        [MaxLength(400)]
        public string? Description { get; set; }

        public virtual List<Ingredient> Ingredients { get; set; } = [];
    }
}
