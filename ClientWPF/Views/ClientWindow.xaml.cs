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
using ClientWPF.Models;
using ClientWPF.ViewModels;
using System.IO.MemoryMappedFiles;

namespace ClientWPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {

        MemoryMappedFile memoryMappedFileMediator;
        MemoryMappedViewAccessor memoryMappedFileView;
        public ClientWindow()
        {
            this.DataContext = new MessageViewModel();
            InitializeComponent();
            inputName.Text = "What is your name?";
        }

        private void Input_Btn_Click(object sender, RoutedEventArgs e)
        {
            //Make a new data source object
            var messageDetails = new MessageModel();
            messageDetails.Message = inputName.Text;
            
            //memoryMappedFileMediator.OpenExisting(@"Gloabl\MediatorMemoryMappedFile");
        }

        private void Read_Btn_Click(object sender, RoutedEventArgs e)
        {
            //byte[] message = new byte[memoryMappedFileView.ReadInt32(0)]; //create byte[] size of MMF by reading MMF from pos 0
            //memoryMappedFileView.ReadArray<byte>(4, message, 0, message.Length);
            //string tempMsg = Encoding.UTF8.GetString(message, 0, message.Length);
            //readMsg.Text = tempMsg;
        }
    }
}
