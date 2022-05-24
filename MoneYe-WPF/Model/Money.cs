using System.ComponentModel;

namespace MoneYe_WPF.Model
{
    //REFACTOR: Rename this class to wallet
   public class Money
   {
       public decimal Amount { get; set; } = 0;
        public decimal Income { get; set; } = 0;
        public decimal Consumption { get; set; } = 0;
        public Currency Currency { get; set; } = Currency.None; //REFACTOR: Get rid of default values

        //REFACTOR: Move to another service?
        private string CurrencyString()
        {
            return Currency switch
            {
                Currency.RuRub => "RUB",
                Currency.UsdDol => "USD",
                Currency.AznMan => "AZN",
                _ => throw new InvalidEnumArgumentException(),
            };
        }
        //REFACTOR: Get rid of this method.
        public override string ToString()
        {
            return $"{Amount} {CurrencyString()}";
        }
    }
}
