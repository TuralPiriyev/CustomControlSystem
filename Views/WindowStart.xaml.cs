﻿using CustomControlSystem.ViewModel;
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
using System.Windows.Shapes;

namespace CustomControlSystem.Views
{
    /// <summary>
    /// Interaction logic for WindowStart.xaml
    /// </summary>
    public partial class WindowStart : Window
    {
        public WindowStart()
        {
            InitializeComponent();
        }
            
     public void WindowLoaded(object sender, RoutedEventArgs e)
        {
            ApplicationContext.Initialize();
            CheckServer();
        }
        public async void CheckServer()
        {
            await Task.Delay(5_000);
            if(ApplicationContext.DB.IsOnline())
            {
                 LoginWindow window = new LoginWindow();
                window.DataContext = new LoginWindowViewModel(window);
                window.Show();
                this.Close();
                return;
            }
            ConfigurationWindow configurationWindow = new ConfigurationWindow();
            configurationWindow.DataContext = new ConfigurationViewModel(configurationWindow);
            configurationWindow.Show();
            this.Close();
        }
    }
}
