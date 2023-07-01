public class Pizza
{
    public string Name { get; set; }
    public List<Ingredient> Ingredients = new() { };
    public decimal Price { get; set; }
    public Dictionary<String, decimal> Quantities = new() { };
    public Boolean IsAvailable;

    public Pizza(string name)
    {
        Name = name;
        IsAvailable = false;
        CheckIngredient();
    }

    public void CheckIngredient()
    {
        Boolean isOk = true;
        foreach (Ingredient ingredient in Ingredients)
        {
            if (ingredient.Stock < Quantities[ingredient.Name])
            {
                isOk = false;
            }
        }
        IsAvailable = isOk;
    }

    public void AddIngredient(Ingredient ingredient, decimal quantity)
    {
        Ingredients.Add(ingredient);
        Quantities.Add(ingredient.Name, quantity);
        CheckIngredient();
    }

    public void Bill()
    {
        foreach(Ingredient ingredient in Ingredients)
        {
            Console.WriteLine(ingredient.Name);
        }
    }

    public void Content()
    {
        foreach (Ingredient ingredient in Ingredients)
        {
            Console.WriteLine(Quantities[ingredient.Name] +","+ ingredient.Unit +","+ ingredient.Name + ", pour chaque pizza:");
        }
    }

    public void Command()
    {
        foreach (Ingredient ingredient in Ingredients)
        {
            if (ingredient.Stock >= Quantities[ingredient.Name])
            {
                ingredient.RemoveStock(Quantities[ingredient.Name]);
            }
        }
        CheckIngredient();
    }

}
