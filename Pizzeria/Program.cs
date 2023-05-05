
using System.Text;
using Pizzeria;

class Program
{
    // Définition des pizzas
    static Pizza regina = new Pizza("Regina", new Dictionary<string, (decimal Quantity, string Unit)> {
            { "Tomate", (150m, "g") },
            { "Mozzarella", (125m, "g") },
            { "Fromage râpé", (100m, "g") },
            { "Jambon", (2m, "tranches") },
            { "Champignon", (4m, "") },
            { "Huile d'olive", (2m, "Cuillères") }
        }, 8);

    static Pizza vegetarian = new Pizza("Végétarienne", new Dictionary<string, (decimal Quantity, string Unit)> {
            { "Tomate", (150m, "g") },
            { "Mozzarella", (100m, "g") },
            { "Courgette", (0.5m, "") },
            { "Poivron jaune", (1m, "") },
            { "Tomate cerise", (6m, "") },
            { "Olive", (5m, "") }
        }, 7.5m);

    static Dictionary<string, Pizza> pizzas = new Dictionary<string, Pizza> { { "Regina", regina }, { "Végétarienne", vegetarian } };

    static void displayBill(Dictionary<string, int> orders)
    {
        decimal prixTotal = 0m;
        Console.WriteLine("------------------------");
        foreach (KeyValuePair<string, int> order in orders)
        {
            Pizza pizza = pizzas[order.Key];
            prixTotal += pizza.Price * order.Value;
            Console.WriteLine($"{order.Value} {pizza.Name} : {order.Value} * {pizza.Price:C}");
            foreach (KeyValuePair<string, (decimal, String)> ingredient in pizza.Ingredients)
            {
                Console.WriteLine($"{ingredient.Key} {ingredient.Value.Item1 * order.Value} {ingredient.Value.Item2}");
            }

        }
        Console.WriteLine($"Prix total {prixTotal:C}");
        Console.WriteLine("------------------------");
    }

    static void displayInstructions(Pizza pizza)
    {
        Console.WriteLine("Préparer la pâte");
        foreach (KeyValuePair<string, (decimal, String)> ingredient in pizza.Ingredients)
        {
            Console.WriteLine($"Ajouter {ingredient.Key}");
        }
        Console.WriteLine("Cuire la pizza");
    }

    static void Main(string[] args)
    {
        // Demander à l'utilisateur de saisir sa commande de pizza
        Console.WriteLine("Bienvenue chez PizzaExpress !");
        Console.WriteLine("Voici nos pizzas disponibles :");
        foreach (Pizza p in pizzas.Values)
        {
            Console.WriteLine(p);
        }

        Console.WriteLine("Entrez votre commande de pizzas sous la forme 'A nom_pizza1, B nom_pizza2, C nom_pizza3 ...'");
        string input = Console.ReadLine();

        // Créer une liste pour stocker les commandes
        Dictionary<string, int> orders = new Dictionary<string, int>();

        // Analyser la commande de l'utilisateur
        foreach (string order in input.Split(','))
        {
            string[] parts = order.Trim().Split(' ');
            if (parts.Length != 2 || !int.TryParse(parts[0], out int quantity))
            {
                Console.WriteLine($"Commande invalide : {order}");
                return;
            }
            string pizzaName = parts[1];
            if (!pizzas.ContainsKey(pizzaName))
            {
                Console.WriteLine($"Désolé, nous ne proposons pas la pizza {pizzaName}.");
                return;
            }

            if (orders.ContainsKey(pizzaName))
            {
                orders[pizzaName] += quantity;
            }
            else
            {
                orders.Add(pizzaName, quantity);
            }
        }

        displayBill(orders);

        Console.WriteLine("------------------------");
        foreach (KeyValuePair<string, int> order in orders)
        {
            Console.WriteLine(order.Key);
            displayInstructions(pizzas[order.Key]);
            Console.WriteLine();
        }
        Console.WriteLine("------------------------");

        Console.WriteLine("Appuyez sur une touche pour quitter.");
        Console.ReadKey();
    }
}
