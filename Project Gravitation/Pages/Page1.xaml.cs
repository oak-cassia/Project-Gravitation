﻿using System;
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

namespace Project_Gravitation.Pages
{
    /// <summary>
    /// Page1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Page1 : Page
    {
        MainWindow _window;
        public Page1(MainWindow Mwindow)
        {
            _window = Mwindow;
            InitializeComponent();
        }
        private void MyButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MyButton_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(_window.option);
            _window.option.sourcepage=this;

        }

        private void MyButton_Click_2(object sender, RoutedEventArgs e)
        {
            
            NavigationService.Navigate(new Arrow());
        }
    }
}
