using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Entities
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

        [DataType("date")]
        public DateTime LaunchDate { get; set; }  // datetime time dates -

        public List<Ingredient> Ingredients { get; set; } = [];

        [DefaultValue(false)]
        public bool IsVegan { get; set; }
    }
}
