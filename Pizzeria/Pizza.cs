using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Pizza
{
    public string Name { get; set; }
    public Dictionary<string, (decimal Quantity, string Unit)> Ingredients { get; set; }
    public decimal Price { get; set; }

    public Pizza(string name, Dictionary<string, (decimal Quantity, string Unit)> ingredients, decimal price)
    {
        Name = name;
        Ingredients = ingredients;
        Price = price;
    }

    public override string ToString()
    {
        string ingredientString = string.Join(", ", Ingredients.Select(kv => $"{kv.Value.Quantity} {kv.Value.Unit} {kv.Key}"));
        return $"{Name} - {ingredientString} - {Price:C}";
    }
}
