using Microsoft.EntityFrameworkCore;
using sbgt.Repository.Entities;

namespace sbgt.Repository.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public DbSet<Item> Items { get; set; } = null!;
    public DbSet<RentEpisode> RentEpisodes { get; set; } = null!;
}