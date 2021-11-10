using System.Text.RegularExpressions;
using MoneYe_WPF.Model;

namespace MoneYe_WPF.Services
{
    public interface IValidator
    {
        Email GetEmail(string address);
        Phone GetPhone(string number);
        Match RegexCheck(string str, string regex);
    }
}