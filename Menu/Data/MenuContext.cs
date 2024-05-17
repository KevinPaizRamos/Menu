using Microsoft.EntityFrameworkCore;
using Menu.Models;
namespace Menu.Data
{
    public class MenuContext : DbContext
    {
        public MenuContext(DbContextOptions<MenuContext> options) : base(options)
        { 

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishIngredient>().HasKey(di => new
            {
                di.DishId,
                di.IngridientId
            });
            modelBuilder.Entity<DishIngredient>().HasOne(d => d.Dish).WithMany(di => di.DishIngredient).HasForeignKey(d=>d.DishId);
            modelBuilder.Entity<DishIngredient>().HasOne(i => i.Ingrident).WithMany(di => di.DishIngredient).HasForeignKey(i => i.IngridientId);

            modelBuilder.Entity<Dish>().HasData(
                new Dish { id = 1, name = "Margheritta", Price = 7.50, ImageUrl = "https://cb.scene7.com/is/image/Crate/frame-margherita-pizza-1?wid=800&qlt=70&op_sharpen=1" }
                );

            modelBuilder.Entity<Ingridient>().HasData(
                new Ingridient { Id = 1, Name = "Tomato Sauce"},
                new Ingridient { Id =2, Name = "Mozarrella" }
                
                );

            modelBuilder.Entity<DishIngredient>().HasData(
                new DishIngredient { DishId = 1, IngridientId = 1},
                 new DishIngredient { DishId = 1, IngridientId = 2}
                );
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingridient> Ingrident { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }
    }
}
