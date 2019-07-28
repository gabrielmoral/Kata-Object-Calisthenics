namespace BankAccountKata
{
    public class Money
    {
        private int _amount;

        public Money(int amount)
        {
            _amount = amount;
        }
        
        public override bool Equals(object obj)
        {
            var money = (Money) obj;
            return money._amount == _amount;
        }

        public override string ToString()
        {
            return _amount.ToString();
        }
    }
}