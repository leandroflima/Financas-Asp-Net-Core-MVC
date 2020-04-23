using Financas.Data.Contracts;
using Financas.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Financas.Services
{
    public class GroupService
    {
        private readonly IMongoCollection<Group> _collection;

        public GroupService(IFinancasDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _collection = database.GetCollection<Group>(settings.GroupsCollectionName);
        }

        public List<Group> Get() => 
            _collection.Find(item => true).ToList();

        public Group Get(string id) =>
            _collection.Find(item => item.Id == id).FirstOrDefault();

        public Group Create(Group item)
        {
            _collection.InsertOne(item);
            return item;
        }

        public void Update(string id, Group itemIn) =>
            _collection.ReplaceOne(item => item.Id == id, itemIn);

        public void Remove(Group itemIn) =>
            _collection.DeleteOne(item => item.Id == itemIn.Id);

        public void Remove(string id) =>
            _collection.DeleteOne(item => item.Id == id);
    }
}
