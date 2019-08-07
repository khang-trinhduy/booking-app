using Booking;
using MongoDB.Driver;
using System.Collections.Generic;

namespace BookingApp.Services
{
    public class BookingServices
    {
        private readonly IMongoCollection<Contract> _contract;
        public BookingServices(IBookingDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _contract = database.GetCollection<Contract>(settings.CollectionName);
        }

        public List<Contract> Get() => _contract.Find(e => true).ToList();

        public Contract Get(string id) => _contract.Find(e => e.Id == id).FirstOrDefault();

        public Contract Create(Contract contract)
        {
            _contract.InsertOne(contract);
            return contract;
        }

        public void Update(string id, Contract contractIn) => _contract.ReplaceOne(e => e.Id == id, contractIn);

        public void Remove(string id) => _contract.DeleteOne(e => e.Id == id);

        public void Remove(Contract contract) => _contract.DeleteOne(e => e.Id == contract.Id);
    }
}