using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFwithSqlite2.Demo2;

public partial class Demo2 : DbContext
{
    public Demo2()
    {
    }

    public Demo2(DbContextOptions<Demo2> options)
        : base(options)
    {
    }

    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=C:\\Users\\pjmol\\AppData\\Local\\db-group2.db");

   
}
