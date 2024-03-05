using System.Collections;
using MongoDB.Bson;

namespace MongoNotes.ModelViews;

public class NoteViewModel
{
    public ObjectId Id { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow.Date;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}