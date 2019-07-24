using System;
using FakeItEasy;
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

            account.Deposit(new Money(1000), DateTime.Parse("10-01-2012"));

            A.CallTo(() => securitySafe.Add(new Money(1000))).MustHaveHappened();
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
            
            A.CallTo(() => statementPrinter.Print(A<StatementList>._)).MustHaveHappened();
        }
    }
}
