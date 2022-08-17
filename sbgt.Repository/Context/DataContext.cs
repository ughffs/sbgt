using Microsoft.EntityFrameworkCore;
using sbgt.Repository.Entities;

namespace sbgt.Repository.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public DbSet<ItemEntity> Items { get; set; } = null!;
    public DbSet<RentEpisodeEntity> RentEpisodes { get; set; } = null!;
    public DbSet<MemberEntity> Members { get; set; } = null!;
}