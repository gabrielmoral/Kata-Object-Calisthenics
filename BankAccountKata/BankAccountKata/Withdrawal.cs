using System;

namespace BankAccountKata
{
    public class Withdrawal : IStatement
    {
        private readonly Money _money;
        private readonly DateTime _when;

        public Withdrawal(Money money, DateTime when)
        {
            _money = money;
            _when = when;
        }

        public override bool Equals(object obj)
        {
            var withdrawal = (Withdrawal) obj;

            return withdrawal._money.Equals(_money) && withdrawal._when.Equals(_when);
        }
    }
}