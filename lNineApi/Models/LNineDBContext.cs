using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace lNineApi.Models
{
    public class LNineDBContext : DbContext
    {
        public LNineDBContext(DbContextOptions<LNineDBContext> options)
            : base(options)
        {
        }

        public DbSet<NineUser> NineUsers { get; set; }
    }
}