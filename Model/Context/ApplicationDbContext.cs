namespace FootballTransfersAPI.Model.Context;

using FootballTransfersAPI.Model.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Club> Clubs { get; set; }

    public DbSet<Player> Players { get; set; }

    public DbSet<Transfer> Transfers { get; set; }
}
