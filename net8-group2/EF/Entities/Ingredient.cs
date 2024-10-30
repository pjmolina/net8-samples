namespace EF.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Ingredient")]
public class Ingredient
{
    [Key]       // Primary Key
    [Required] // Not null
    [MaxLength(4)]
    public string Code { get; set; } = "";

    [Required] // Not null
    [MaxLength(100)]
    public string Name { get; set; }

    [Required] // Not null
    public decimal Quantity { get; set; }

    public int PizzaId { get; set; }

    // public virtual Pizza? Pizza { get; set; }

}
