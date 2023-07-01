namespace Pizzeria
{
    public class CookVisitor : Visitor
    {
        public override void End()
        {
            foreach (var (key, value) in Pizzas)
            {
                foreach (int i in Enumerable.Range(1, value))
                {
                    PizzaManager.GetInstance().Process(key);
                    Display.GetInstance().DisplayProcessEnd();
                    Display.GetInstance().DisplayLinefeed();
                }
            }
        }
    }
}
