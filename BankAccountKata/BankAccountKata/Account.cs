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
            _statementList = new StatementList(statementPrinter);
        }

        public void Deposit(Deposit deposit)
        {
            _securitySafe.Add(deposit);
            _statementList.Add(deposit);
        }

        public void Withdraw(Withdrawal withdrawal)
        {
            _securitySafe.Take(withdrawal);
            _statementList.Add(withdrawal);
        }

        public string PrintStatement()
        {
            return _statementPrinter.Print();
        }
    }
}