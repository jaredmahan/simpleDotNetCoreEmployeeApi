using Microsoft.EntityFrameworkCore;

namespace CoreApi.Models {
    public class CoreApiContext : DbContext {
        public CoreApiContext (DbContextOptions<CoreApiContext> options) : base (options) { }
        public DbSet<Employee> Employees { get; set; }
    }
}