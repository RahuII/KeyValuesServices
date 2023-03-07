using Microsoft.EntityFrameworkCore;

namespace KeyValueAPI.Data;

public class DataContext : DbContext
{
    // Creating a constructor for the DataContext class and passing in the DbContextOptions 
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    // Creating a DbSet for the KeyValue class 
    public DbSet<KeyValue> KeyValues { get; set; }
}
