using System.Collections.Generic;

namespace SA_Week3_NarrowCasting.ViewModel
{ 
    public class Start
    {
        private Model.ConcreteSubject data;
        private List<ConcreteObserver> activeConcreteObserver;

        public Start()
        {
            // init variables
            data = new Model.ConcreteSubject();
            activeConcreteObserver = new List<ConcreteObserver> {};

            // start with 1 observer
            createConcreteObserver();
        }

        public void createConcreteObserver()
        {
            activeConcreteObserver.Insert(activeConcreteObserver.Count, new ConcreteObserver(this, data));             
        }

        public void destroyConcreteObserver(ConcreteObserver o)
        {
            activeConcreteObserver.Remove(o);
        }
    }
}
