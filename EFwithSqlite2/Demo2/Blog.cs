using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFwithSqlite2.Demo2;

public partial class Blog
{
    [Key]
    public int BlogId { get; set; }

    public string Url { get; set; } = null!;

    [InverseProperty("Blog")]
    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
