using System;
using System.Text.RegularExpressions;
using MoneYe_WPF.Model;

namespace MoneYe_WPF.Services
{
    class Validator : IValidator
    {
        private Regex _regex;

        public Email GetEmail(string address)
        {
            var match = RegexCheck(address, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (match.Success)
            {
                return new Email() { Address = address };
            }
            throw new Exception("For time");
        }

        public Phone GetPhone(string number)
        {
            //var match = RegexCheck(number, @"([+-]?(?=\.\d|\d)(?:\d+)?(?:\.?\d*))(?:[eE]([+-]?\d+))?(\s([0-9]+\s)+)?(\s([0-9]+\s)+)");
            //if (match.Success)
            //{
            //    return new Phone() { Number = number };
            //}
            //throw new Exception("For time");
            return new Phone() { Number = number };
        }

        public Match RegexCheck(string str, string regex)
        {
            _regex = new Regex(regex);
            return _regex.Match(str);
        }

    }
}