using System.Collections.Generic;
using System.Linq;

namespace BankAccountKata
{
    public class StatementList
    {
        private List<Deposit> _statements = new List<Deposit>();

        public void Add(Deposit deposit)
        {
            _statements.Add(deposit);
        }

        public override bool Equals(object obj)
        {
            var list = (StatementList) obj;

            return _statements.SequenceEqual(list._statements);
        }
    }
}