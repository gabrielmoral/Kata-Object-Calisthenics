namespace BankAccountKata
{
    public interface ISecuritySafe
    {
        void Add(Deposit deposit);
        void Take(Withdrawal withdrawal);
    }
}