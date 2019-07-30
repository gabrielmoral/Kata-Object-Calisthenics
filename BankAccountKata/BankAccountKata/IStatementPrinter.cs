namespace BankAccountKata
{
    public interface IStatementPrinter
    {
        void Add(PrintableStatement statement);
        string Print();
    }
}