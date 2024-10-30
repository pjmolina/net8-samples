using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Entities;

[Table("User")]
public partial class User
{
    [Key]       // Primary Key
    [Required] // Not null
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string LastName { get; set; } = null!;
}
