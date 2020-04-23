namespace Financas.Data.Contracts
{
    public interface IFinancasDatabaseSettings
    {
        public string GroupsCollectionName { get; set; }

        public string SubGroupsCollectionName { get; set; }

        public string AccountsCollectionName { get; set; }

        public string TransactionsCollectionName { get; set; }

        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}
