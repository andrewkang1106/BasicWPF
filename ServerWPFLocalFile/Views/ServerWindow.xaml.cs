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
using ServerWPFLocalFile.Models;
using ServerWPFLocalFile.ViewModels;
using System.IO;

namespace ServerWPFLocalFile.Views
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ServerWindow : Window
    {
        public ServerWindow()
        {
            this.DataContext = new MessageViewModel();
            InitializeComponent();
            inputMsg.Text = "Enter Message Here";
        }

        private void Input_Btn_Click(object sender, RoutedEventArgs e)
        {
            //Make a new data source object
            var messageDetails = new MessageModel();
            messageDetails.Message = inputMsg.Text;
        }

        private void Read_Btn_Click(object sender, RoutedEventArgs e)
        {
            string filename = @"c:\Users\Owner\Documents\Github\BasicWPF\MsgFile.txt";

            FileStream fWrite = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
            var messageDetails = new MessageModel();
            messageDetails.Message = inputMsg.Text;

            var text = messageDetails.Message;

            byte[] writeArr = Encoding.UTF8.GetBytes(text);
            fWrite.Write(writeArr, 0, text.Length);
            fWrite.Close();
            //as of now, only updates txt file when I close the GUI
        }
    }
}
