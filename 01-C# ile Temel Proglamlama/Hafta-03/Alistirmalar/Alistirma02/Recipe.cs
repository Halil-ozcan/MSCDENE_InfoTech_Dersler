namespace Alistirma02;

public class Recipe
{
    public Recipe(string name,int preparationTime)
    {
        Name = name;
        Ingredients = new List<string>();
        this.preparationTime = preparationTime;
    }

    public string Name { get; set; }
   public List<string> Ingredients { get; set; }
   public int preparationTime { get; set; }

   public void AddIngredient(string ingredient)
   {
        Ingredients.Add(ingredient);
   }

   public void ShowRecipe()
   {
        Console.WriteLine($"Tarif: {Name}");
        Console.WriteLine("Malzemeler: ");
        foreach (var ingredient in Ingredients)
        {
            Console.WriteLine("-" + ingredient);
        }
        Console.WriteLine($"Hazırlanış Süresi: {preparationTime} dakika\n");
   }


}
