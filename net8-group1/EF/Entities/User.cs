using System;
using System.Collections.Generic;

namespace EF.Entities;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
}
