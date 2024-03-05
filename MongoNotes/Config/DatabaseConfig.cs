using MongoDB.Driver;
using MongoNotes.Models;

public static class DatabaseConfig
{
    public static void RegisterDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionStr = "mongodb://localhost:27017";
        services.AddSingleton<IMongoClient>(new MongoClient(connectionStr));

        var client = services.BuildServiceProvider().GetRequiredService<IMongoClient>();

        // Verifique a existência do banco de dados
        var database = client.GetDatabase("notesData");
        if (!DatabaseExists(client, "notesData"))
        {
            // Crie o banco de dados
            client.GetDatabase("notesData");

            // Crie a coleção dentro do banco de dados
            database.CreateCollection("notes");
        }

        // Adicione o IMongoCollection<Note> como um serviço
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