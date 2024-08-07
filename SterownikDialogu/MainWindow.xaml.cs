﻿using System;
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
            DelegateParams delegateParams = null;
            switch (eleName)
            {
                case GuiElements.LABEL_CAR_TYPE:
                    delegateParams = new DelegateParams(UpdateCarType);
                    break;
                case GuiElements.LABEL_ADDRESS:
                    delegateParams = new DelegateParams(UpdateAddress);
                    break;
                case GuiElements.LABEL_ADDRESS_NUMBER:
                    delegateParams = new DelegateParams(UpdateAddressNumber);
                    break;
                case GuiElements.LABEL_HOUR:
                    delegateParams = new DelegateParams(UpdateHour);
                    break;
                case GuiElements.LABEL_MINUTE:
                    delegateParams = new DelegateParams(UpdateMinute);
                    break;
                case GuiElements.LABEL_LISTENING:
                    delegateParams = new DelegateParams(UpdateListeningIcon);
                    break;
                case GuiElements.LABEL_FINISH:
                    delegateParams = new DelegateParams(UpdateFinishLabel);
                    break;
            }
            this.Dispatcher.Invoke(delegateParams, customParams);
        }

        private void UpdateCarType(object obj)
        {
            holder_1.Content = (string)obj;
        }

        private void UpdateAddress(object obj)
        {
            holder_2.Content = (string)obj;
        }

        private void UpdateAddressNumber(object obj)
        {
            holder_3.Content = (string)obj;
        }

        private void UpdateHour(object obj)
        {
            holder_4.Content = (string)obj;
        }

        private void UpdateMinute(object obj)
        {
            holder_5.Content = (string)obj;
        }

        private void UpdateListeningIcon(object obj)
        {
            bool value = bool.Parse((string)obj);
            if (value) listening_icon.Visibility = Visibility.Visible;
            else listening_icon.Visibility = Visibility.Hidden;
        }
        

        private void UpdateFinishLabel(object obj)
        {
             finish.Visibility = Visibility.Visible;
        }

    }
}
