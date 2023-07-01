namespace Pizzeria
{
    public class Display
    {
        private Display() { }

        private static Display _instance;

        public DisplayMother Mode { get; set; }

        public static Display GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Display();
            }
            return _instance;
        }

        public void DisplayWelcomeMessage()
        {
            Mode.DisplayWelcomeMessage();
        }

        public void DisplayCommand()
        {
            Mode.DisplayCommand();
        }

        public void DisplaySeparation()
        {
            Mode.DisplaySeparation();
        }

        public void DisplayLinefeed()
        {
            Mode.DisplayLinefeed();
        }

        public virtual void DisplayPizza(int pizzaNumber, string pizzaName, decimal pizzaPrice)
        {
            Mode.DisplayPizza(pizzaNumber, pizzaName, pizzaPrice);
        }

        public virtual void DisplayIngredient(string ingredientName, decimal ingredientQuantity, string ingrdientUnit)
        {
            Mode.DisplayIngredient(ingredientName, ingredientQuantity, ingrdientUnit);
        }

        public void DisplayProcessHeader(string pizzaName)
        {
            Mode.DisplayProcessHeader(pizzaName);
        }

        public void DisplayProcessEnd()
        {
            Mode.DisplayProcessEnd();
        }

        public void DisplayAddIngredient(string ingredientName)
        {
            Mode.DisplayAddIngredient(ingredientName);
        }

        public void DisplayPizzaQuantity(string pizzaName, decimal ingredientQuantity, string ingredientUnit)
        {
            Mode.DisplayPizzaQuantity(pizzaName, ingredientQuantity, ingredientUnit);
        }

        public virtual void DisplaySum(decimal sum)
        {
            Mode.DisplaySum(sum);
        }

    }
}
