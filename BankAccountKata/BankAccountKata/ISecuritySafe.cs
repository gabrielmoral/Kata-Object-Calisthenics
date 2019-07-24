namespace BankAccountKata
{
    public interface ISecuritySafe
    {
        void Add(Deposit deposit);
        void Take(Money money);
    }
}