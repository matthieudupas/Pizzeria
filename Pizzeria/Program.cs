using Pizzeria;

class Program
{
    static void Main(string[] args)
    {
        DisplayScreen displayScreen = new DisplayScreen();
        DisplayFile displayFile = new DisplayFile(@"Bill.txt");

        Display.GetInstance().Mode = displayFile;

        Ingredient tomate = new Ingredient("tomate", Units.Grammes);
        Ingredient tomate_cerise = new Ingredient("tomate cerise", Units.Unites);
        Ingredient mozarella = new Ingredient("mozarella", Units.Grammes);
        Ingredient jambon = new Ingredient("jambon", Units.Tranches);
        Ingredient champignon = new Ingredient("champignon", Units.Grammes);
        Ingredient courgette = new Ingredient("courgette", Units.Unites);
        Ingredient poivron = new Ingredient("poivron", Units.Unites);
        Ingredient olive = new Ingredient("olive", Units.Poignees);

        tomate.Register(PizzaManager.GetInstance());
        tomate_cerise.Register(PizzaManager.GetInstance());
        mozarella.Register(PizzaManager.GetInstance());
        jambon.Register(PizzaManager.GetInstance());
        champignon.Register(PizzaManager.GetInstance());
        courgette.Register(PizzaManager.GetInstance());
        poivron.Register(PizzaManager.GetInstance());
        olive.Register(PizzaManager.GetInstance());

        tomate.AddStock(1000);
        tomate_cerise.AddStock(1000);
        champignon.AddStock(10000);
        courgette.AddStock(100000);
        poivron.AddStock(1000000);
        olive.AddStock(1000000);
        mozarella.AddStock(1000);
        jambon.AddStock(1000);

        Pizza pizza_4_saisons = new Pizza("4 saisons");
        pizza_4_saisons.AddIngredient(tomate, 150);
        pizza_4_saisons.AddIngredient(mozarella, 125);
        pizza_4_saisons.AddIngredient(jambon, 2);
        pizza_4_saisons.AddIngredient(poivron, 0.5m);
        pizza_4_saisons.AddIngredient(olive, 1);
        pizza_4_saisons.Price = 9;
        PizzaManager.GetInstance().Register(pizza_4_saisons);

        Pizza pizza_vegetarienne = new Pizza("Végétarienne");
        pizza_vegetarienne.AddIngredient(tomate, 150);
        pizza_vegetarienne.AddIngredient(mozarella, 100);
        pizza_vegetarienne.AddIngredient(courgette, 0.5m);
        pizza_vegetarienne.AddIngredient(poivron, 1);
        pizza_vegetarienne.AddIngredient(tomate_cerise, 6);
        pizza_vegetarienne.AddIngredient(olive, 3);
        pizza_vegetarienne.Price = 7.5m;
        PizzaManager.GetInstance().Register(pizza_vegetarienne);

        RootExpression expression = new RootExpression();

        Display.GetInstance().DisplayWelcomeMessage();

        PizzaManager.GetInstance().Menu();

        bool exit = false;

        while (!exit)
        {
            Display.GetInstance().DisplayCommand();

            string input = Console.ReadLine();

            if (input.ToLower() == "exit")
            {
                exit = true;
            }
            else
            {
                try
                {
                    try
                    {
                        expression.Interpret(input);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Syntax incorrect ");
                    }

                    BillVisitor billVisitor = new BillVisitor();
                    expression.Accept(billVisitor);
                    CookVisitor cookVisitor = new CookVisitor();
                    expression.Accept(cookVisitor);
                    IngredientVisitor ingredientVisitor = new IngredientVisitor();
                    expression.Accept(ingredientVisitor);
                }
                catch (Exception)
                {
                    Console.WriteLine("Saisie incorrect ");
                }
            }
        }
    }
}
