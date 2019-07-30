namespace BankAccountKata
{
    public interface ISecuritySafe
    {
        void Add(Deposit deposit);
        void Take(Withdrawal withdrawal);
    }

    public class SecuritySafe : ISecuritySafe
    {
        public void Add(Deposit deposit)
        {
            
        }

        public void Take(Withdrawal withdrawal)
        {
       }
    }
}