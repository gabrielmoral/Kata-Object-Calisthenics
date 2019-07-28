namespace BankAccountKata
{
    public class StatementPrinter : IStatementPrinter
    {
        public string Print(StatementList statementList)
        {
            const string statementHeader = "Date||Credit||Debit||Balance\n";
            
            var textStatement = statementHeader;

            foreach (var statement in statementList.Statements)
            {
                textStatement += statement.ToString();
            }
            
            return textStatement;
        }
    }
}