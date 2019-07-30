using System;

namespace BankAccountKata
{
    public class Withdrawal : IStatement
    {
        private readonly DateTime _when;

        public Withdrawal(Money value, DateTime when)
        {
            Value = value;
            _when = when;
        }

        public Money Value { get; }
        
        public override bool Equals(object obj)
        {
            var withdrawal = (Withdrawal) obj;

            return withdrawal.Value.Equals(Value) && withdrawal._when.Equals(_when);
        }

        public override string ToString()
        {
            return $"{_when:d}||{Value.ToString()}||||";
        }
    }
}