using System;
using NFluent;
using NUnit.Framework;

namespace BankAccountKata.Test
{
    public class BankAccountTest
    {
        [Test]
        public void CanDeposeAndWithdrawMoneyOnMyAccount()
        {
            var account = new Account(new SecuritySafe());
            account.Deposit(new Money(1000), DateTime.Parse("10-01-2012"));
            account.Deposit(new Money(1000), DateTime.Parse("13-01-2012"));
            account.Withdraw(new Money(200), DateTime.Parse("14-01-2012"));
            
            var printStatement = account.PrintStatement();
            Assert.That(printStatement, Is.EqualTo(
                "Date||Credit||Debit||Balance\n" +
                "14/01/2012||200||||1800\n" +
                "13/01/2012||||1000||2000\n" +
                "10/01/2012||||1000||1000\n"));
        }
    }

    public class SecuritySafe : ISecuritySafe
    {
        public void Add(int amount)
        {
        }

        public void Take(int amount)
        {
            
        }
    }
}
