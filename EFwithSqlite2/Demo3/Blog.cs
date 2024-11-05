using System;
using System.Collections.Generic;

namespace EFwithSqlite2.Demo3;

public partial class Blog
{
    public int BlogId { get; set; }

    public string Url { get; set; } = null!;

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
