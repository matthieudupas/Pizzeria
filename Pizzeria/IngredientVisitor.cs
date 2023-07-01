namespace Pizzeria
{
    public class IngredientVisitor : Visitor
    {
        public override void VistRoot(RootExpression expression)
        {
            base.VistRoot(expression);
            Display.GetInstance().DisplaySeparation();
        }

        public override void End()
        {
            PizzaManager.GetInstance().Ingredients(Pizzas);
        }
    }
}
