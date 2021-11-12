using System;
using MoneYe_WPF.Model;

namespace MoneYe_WPF.Services
{
    public class MoneyService
    {
        public static void Subtract(Money money, decimal amount)
        {
            if (money.Amount > amount)
            {
                money.Amount -= amount;
                money.Consumption += amount;
                return;
            }

            throw new Exception("Not enough money!");
        }

        public static void Add(Money money, decimal amount)
        {
            money.Amount += amount;
            money.Income += amount;
        }
    }
}