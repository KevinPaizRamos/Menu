namespace Menu.Models
{
    public class Ingridient
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<DishIngredient>? DishIngredient { get; set; }

    }
}
