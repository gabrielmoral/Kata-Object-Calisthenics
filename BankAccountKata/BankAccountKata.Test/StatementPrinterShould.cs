using System;
using NUnit.Framework;

namespace BankAccountKata.Test
{
    public class StatementPrinterShould
    {
        [Test]
        public void PrintEmptyAccountIfNoStatements()
        {
            var statementPrinter= new StatementPrinter();
            var result = statementPrinter.Print(new StatementList());
            Assert.That(result, Is.EqualTo("Date||Credit||Debit||Balance\n"));
        }
        
        [Test]
        public void PrintDeposit()
        {
            var statementPrinter= new StatementPrinter();
            var statementList = new StatementList();
            statementList.Add(
                new Deposit(
                    new Money(1000),
                    DateTime.Parse("10-01-2012")));
            
            var result = statementPrinter.Print(statementList);
            Assert.That(result, Is.EqualTo("Date||Credit||Debit||Balance\n" +
                                           "10/01/2012||||1000||1000\n"));
        }
    }
}
