namespace Pizzeria
{
    public class DisplayFile : DisplayMother
    {
        protected string FileName;

        public DisplayFile(string fileName)
        {
            FileName = fileName;
        }

        public override void DisplayPizza(int pizzaNumber, string pizzaName, decimal pizzaPrice)
        {
            using (StreamWriter writer = new StreamWriter(FileName, true))
            {
                writer.WriteLine(pizzaNumber + " " + pizzaName + " : " + pizzaNumber + " * " + pizzaPrice + " €");
            }
        }

        public override void DisplayIngredient(string ingredientName, decimal ingredientQuantity, string ingrdientUnit)
        {
            using (StreamWriter writer = new StreamWriter(FileName, true))
            {
                writer.WriteLine(ingredientName + " " + ingredientQuantity + " " + ingrdientUnit);
            }
        }

        public override void DisplaySum(decimal sum)
        {
            using (StreamWriter writer = new StreamWriter(FileName, true))
            {
                writer.WriteLine("Prix total : " + sum + "€");
            }

        }
    }
}
