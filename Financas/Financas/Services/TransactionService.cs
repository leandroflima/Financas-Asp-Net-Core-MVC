using Financas.Data.Contracts;
using Financas.Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Financas.Services
{
    public class TransactionService
    {
        private readonly IMongoCollection<Transaction> _collection;

        public TransactionService(IFinancasDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _collection = database.GetCollection<Transaction>(settings.TransactionsCollectionName);
        }

        public List<Transaction> Get() =>
            _collection.Find(item => true).ToList();

        public Transaction Get(string id) =>
            _collection.Find<Transaction>(item => item.Id == id).FirstOrDefault();

        public Transaction Create(Transaction item)
        {
            _collection.InsertOne(item);
            return item;
        }

        public void Update(string id, Transaction itemIn) =>
            _collection.ReplaceOne(item => item.Id == id, itemIn);

        public void Remove(Transaction itemIn) =>
            _collection.DeleteOne(item => item.Id == itemIn.Id);

        public void Remove(string id) =>
            _collection.DeleteOne(item => item.Id == id);
    }
}
