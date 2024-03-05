using System.Runtime.InteropServices.JavaScript;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoNotes.Models;

public class Note
{
    [BsonId]
    public ObjectId Id { get; set; }
    [BsonElement("date")]
    public DateTime Date { get; set; }
    [BsonElement("title")]
    public string Title { get; set; } = string.Empty;
    [BsonElement("description")]
    public string Description { get; set; } = string.Empty;
}