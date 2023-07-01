namespace Pizzeria
{
    public class BillVisitor : Visitor
    {
        public override void End()
        {
            decimal total = 0;
            foreach(var (key, value) in Pizzas)
            {
                total += PizzaManager.GetInstance().Bill(key, value);
            }
            Display.GetInstance().DisplaySum(total);

        }
    }
}
