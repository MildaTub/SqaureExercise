using Microsoft.EntityFrameworkCore;

namespace Points.DataAccess
{
    public class PointsDbContext : DbContext
    {
        public DbSet<Point> Points { get; set; }

        public PointsDbContext(DbContextOptions<PointsDbContext> options)
            :base(options)
        {
        }
    }
}
