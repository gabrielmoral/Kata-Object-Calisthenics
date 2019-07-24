using System;

namespace BankAccountKata
{
    public class Deposit
    {
        private readonly Money _money;
        private readonly DateTime _when;

        public Deposit(Money money, DateTime when)
        {
            _money = money;
            _when = when;
        }

        public override bool Equals(object obj)
        {
            var deposit = (Deposit) obj;

            return deposit._money.Equals(_money) && deposit._when.Equals(_when);
        }
    }
}