using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzeria
{
    public abstract class SubjectIngredient
    {
        List<Observer> observers = new() { };

        public void Notify()
        {
            foreach (Observer observer in observers)
            {
                observer.Update();
            }
        }

        public void Register(Observer observer)
        {
            observers.Add(observer);
        }
    }
}
