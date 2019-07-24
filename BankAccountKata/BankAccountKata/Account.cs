using System;

namespace BankAccountKata
{
    public class Account
    {
        private readonly ISecuritySafe _securitySafe;
        private readonly IStatementPrinter _statementPrinter;
        private readonly StatementList _statementList;

        public Account(ISecuritySafe securitySafe, IStatementPrinter statementPrinter)
        {
            _securitySafe = securitySafe;
            _statementPrinter = statementPrinter;
            _statementList = new StatementList();
        }

        public void Deposit(Money money, DateTime parse)
        {
            _securitySafe.Add(money);
            _statementList.Add(new Deposit(money, parse));
        }

        public void Withdraw(Money money, DateTime parse)
        {
            _securitySafe.Take(money);
        }

        public string PrintStatement()
        {
            return _statementPrinter.Print(_statementList);
        }
    }
}