using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzeria
{
    public class AnExpression : Expression
    {
        public List<CommandExpression> CommandExpressions = new() { };

        public override void Interpret(string text)
        {
            string[] myCommand = text.Split(',');
            foreach (string command in myCommand)
            {

                    CommandExpression commandExpression = new CommandExpression();
                    CommandExpressions.Add(commandExpression);
                    commandExpression.Interpret(command.Trim());
              
            }
        }

        public override void Accept(Visitor visitor)
        {
            foreach(CommandExpression command in CommandExpressions)
            {
                command.Accept(visitor);
            }
        }

    }
}
