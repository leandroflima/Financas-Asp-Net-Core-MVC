using Financas.Data.Contracts;
using Financas.Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Financas.Services
{
    public class AccountService
    {
        private readonly IMongoCollection<Account> _collection;

        public AccountService(IFinancasDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _collection = database.GetCollection<Account>(settings.AccountsCollectionName);
        }

        public List<Account> Get() =>
            _collection.Find(item => true).ToList();

        public Account Get(string id) =>
            _collection.Find<Account>(item => item.Id == id).FirstOrDefault();

        public Account Create(Account item)
        {
            _collection.InsertOne(item);
            return item;
        }

        public void Update(string id, Account itemIn) =>
            _collection.ReplaceOne(item => item.Id == id, itemIn);

        public void Remove(Account itemIn) =>
            _collection.DeleteOne(item => item.Id == itemIn.Id);

        public void Remove(string id) =>
            _collection.DeleteOne(item => item.Id == id);
    }
}
