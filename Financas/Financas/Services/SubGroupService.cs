using Financas.Data.Contracts;
using Financas.Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Financas.Services
{
    public class SubGroupService
    {
        private readonly IMongoCollection<SubGroup> _collection;

        public SubGroupService(IFinancasDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _collection = database.GetCollection<SubGroup>(settings.SubGroupsCollectionName);
        }

        public List<SubGroup> Get() =>
            _collection.Find(item => true).ToList();

        public SubGroup Get(string id) =>
            _collection.Find(item => item.Id == id).FirstOrDefault();

        public SubGroup Create(SubGroup item)
        {
            _collection.InsertOne(item);
            return item;
        }

        public void Update(string id, SubGroup itemIn) =>
            _collection.ReplaceOne(item => item.Id == id, itemIn);

        public void Remove(SubGroup itemIn) =>
            _collection.DeleteOne(item => item.Id == itemIn.Id);

        public void Remove(string id) =>
            _collection.DeleteOne(item => item.Id == id);
    }
}
