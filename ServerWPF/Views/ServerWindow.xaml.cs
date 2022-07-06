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
using ServerWPF.Models;
using ServerWPF.ViewModels;
using System.IO.MemoryMappedFiles;

namespace ServerWPF.Views
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ServerWindow : Window
    {
        MemoryMappedFile memoryMappedFileMediator;
        MemoryMappedViewAccessor memoryMappedFileView;
        public ServerWindow()
        {
            this.DataContext = new MessageViewModel();
            InitializeComponent();
            inputName.Text = "What is your name?";

            memoryMappedFileMediator = MemoryMappedFile.CreateNew("MediatorMemoryMappedFile", 1000, MemoryMappedFileAccess.ReadWrite); //Create MMF of name "string" size 1000 bytes, file access capabilites read/write
            memoryMappedFileView = memoryMappedFileMediator.CreateViewAccessor(); // use common memorymappedfile obj and create an accessor
        }

        private void Input_Btn_Click(object sender, RoutedEventArgs e)
        {
            //Make a new data source object
           // var messageDetails = new MessageModel();
           // messageDetails.Message = inputName.Text;

            byte[] message = Encoding.UTF8.GetBytes(inputName.Text); //byte [] <- message
            memoryMappedFileView.Write(0, message.Length); //position and size. If set to val > message.Length, the "new" message will show parts of the older msg if the new shorter than older msg
            memoryMappedFileView.WriteArray<byte>(4,message, 0,message.Length); //starting pos 4, reads in message, offset 0, count = length
            memoryMappedFileView.Flush(); //clears all buffers
        }

        private void Read_Btn_Click(object sender, RoutedEventArgs e)
        {
            byte[] message = new byte[memoryMappedFileView.ReadInt32(0)]; //create byte[] size of MMF by reading MMF from pos 0
            memoryMappedFileView.ReadArray<byte>(4,message,0, message.Length);
            string tempMsg = Encoding.UTF8.GetString(message, 0, message.Length);
            readMsg.Text = tempMsg;

        }
    }
}
