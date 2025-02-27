﻿using System;

namespace MoneYe_WPF.Model
{
    public class User
    {
        public string Password { get; set; }


        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime? Age { get; set; }
        public Gender Gender { get; set; }
        public Email Email { get; set; }
        public Phone Phone { get; set; }

        public Money Balance { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {Surname}";
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
    public class Phone
    {
        public string Number { get; set; }
        public override string ToString()
        {
            return Number;
        }
    }

}
