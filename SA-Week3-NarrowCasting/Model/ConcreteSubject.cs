using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Media;

namespace SA_Week3_NarrowCasting.Model
{
    public class ConcreteSubject : Interface.Subject
    {
        private List<Interface.Observer> observers;
        private Brush randomColor;
        private Random rnd = new Random();

        public ConcreteSubject()
        {
            observers = new List<Interface.Observer> {};
        }

        public void setState()
        {
            Brush result = Brushes.Transparent;
            Type brushesType = typeof(Brushes);
            PropertyInfo[] properties = brushesType.GetProperties();
            int random = rnd.Next(properties.Length);
            randomColor = (Brush)properties[random].GetValue(null, null);

            notifyObservers();
        }

        public void notifyObservers(){
            foreach (Interface.Observer o in observers)
            {
                o.update(randomColor);
            }
        }

        public void attach(Interface.Observer o)
        {
            observers.Add(o);
        }

        public void detach(Interface.Observer o)
        {
            observers.Remove(o);
        }
    }
}
