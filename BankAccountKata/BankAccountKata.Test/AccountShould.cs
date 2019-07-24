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

            account.Withdraw(new Money(1000), DateTime.Parse("10-01-2012"));

            A.CallTo(() => securitySafe.Take(new Money(1000))).MustHaveHappened();
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

        private static StatementList StatementListWith(Deposit deposit)
        {
            var statementListWithDeposit = new StatementList();
            statementListWithDeposit.Add(deposit);
            return statementListWithDeposit;
        }

        private static Deposit CreateDeposit()
        {
            return new Deposit(new Money(1000), DateTime.Parse("10-01-2012"));
        }
    }
}
