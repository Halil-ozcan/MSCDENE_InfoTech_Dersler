namespace Alistirma02;

class Program
{
    static void Main(string[] args)
    {

       List<Recipe> recipes = new List<Recipe>
       {
            new Recipe("Menenmen",15){Ingredients = {"Yumurta","Domates","Biber","Soğan","Tuz","Yağ"}},
            new Recipe("KarnıYarık",50){Ingredients = {"Patlıcan","Kıyma","Soğan","Domates","Salça","Yağ"}},
            new Recipe("Mercimek Çorbası",30){Ingredients = {"Mercimek","Soğan","Havuç","Tuz","Yağ"}},
            new Recipe("Pilav",20){Ingredients = {"Prinç","Tereyağ","Tuz","Su",}},
            new Recipe("Omlet",10){Ingredients = {"Yumurta","Süt","Tuz","Yağ"}},
       };
       
       Console.WriteLine("Tüm Tarifler\n");
       foreach (Recipe recipe in recipes)
       {
            recipe.ShowRecipe();
       }

       var shortestRecipe = recipes.OrderBy(r=>r.preparationTime).First();
       Console.WriteLine("En kısa sürede hazırlanabilen Tarif: ");
       shortestRecipe.ShowRecipe();

      


    }
}
