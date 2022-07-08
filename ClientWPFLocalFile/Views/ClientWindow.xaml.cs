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
using ClientWPFLocalFile.Models;
using ClientWPFLocalFile.ViewModels;
using System.IO;

namespace ClientWPFLocalFile.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        public ClientWindow()
        {
            this.DataContext = new MessageViewModel();
            InitializeComponent();
            string filename = @"c:\Users\Owner\Documents\Github\BasicWPF\MsgFile.txt";
            FileStream fRead = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            var content = new string(' ', (int)fRead.Length);
            readMsg.Text = content;
        }

        private void Read_Btn_Click(object sender, RoutedEventArgs e)
        {
            //create fs obj
            string filename = @"c:\Users\Owner\Documents\Github\BasicWPF\MsgFile.txt";
            FileStream fRead = new FileStream(filename, FileMode.Open,FileAccess.Read, FileShare.Read);
            byte[] readArr = new byte[readMsg.Text.Length];
            int count;
            //string result = Encoding.UTF8.GetString(readArr);
            //read until end of file 
            while((count = fRead.Read(readArr, 0, readArr.Length)) > 0)
            {
                Console.WriteLine(Encoding.UTF8.GetString(readArr, 0, count));
            }
            readMsg.Text = Encoding.Default.GetString(readArr);
            fRead.Close();
        }
    }
}
