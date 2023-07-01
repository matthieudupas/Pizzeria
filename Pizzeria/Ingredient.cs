using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pizzeria;

public class Ingredient : SubjectIngredient
{
    public string Name { get; set; }
    public string Unit { get; set; }
    public decimal Stock { get; set; }

    public Ingredient(string name, string unit)
    {
        Name = name;
        Unit = unit;
        Stock = 0;
    }

    public void AddStock(decimal quantity)
    {
        Stock += quantity;
        this.Notify();
    }

    public void RemoveStock(decimal quantity)
    {
        Stock -= quantity;
        this.Notify();
    }
}
