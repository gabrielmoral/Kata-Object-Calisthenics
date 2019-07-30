using System;

namespace BankAccountKata
{
    public interface IStatement
    {
        Money Value { get; }
    }

    public class Deposit : IStatement
    {
        private readonly DateTime _when;

        public Deposit(Money value, DateTime when)
        {
            Value = value;
            _when = when;
        }
        public Money Value { get; }

        public override bool Equals(object obj)
        {
            var deposit = (Deposit) obj;

            return deposit.Value.Equals(Value) && deposit._when.Equals(_when);
        }

        public override string ToString()
        {
            return $"{_when:d}||||{Value.ToString()}||";
        }
    }
}