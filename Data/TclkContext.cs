using Microsoft.EntityFrameworkCore;
using tclk.Models;

namespace tclk.Data
{
    public class TclkContext : DbContext
    {
        public TclkContext (DbContextOptions<TclkContext> options)
            : base(options) { }
        public DbSet<News> News { get; set; }
    }
}
