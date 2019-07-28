using System.Collections.Generic;
using System.Linq;

namespace BankAccountKata
{
    public class StatementList
    {
        private List<IStatement> _statements = new List<IStatement>();

        public void Add(IStatement statement)
        {
            _statements.Add(statement);
        }

        public override bool Equals(object obj)
        {
            var list = (StatementList) obj;

            return _statements.SequenceEqual(list._statements);
        }
    }
}