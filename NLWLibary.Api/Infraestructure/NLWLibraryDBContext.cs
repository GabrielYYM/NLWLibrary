using Microsoft.EntityFrameworkCore;
using NLWLibary.Api.Entities;

namespace NLWLibary.Api.Infraestructure;

public class NLWLibraryContext : DbContext
{
    public DbSet<User> Users { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=local do .db");
    }
}
