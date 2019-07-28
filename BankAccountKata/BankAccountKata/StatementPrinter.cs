namespace BankAccountKata
{
    public class StatementPrinter : IStatementPrinter
    {
        public string Print(StatementList statementList)
        {
            const string accountHeader = "Date||Credit||Debit||Balance\n";
            
            return accountHeader;
        }
    }
}