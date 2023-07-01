namespace Pizzeria
{
    public class CommandExpression : Expression
    {
        public int Number;

        public String PizzaName;

        public override void Accept(Visitor visitor)
        {
            visitor.VisitCommand(this);
        }

        public override void Interpret(string text)
        {
                string[] cut = text.Split(' ');
                Number = int.Parse(cut[0]);
                for(int i = 1; i < cut.Length; i++)
                {
                    PizzaName += cut[i] + ' ';
                }
                PizzaName = PizzaName.Trim();
            
                if(PizzaManager.GetInstance().IsPizzaExist(PizzaName))
                {
                    int count = 0;
                    foreach(int value in Enumerable.Range(1, Number))
                    {
                    if (PizzaManager.GetInstance().IsOk(PizzaName))
                        {
                            PizzaManager.GetInstance().Command(PizzaName);
                            count++;
                        } 
                        else
                        {
                            Console.WriteLine("Pizza non disponible " + PizzaName);
                        }
                    }
                    Number = count;
                }
                else
                {
                    throw new SystemException("Cette pizza n'existe pas : " + PizzaName);
                }
        }

    }
}
