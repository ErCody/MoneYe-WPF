using System.ComponentModel;

namespace MoneYe_WPF.Model
{
   public class Money
   {
       public decimal Amount { get; set; } = 0;
        public decimal Income { get; set; } = 0;
        public decimal Consumption { get; set; } = 0;
        public Currency Currency { get; set; } = Currency.None;

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
        public override string ToString()
        {
            return $"{Amount} {CurrencyString()}";
        }
    }
}
