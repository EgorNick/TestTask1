using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TestTask1.Data.Entitys;

namespace TestTask1.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public virtual DbSet<CoordinateEntity> JsonData { get; set; }
}