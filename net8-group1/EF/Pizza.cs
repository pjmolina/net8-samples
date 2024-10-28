using System;
using System.Collections.Generic;

namespace EF;

public partial class Pizza
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }
}
