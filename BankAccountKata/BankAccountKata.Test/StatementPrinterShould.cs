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
    }
}
