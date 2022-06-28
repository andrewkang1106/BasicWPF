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
using ClientWPF.Models;
using ClientWPF.ViewModels;

namespace ClientWPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.DataContext = new MessageViewModel();
          /*  var messageDetails = new MessageModel();
            inputName.Text = messageDetails.Message;*/
            InitializeComponent();
        }

        private void Input_Btn_Click(object sender, RoutedEventArgs e)
        {
            //Make a new data source object
            var messageDetails = new MessageModel();
            messageDetails.Message = inputName.Text;
        }
    }
}
