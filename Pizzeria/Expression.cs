namespace Pizzeria
{
    public abstract class Expression
    {
        public abstract void Interpret(string text);

        public abstract void Accept(Visitor visitor);

    }
}
