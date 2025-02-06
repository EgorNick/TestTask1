using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TestTask1.Core.Entitys;

namespace TestTask1.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public virtual DbSet<Coordinate> JsonData { get; set; }
}