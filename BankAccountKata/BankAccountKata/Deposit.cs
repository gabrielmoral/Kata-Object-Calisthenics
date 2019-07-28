using System;

namespace BankAccountKata
{
    public interface IStatement
    {
    }

    public class Deposit : IStatement
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

        public override string ToString()
        {
            return $"{_when:d}||||{_money.ToString()}||{_money.ToString()}\n";
        }
    }
}