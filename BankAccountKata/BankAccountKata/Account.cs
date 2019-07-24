using System;

namespace BankAccountKata
{
    public class Account
    {
        private readonly ISecuritySafe _securitySafe;
        private readonly IStatementPrinter _statementPrinter;

        public Account(ISecuritySafe securitySafe, IStatementPrinter statementPrinter)
        {
            _securitySafe = securitySafe;
            _statementPrinter = statementPrinter;
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
            return _statementPrinter.Print(new StatementList());
        }
    }
}