

using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.SharePoint.Client;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Data.Entity;
using System.Text.Json;
class Program
{
    static void Main(string[] args)
    {
        var connectionString = "mongodb://uop-ye-cosmos-db-dev:zofFqXUypV2bvcOILfWDi7LHgeV9SlESv7WXiTrSN0xiqQYcDBuTJ2BnqOslroAEuu21yDRDv3fLACDbFmSb6Q%3D%3D@uop-ye-cosmos-db-dev.mongo.cosmos.azure.com:10255/?ssl=true&replicaSet=globaldb&retrywrites=false&maxIdleTimeMS=120000&appName=@uop-ye-cosmos-db-dev@";
        var client = new MongoClient(connectionString);

        // Access a database
        var database = client.GetDatabase("xlMigration");

        // Access a collection
        var collection = database.GetCollection<BsonDocument>("MigrationFileCollection");

        // Define a filter to retrieve documents (optional)
        var filter = Builders<BsonDocument>.Filter.Empty;
        var filters = Builders<BsonDocument>.Filter.Eq("IsHydatPlant", false);

        // Retrieve documents that match the filter
        var result = FileCollection.Find(filters).ToList();
        if (result != null)
        {
            foreach (BsonDocument element in result)
            {
                var plantNumber = element.GetValue("PLANTNUMBER").ToString();
                plantNumber = element.ToString().Replace(" ", "");
                foreach (var item in hydatPlant)
                {
                    if (item == plantNumber)
                    {
                        var filter = Builders<BsonDocument>.Filter.Eq("_id", element.GetValue("_id"));
                        var update = Builders<BsonDocument>.Update.Set("IsHydatPlant", true);
                        var updateResult = await fileCollection.UpdateOneAsync(filters, update);

                        // Set IsHydatPlant to true
                        element.Set("IsHydatPlant", true);
                        break;
                    }
                }
            }

           
        }
        else
        {
            Console.WriteLine("No record found");
            return null;
        }
    }


}
