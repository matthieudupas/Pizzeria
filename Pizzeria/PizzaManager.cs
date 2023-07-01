namespace Pizzeria
{
    public sealed class PizzaManager : Observer
    {
        private PizzaManager() { }

        private static PizzaManager _instance;

        private Dictionary<string, Pizza> Pizzas = new() { };

        public Boolean IsOk(String pizzaName)
        {
            return Pizzas[pizzaName].IsAvailable;
        }

        public static PizzaManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new PizzaManager();
            }
            return _instance;
        }

        public Boolean IsPizzaExist(String name)
        {
            return Pizzas.ContainsKey(name);
        }

        public void Register(Pizza pizza)
        {
            Pizzas.Add(pizza.Name, pizza);
        }

        public Pizza GetPizza(String name)
        {
            return Pizzas[name];
        }

        public override void Update()
        {
            foreach (var(pizzaName, pizza) in Pizzas)
            {
                pizza.CheckIngredient();
            }
        }

        public void Command(String name)
        {
            Pizzas[name].Command();
        }

        public void Menu()
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Voici nos pizzas disponibles :");
            foreach (var pizza in Pizzas)
            {
                Console.WriteLine(pizza.Key);
            }
            Console.WriteLine("-----------------------------------------");
        }

        public decimal Bill(String pizzaName, int pizzaNumber)
        {
            Pizza pizza = GetPizza(pizzaName);
            Display.GetInstance().DisplayPizza(pizzaNumber, pizzaName, pizza.Price);
            foreach(Ingredient ingredient in pizza.Ingredients)
            {
                Display.GetInstance().DisplayIngredient(ingredient.Name, pizza.Quantities[ingredient.Name], ingredient.Unit);
            }
            return pizzaNumber * pizza.Price;
        }

        public void Process(String pizzaName)
        {
            Pizza pizza = GetPizza(pizzaName);
            Display.GetInstance().DisplayProcessHeader(pizzaName);
            foreach (Ingredient ingredient in pizza.Ingredients)
            {
                Display.GetInstance().DisplayAddIngredient(ingredient.Name);
            }
        }

        public void Ingredients(Dictionary<String, int> pizzas)
        {
            Dictionary<String, decimal> ingredients = new Dictionary<string, decimal>();
            Dictionary<String, String> ingredientUnits = new Dictionary<string, String>();
            foreach( var (pizzaName, pizzaNumber) in pizzas)
            {
                Pizza pizza = Pizzas[pizzaName];
                foreach(Ingredient ingredient in pizza.Ingredients )
                {
                    if (ingredients.ContainsKey(ingredient.Name))
                    {
                        ingredients[ingredient.Name] += pizza.Quantities[ingredient.Name] * pizzaNumber;
                    }
                    else
                    {
                        ingredients[ingredient.Name] = pizza.Quantities[ingredient.Name] * pizzaNumber;
                    }
                    ingredientUnits[ingredient.Name] = ingredient.Unit;
                }
            }
            foreach (var (ingredientName, ingredientQuantity) in ingredients)
            {
                Display.GetInstance().DisplayIngredient(ingredientName, ingredientQuantity, ingredientUnits[ingredientName]);
                foreach (var (pizzaName, pizzaNumber) in pizzas)
                {
                    Pizza pizza = Pizzas[pizzaName];
                    foreach (Ingredient ingredient in pizza.Ingredients)
                    {
                        if (ingredient.Name.Equals(ingredientName))
                        {
                                Display.GetInstance().DisplayPizzaQuantity(pizzaName, ingredientQuantity, ingredientUnits[ingredientName]);
                        }
                    }
                }
            }
        }
    }
}
