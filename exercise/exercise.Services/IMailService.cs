using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.Services
{
    public interface IMailService
    {
        void SendMessage(string message, string to, string from = "MailService");
    }
}
