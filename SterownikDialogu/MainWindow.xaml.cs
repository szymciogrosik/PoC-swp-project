using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ModulASR;
using DBConnector.Model;
using System.Threading;

namespace SterownikDialogu
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BackgroundThread backgroundThread;
        private delegate void DelegateParams(Object param);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            backgroundThread = new BackgroundThread(this);
            new Thread(backgroundThread.Core).Start();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
        }

        public void UpdateElement(GuiElements eleName, string[] customParams)
        {
            if (eleName.Equals(GuiElements.LABEL_TEXT))
            {
                DelegateParams delegateParams = new DelegateParams(UpdateTestLabel);
                this.Dispatcher.Invoke(delegateParams, customParams);
            }
        }

        private void UpdateTestLabel(Object i)
        {
            int val = Convert.ToInt32(i);
            //labelExample.Content = i + "";
        }

    }
}
