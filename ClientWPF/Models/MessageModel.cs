using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWPF.Models
{
    public class MessageModel
    {
        private string _message;

        public string Message 
        { 
            get { return _message; } 
            set 
            { 
                _message = value; 
            } 
        }

    }
}
