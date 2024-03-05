using MongoDB.Bson;

namespace MongoNotes.ModelViews;

public class InsertNoteModelView
{
    public ObjectId Id { get; set; }
    public DateTime Date { get; set; } = DateTime.Now.Date;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}