using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exercise.Services
{
    public class MessageBoxMailService : IMailService
    {
        public void SendMessage(string message, string to, string from = "MailService")
        {
            MessageBox.Show($"сообщение {to} от {from} : {message}");
        }
    }
}
