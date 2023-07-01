namespace Pizzeria
{
    public class DisplayMother
    {
        public void DisplayWelcomeMessage()
        {
            Console.WriteLine("Bienvenue chez PizzaExpress !");
        }

        public void DisplayCommand()
        {
            Console.WriteLine("Entrez votre commande de pizzas sous la forme 'A nom_pizza1, B nom_pizza2, C nom_pizza3 ... ou EXIT pour quitter'");
        }

        public void DisplaySeparation()
        {
            Console.WriteLine("-------------------------------------");
        }

        public void DisplayLinefeed()
        {
            Console.WriteLine("");
        }

        public virtual void DisplayPizza(int pizzaNumber, string pizzaName, decimal pizzaPrice)
        {

        }

        public virtual void DisplayIngredient(string ingredientName, decimal ingredientQuantity, string ingrdientUnit)
        {

        }

        public void DisplayProcessHeader(string pizzaName)
        {
            Console.WriteLine(pizzaName);
            Console.WriteLine("Préparer la pâte");
        }

        public void DisplayProcessEnd()
        {
            Console.WriteLine("Cuire pizza");
        }

        public void DisplayAddIngredient(string ingredientName)
        {
            Console.WriteLine("Ajouter " + ingredientName);
        }

        public void DisplayPizzaQuantity(string pizzaName, decimal ingredientQuantity, string ingredientUnit)
        {
            Console.WriteLine(" - " + pizzaName + " : " + ingredientQuantity + " " + ingredientUnit);
        }

        public virtual void DisplaySum(decimal sum)
        {

        }
    }
}
