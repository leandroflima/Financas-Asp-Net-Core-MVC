using Financas.Data.Contracts;

namespace Financas.Data
{
    public class FinancasDatabaseSettings : IFinancasDatabaseSettings
    {
        public string GroupsCollectionName { get; set; }
        public string SubGroupsCollectionName { get; set; }
        public string AccountsCollectionName { get; set; }
        public string TransactionsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
