using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneYe_WPF.Model
{
    class Money
    {
        public decimal Amount { get; set; }
        public Currency Currency { get; set; }

        private string CurrencyString()
        {
            return Currency switch
            {
                Currency.RuRub => "Russian Ruble",
                Currency.UsdDol => "USD Dollar",
                Currency.AznMan => "Azerbaijan Manat",
                _ => throw new InvalidEnumArgumentException(),
            };
        }
        public override string ToString()
        {
            return $"{Amount} {CurrencyString()}";
        }
    }
}
