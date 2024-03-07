using MongoDB.Driver;
using MongoNotes.Models;

public static class DatabaseConfig
{
    public static void RegisterDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionStr = "mongodb://localhost:27017";
        services.AddSingleton<IMongoClient>(new MongoClient(connectionStr));

        var client = services.BuildServiceProvider().GetRequiredService<IMongoClient>();
        
        var database = client.GetDatabase("notesData");
        if (!DatabaseExists(client, "notesData"))
        {
            client.GetDatabase("notesData");
            
            database.CreateCollection("notes");
        }
        
        services.AddSingleton<IMongoCollection<Note>>(provider =>
        {
            var client = provider.GetRequiredService<IMongoClient>();
            var db = client.GetDatabase("notesData");
            return db.GetCollection<Note>("notes");
        });
    }

    private static bool DatabaseExists(IMongoClient client, string databaseName)
    {
        var databases = client.ListDatabaseNames().ToList();
        return databases.Contains(databaseName);
    }
}