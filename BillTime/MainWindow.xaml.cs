﻿using BillTime.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BillTime
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            content.Content = new MainControl();
        }

        private void clientMenuitem_Click(object sender, RoutedEventArgs e)
        {
            content.Content = new ClientControl();
        }

        private void paymentMenuitem_Click(object sender, RoutedEventArgs e)
        {
            content.Content = new PaymentsControl();
        }

        private void workMenuitem_Click(object sender, RoutedEventArgs e)
        {
            content.Content = new WorkControl();
        }

        private void defaultsMenuitem_Click(object sender, RoutedEventArgs e)
        {
            content.Content = new DefaultsControl();
        }

        private void mainMenuItem_Click(object sender, RoutedEventArgs e)
        {
            content.Content = new MainControl();
        }

        private void aboutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            content.Content = new AboutControl();
        }

        private void exitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
