using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using FluentAssertions;
namespace CSharp_HelloMongo
{
    class Program
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        static void Main(string[] args)
        {
            _client = new MongoClient();
            _database = _client.GetDatabase("test");

            //InsertData();
            QueryData();
            Console.ReadLine();
            //var filter = Builders<BsonDocument>.Filter.Eq(< field >, < value >);
        }

        private static async void QueryData()
        {
            var collection = _database.GetCollection<BsonDocument>("restaurants");
            var filter = new BsonDocument();
            var sort = Builders<BsonDocument>.Sort.Ascending("borough").Ascending("address.zipcode");
            var result = await collection.Find(filter).Sort(sort).ToListAsync();
        }
        private static async void QueryData_9()
        {
            var collection = _database.GetCollection<BsonDocument>("restaurants");
            var filter = new BsonDocument();
            var sort = Builders<BsonDocument>.Sort.Ascending("borough").Ascending("address.zipcode");
            var result = await collection.Find(filter).Sort(sort).ToListAsync();
        }
        private static async void QueryData_8()
        {
            var collection = _database.GetCollection<BsonDocument>("restaurants");
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("cuisine", "Italian") | builder.Eq("address.zipcode", "10075");
            var result = await collection.Find(filter).ToListAsync();
        }
        private static async void QueryData_7()
        {
            var collection = _database.GetCollection<BsonDocument>("restaurants");
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("cuisine", "Italian") & builder.Eq("address.zipcode", "10075");
            var result = await collection.Find(filter).ToListAsync();
        }

        private static async void QueryData_6()
        {
            var collection = _database.GetCollection<BsonDocument>("restaurants");
            var filter = Builders<BsonDocument>.Filter.Lt("grades.score", 10);
            var result = await collection.Find(filter).ToListAsync();
        }
        private static async void QueryData_5()
        {
            var collection = _database.GetCollection<BsonDocument>("restaurants");
            var filter = Builders<BsonDocument>.Filter.Gt("grades.score", 30);
            var result = await collection.Find(filter).ToListAsync();
        }
        private static async void QueryData_4()
        {
            var collection = _database.GetCollection<BsonDocument>("restaurants");
            var filter = Builders<BsonDocument>.Filter.Eq("grades.grade", "B");
            var result = await collection.Find(filter).ToListAsync();
        }
        private static async void QueryData_3()
        {
            var collection = _database.GetCollection<BsonDocument>("restaurants");
            var filter = Builders<BsonDocument>.Filter.Eq("address.zipcode", "10075");
            var result = await collection.Find(filter).ToListAsync();
        }
        private static async void QueryData_2()
        {
            var collection = _database.GetCollection<BsonDocument>("restaurants");
            var filter = Builders<BsonDocument>.Filter.Eq("borough", "Manhattan");
            var result = await collection.Find(filter).ToListAsync();
        }

        private static async void QueryData_1()
        {
            //Find or Query Data with C# Driver
            var collection = _database.GetCollection<BsonDocument>("restaurants");
            var filter = new BsonDocument();
            var count = 0;
            using (var cursor = await collection.FindAsync(filter))
            {
                while (await cursor.MoveNextAsync())
                {
                    var batch = cursor.Current;
                    foreach (var document in batch)
                    {
                        // process document
                        Console.WriteLine();
                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine("Count'restaurants': {0}", count.ToString());
                        Console.WriteLine("----------------------------------------------");
                        Console.Write(document.ToString());
                        count++;
                    }
                }
            }
            //count.Should().Be(25359);
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Count'restaurants': {0}", count.ToString());
            Console.WriteLine("----------------------------------------------");

        }
        private static async void InsertData()
        {
            //Insert Data with C# Driver
            var document = new BsonDocument
            {
                { "address" , new BsonDocument
                    {
                        { "street", "2 Avenue" },
                        { "zipcode", "10075" },
                        { "building", "1480" },
                        { "coord", new BsonArray { 73.9557413, 40.7720266 } }
                    }
                },
                { "borough", "Manhattan" },
                { "cuisine", "Italian" },
                { "grades", new BsonArray
                    {
                        new BsonDocument
                        {
                            { "date", new DateTime(2014, 10, 1, 0, 0, 0, DateTimeKind.Utc) },
                            { "grade", "A" },
                            { "score", 11 }
                        },
                        new BsonDocument
                        {
                            { "date", new DateTime(2014, 1, 6, 0, 0, 0, DateTimeKind.Utc) },
                            { "grade", "B" },
                            { "score", 17 }
                        }
                    }
                },
                { "name", "Vella" },
                { "restaurant_id", "41704620" }
            };

            var collection = _database.GetCollection<BsonDocument>("restaurants");
            await collection.InsertOneAsync(document);
        }
    }
}
