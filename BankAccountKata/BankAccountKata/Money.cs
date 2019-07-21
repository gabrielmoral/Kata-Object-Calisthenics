namespace BankAccountKata
{
    public class Money
    {
        public Money(int amount)
        {
            Amount = amount;
        }

        public int Amount { get; private set; }
    }
}