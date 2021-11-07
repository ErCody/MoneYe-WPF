using System;
using System.Text.RegularExpressions;
using MoneYe_WPF.Model;

namespace MoneYe_WPF.Services
{
    //class Email
    //{
    //    private Regex _regex;
    //    public string Address { get; private set; }

    //    public Email Get(string address)
    //    {
    //        var match = RegexCheck(address);
    //        if (match.Success)
    //        {
    //            Address = address;
    //            return new Email() { Address = address };
    //        }

    //        throw new Exception("For time");

    //    }

    //    private Match RegexCheck(string str)
    //    {
    //        _regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
    //        return _regex.Match(str);
    //    }

    //}

    interface IValidatorCreator
    {
        public Validator Create();
    }

    abstract class Validator
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public void VehicleInfo()
        {
            Console.WriteLine($"Make is: {Make}\nModel is: {Model}\nYear is: {Year}");
        }
    }

    class Email : Validator
    {
        public Email()
        {
            Make = "Ford";
            Model = "F150";
            Year = 2021;
        }
    }

    class Cycle : Validator
    {
        public Cycle()
        {
            Make = "Stels";
            Model = "Raptor";
            Year = 2010;
        }
    }

    class TruckCreator : IValidatorCreator
    {
        public Validator Create()
        {
            return new Email();
        }
    }

    class CycleCreator : IValidatorCreator
    {
        public Validator Create()
        {
            return new Cycle();
        }
    }
}