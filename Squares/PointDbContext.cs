using Microsoft.EntityFrameworkCore;
using Squares.DataAccess.Entities;

namespace Squares.DataAccess
{
    public class SquaresDbContext: DbContext
    {
        public DbSet<Square> Squares { get; set; }
        public SquaresDbContext(DbContextOptions<SquaresDbContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }

    }
}
