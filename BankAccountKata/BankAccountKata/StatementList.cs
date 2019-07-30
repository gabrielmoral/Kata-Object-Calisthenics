using System;
using System.Collections.Generic;
using System.Linq;

namespace BankAccountKata
{
    public class StatementList
    {
        private readonly IStatementPrinter _statementPrinter;
        private List<IStatement> _statements = new List<IStatement>();
        private Money _totalAmount = new Money(0);

        public StatementList(IStatementPrinter statementPrinter)
        {
            _statementPrinter = statementPrinter;
        }

        public void Add(IStatement statement)
        {
            _statements.Add(statement);
            _statementPrinter.Add(new PrintableStatement(statement, RecalculateTotal(statement)));
        }

        public override bool Equals(object obj)
        {
            var list = (StatementList) obj;

            return _statements.SequenceEqual(list._statements);
        }
        
        private Money RecalculateTotal(IStatement statement)
        {
            switch (statement)
            {
                case Deposit d:
                    _totalAmount += d.Value;
                    return _totalAmount;
                case Withdrawal w:
                    _totalAmount -= w.Value;
                    return _totalAmount;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}