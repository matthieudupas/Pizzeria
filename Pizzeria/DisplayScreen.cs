namespace Pizzeria
{
    public class DisplayScreen : DisplayMother
    {
        public override void DisplaySum(decimal sum)
        {
            Console.WriteLine("Prix total : " + sum + "€");
        }

        public override void DisplayPizza(int pizzaNumber, string pizzaName, decimal pizzaPrice)
        {
            Console.WriteLine(pizzaNumber + " " + pizzaName + " : " + pizzaNumber + " * " + pizzaPrice + " €");
        }

        public override void DisplayIngredient(string ingredientName, decimal ingredientQuantity, string ingrdientUnit)
        {
            Console.WriteLine(ingredientName + " " + ingredientQuantity + " " + ingrdientUnit);
        }


    }
}
