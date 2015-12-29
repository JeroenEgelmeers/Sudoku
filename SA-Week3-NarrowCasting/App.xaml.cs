using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SA_Week3_NarrowCasting
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application{
        private ViewModel.Start appEntry;

        public App()
        {
            appEntry = new ViewModel.Start();
        }        
    }
}
