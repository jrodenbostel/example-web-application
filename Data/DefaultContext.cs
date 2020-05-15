using ExampleWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleWebApplication.Data
{
    public class DefaultContext : DbContext
    {
        public DefaultContext(DbContextOptions<DefaultContext> options)
            : base(options)
        {
        }
        
        public DbSet<TestModel> TestModels { get; set; }
    }
}