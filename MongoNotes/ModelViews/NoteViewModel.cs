using System.Collections;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoNotes.ModelViews;

public class NoteViewModel
{
    [BsonId]
    public ObjectId Id { get; set; }
    [BsonElement]
    public DateTime Date { get; set; }
    [BsonElement]
    public string Title { get; set; } = string.Empty;
    [BsonElement]
    public string Description { get; set; } = string.Empty;
}