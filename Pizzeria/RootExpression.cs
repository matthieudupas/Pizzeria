namespace Pizzeria
{
    public class RootExpression : Expression
    {
        AnExpression Expression;

        public override void Interpret(string text)
        {
            Console.WriteLine(text);
            Expression = new AnExpression();
            Expression.Interpret(text);
        }

        public override void Accept(Visitor visitor)
        {
            visitor.VistRoot(this);
            Expression.Accept(visitor);
            visitor.End();
        }

    }
}
