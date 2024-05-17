namespace Menu.Models
{
    public class DishIngredient
    {
        public int DishId { get; set; }
        public Dish Dish { get; set; }

        public int IngridientId {  get; set; }

        public Ingridient Ingrident {  get; set; }

    }
}
