namespace BankAccountKata
{
    public interface ISecuritySafe
    {
        void Add(Money money);
        void Take(Money money);
    }
}