namespace Pizzeria
{
    public class Visitor
    {
        protected Dictionary<String, int> Pizzas = new();
        public void VisitExpression(AnExpression expression) { }
        public virtual void VisitCommand(CommandExpression expression) 
        { 
            string pizzaName = expression.PizzaName;
            int number = expression.Number;
            if(number > 0)
            {
                if(Pizzas.ContainsKey(pizzaName))
                {
                    Pizzas[pizzaName] += number;
                }
                else
                {
                    Pizzas[pizzaName] = number;
                }
            }
        }
        public virtual void VistRoot(RootExpression expression)
        {
            Pizzas.Clear();
        }
        public virtual void End() { }
    }
}
