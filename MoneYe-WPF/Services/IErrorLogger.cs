using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoneYe_WPF.Services
{
    public interface IErrorLogger
    {
        public void LogError(string message, Exception ex);
    }
}
