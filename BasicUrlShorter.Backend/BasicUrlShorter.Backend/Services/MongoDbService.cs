using BasicUrlShorter.Backend.Models;
using MongoDB.Driver;

namespace BasicUrlShorter.Backend.Services;

public class MongoDbService
{
    private IMongoDatabase GetDatabase()
    {
        const string connectionUri = "mongodb+srv://luca:test123@experimental.2oercwj.mongodb.net/?retryWrites=true&w=majority&appName=experimental";
        var settings = MongoClientSettings.FromConnectionString(connectionUri);
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        
        var client = new MongoClient(settings);
        try
        {
            var database = client.GetDatabase("urlShorterTest");
            Console.WriteLine("Pinged your deployment. You successfully connected to MongoDB!");
            return database;
        } catch (Exception ex) {
            Console.WriteLine(ex);
            return null;
        }
    }

    private async void CreateCollection()
    {
        var database = GetDatabase();
        await database.CreateCollectionAsync("Urls", new CreateCollectionOptions
        {
            Capped = true,
            MaxSize = 1024,
            MaxDocuments = 100
        });
    }

    public IMongoCollection<ShortenUrl> GetCollection(IMongoDatabase database)
    {
        return database.GetCollection<ShortenUrl>("Urls");
    }

    public ShortenUrl GetDocument(string shortenCode)
    {
        var database = GetDatabase();
        var collection = GetCollection(database);
        var filter = Builders<ShortenUrl>.Filter.Eq("shortenCode", shortenCode);
        var projection = Builders<ShortenUrl>.Projection.Exclude("_id");
        var document = collection.Find(filter).Project<ShortenUrl>(projection).FirstOrDefault();
        return document;
    }

    public void SaveDocument(ShortenUrl shortenUrl)
    {
        var database = GetDatabase();
        var collection = GetCollection(database);
        collection.InsertOne(shortenUrl);
    }
}
