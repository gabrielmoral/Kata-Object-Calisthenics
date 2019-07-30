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
            var result = statementPrinter.Print();
            Assert.That(result, Is.EqualTo("Date||Credit||Debit||Balance\n"));
        }
        
        [Test]
        public void PrintDeposit()
        {
            var statementPrinter= new StatementPrinter();
            statementPrinter.Add(new PrintableStatement(NewDeposit(1000), new Money(1000)));

            var result = statementPrinter.Print();
            Assert.That(result, Is.EqualTo("Date||Credit||Debit||Balance\n" +
                                           "10/01/2012||||1000||1000\n"));
        }
        
        [Test]
        public void PrintSeveralDeposits()
        {
            var statementPrinter= new StatementPrinter();
            statementPrinter.Add(new PrintableStatement(NewDeposit(1000), new Money(1000)));
            statementPrinter.Add(new PrintableStatement(NewDeposit(1000), new Money(2000)));
            
            var result = statementPrinter.Print();
            Assert.That(result, Is.EqualTo("Date||Credit||Debit||Balance\n" +
                                           "10/01/2012||||1000||2000\n" +
                                           "10/01/2012||||1000||1000\n"
                                           ));
        }
        
        private static Deposit NewDeposit(int amount)
        {
            return new Deposit(
                new Money(amount),
                DateTime.Parse("10-01-2012"));
        }

    }
}
