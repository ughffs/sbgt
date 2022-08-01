using Microsoft.EntityFrameworkCore;

namespace sbgt.Repository.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }
}