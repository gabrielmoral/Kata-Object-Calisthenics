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

        public void Deposit(Deposit deposit)
        {
            _securitySafe.Add(deposit);
            _statementList.Add(deposit);
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