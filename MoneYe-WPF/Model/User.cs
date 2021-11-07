using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace MoneYe_WPF.Model
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }


        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime Age { get; set; }
        public Gender Gender { get; set; }
        public Email Email { get; set; }
        public override string ToString()
        {
            return $"{FirstName}";
        }
    }


    public class Email
    {
        public string Address { get; set; }
        public override string ToString()
        {
            return Address;
        }
    }
}
