using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MoneYe_WPF.Services
{
    public class ErrorLogger : IErrorLogger
    {
        private readonly string filepath = $@"Logs\{DateTime.Now.ToFileTime()}.log";

        public void LogError(string message, Exception ex)
        {
            var log = $"[{DateTime.Now.ToLocalTime()}] [ERROR]  [Message:] {message}\n{ex.Message}\n";

            File.AppendAllText(filepath, log);
        }
    }
}
