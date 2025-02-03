using System;
using Microsoft.EntityFrameworkCore;
using TaskboardAPI.Entities;

namespace TaskboardAPI.Data;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
    public DbSet<Board> Boards { get; set; }
    public DbSet<Column> Columns { get; set; }
    public DbSet<Card> Cards { get; set; }
}
