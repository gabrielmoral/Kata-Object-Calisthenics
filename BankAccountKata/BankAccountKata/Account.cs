using System;

namespace BankAccountKata
{
    public class Account
    {
        private readonly ISecuritySafe _securitySafe;

        public Account(ISecuritySafe securitySafe)
        {
            _securitySafe = securitySafe;
        }

        public void Deposit(Money money, DateTime parse)
        {
            _securitySafe.Add(money);
        }

        public void Withdraw(Money money, DateTime parse)
        {
            _securitySafe.Take(money);
        }

        public string PrintStatement()
        {
            throw new NotImplementedException();
        }
    }
}