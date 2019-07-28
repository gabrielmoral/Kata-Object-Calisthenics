using System;
using FakeItEasy;
using FakeItEasy.Sdk;
using NFluent;
using NUnit.Framework;

namespace BankAccountKata.Test
{
    public class AccountShould
    {
        [Test]
        public void DepositMoney()
        {
            var securitySafe = new Fake<ISecuritySafe>().FakedObject;
            var statementPrinter = new Fake<IStatementPrinter>().FakedObject;

            var account = new Account(securitySafe, statementPrinter);

            var deposit = CreateDeposit();
            account.Deposit(deposit);

            A.CallTo(() => securitySafe.Add(deposit)).MustHaveHappened();
        }
        
        [Test]
        public void WithdrawMoney()
        {
            var securitySafe = new Fake<ISecuritySafe>().FakedObject;
            var statementPrinter = new Fake<IStatementPrinter>().FakedObject;

            var account = new Account(securitySafe, statementPrinter);

            var withdrawal = CreateWithdrawal();
            account.Withdraw(withdrawal);

            A.CallTo(() => securitySafe.Take(withdrawal)).MustHaveHappened();
        }
        
        [Test]
        public void PrintStatement()
        {
            var securitySafe = new Fake<ISecuritySafe>().FakedObject;
            var statementPrinter = new Fake<IStatementPrinter>().FakedObject;
            
            var account = new Account(securitySafe, statementPrinter);

            account.PrintStatement();
            
            A.CallTo(() => statementPrinter.Print(new StatementList())).MustHaveHappened();
        }
        
        [Test]
        public void PrintStatementWithDeposit()
        {
            var securitySafe = new Fake<ISecuritySafe>().FakedObject;
            var statementPrinter = new Fake<IStatementPrinter>().FakedObject;
            
            var account = new Account(securitySafe, statementPrinter);
            var deposit = CreateDeposit();
            account.Deposit(deposit);

            account.PrintStatement();

            A.CallTo(() => statementPrinter.Print(StatementListWith(deposit)))
                .MustHaveHappened();
        }
        
        [Test]
        public void PrintStatementWithWithdrawal()
        {
            var securitySafe = new Fake<ISecuritySafe>().FakedObject;
            var statementPrinter = new Fake<IStatementPrinter>().FakedObject;
            
            var account = new Account(securitySafe, statementPrinter);
            var withdrawal = CreateWithdrawal();
            account.Withdraw(withdrawal);

            account.PrintStatement();

            A.CallTo(() => statementPrinter.Print(StatementListWith(withdrawal)))
                .MustHaveHappened();
        }

        private static StatementList StatementListWith(IStatement statement)
        {
            var statementList = new StatementList();
            statementList.Add(statement);
            return statementList;
        }

        private static Deposit CreateDeposit()
        {
            return new Deposit(new Money(1000), DateTime.Parse("10-01-2012"));
        }
        
        private static Withdrawal CreateWithdrawal()
        {
            return new Withdrawal(new Money(1000), DateTime.Parse("10-01-2012"));
        }
    }
}
