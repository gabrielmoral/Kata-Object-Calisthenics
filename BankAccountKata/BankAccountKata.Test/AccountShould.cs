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

            var account = new Account(securitySafe);

            account.Deposit(new Money(1000), DateTime.Parse("10-01-2012"));

            A.CallTo(() => securitySafe.Add(1000)).MustHaveHappened();
        }
        
        [Test]
        public void WithdrawMoney()
        {
            var securitySafe = new Fake<ISecuritySafe>().FakedObject;

            var account = new Account(securitySafe);

            account.Withdraw(new Money(1000), DateTime.Parse("10-01-2012"));

            A.CallTo(() => securitySafe.Take(1000)).MustHaveHappened();
        }
    }
}
