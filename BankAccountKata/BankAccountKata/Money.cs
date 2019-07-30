namespace BankAccountKata
{
    public class Money
    {
        private int _amount;

        public Money(int amount)
        {
            _amount = amount;
        }
        
        public static Money operator+ (Money b, Money c)
        {
            return new Money(b._amount + c._amount);   
        }
        
        public static Money operator- (Money b, Money c)
        {
            return new Money(b._amount - c._amount);   
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