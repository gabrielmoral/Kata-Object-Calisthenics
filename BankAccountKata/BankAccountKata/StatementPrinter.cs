using System.Collections.Generic;

namespace BankAccountKata
{
    public class StatementPrinter : IStatementPrinter
    {
        List<PrintableStatement> _statements = new List<PrintableStatement>();
        
        public string Print()
        {
            const string statementHeader = "Date||Credit||Debit||Balance\n";
            
            var textStatement = statementHeader;

            foreach (var statement in _statements)
            {
                textStatement += statement.ToString();
            }
            
            return textStatement;
        }

        public void Add(PrintableStatement statement)
        {
            _statements.Insert(0, statement);
        }
    }

    public class PrintableStatement
    {
        private readonly IStatement _statement;
        private readonly Money _total;

        public PrintableStatement(IStatement statement, Money total)
        {
            _statement = statement;
            _total = total;
        }

        public override string ToString()
        {
            return _statement.ToString() + _total.ToString() + "\n";
        }
    }
}