﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
using AutoStatusLineChart.ViewModel;

namespace AutoStatusLineChart
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow window = new MainWindow();
            MainWindowViewModel VM = new MainWindowViewModel();
            window.DataContext = VM;
            window.Show();
        }
    }



    //protected override void OnStartup(StartupEventArgs e)
    //{
    //    base.OnStartup(e);
    //    WpfMVVMSample.MainWindow window = new MainWindow();
    //    UserViewModel VM = new UserViewModel();
    //    window.DataContext = VM;
    //    window.Show();
    //}
}
