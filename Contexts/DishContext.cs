using Microsoft.EntityFrameworkCore;
using delicious.Models;

namespace delicious.Contexts
{
    public class DishContext : DbContext
    {
        public DishContext(DbContextOptions options) : base(options) { }

        public DbSet<Dish> Dishes { get; set; }
    }
}