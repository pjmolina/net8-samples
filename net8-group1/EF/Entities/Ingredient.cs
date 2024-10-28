namespace EF.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Ingredient")]
public class Ingredient
{
    [Key]
    [Required]
    [MaxLength(4)]
    public string Code { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    [DataType("decimal(18,5)")]
    public decimal Quantity { get; set; }

    public Pizza? Pizza { get; set; }

    public int PizzaId { get; set; }
}
