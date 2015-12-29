using System.Windows;
using System.Windows.Media;

namespace SA_Week3_NarrowCasting
{
    /// <summary>
    /// Interaction logic for Display.xaml
    /// </summary>
    public partial class ConcreteObserver : Window, Interface.Observer
    {
        private Model.ConcreteSubject model;
        private ViewModel.Start controller;

        public ConcreteObserver(ViewModel.Start c, Model.ConcreteSubject m)
        {
            model = m;
            controller = c;

            model.attach(this);

            InitializeComponent();
            this.Show();
        }

        public void update(Brush color)
        {

            this.Background = color;
        }

        private void newConcreteObserver(object sender, RoutedEventArgs e)
        {
            controller.createConcreteObserver();
        }
        private void setState(object sender, RoutedEventArgs e)
        {
            model.setState();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            model.detach(this);
            controller.destroyConcreteObserver(this);
        }
    }
}