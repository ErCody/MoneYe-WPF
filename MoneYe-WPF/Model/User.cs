using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneYe_WPF.Model
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public ushort Age { get; set; }

        public override string ToString()
        {
            return $"{FirstName}";
        }
    }
}
