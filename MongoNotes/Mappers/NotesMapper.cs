using MongoDB.Bson;
using MongoNotes.Models;
using MongoNotes.ModelViews;


namespace MongoNotes.Mappers;

public static class NotesMapper
{
    public static Note MapToNote(NoteViewModel viewModel)
    {
        var note = new Note
        {
            Id = viewModel.Id,
            Date = viewModel.Date,
            Title = viewModel.Title,
            Description = viewModel.Description
        };

        return note;
    }

    public static NoteViewModel? MapTNoteViewModel(Note note)
    {
        var viewNote = new NoteViewModel
        {
            Id = note.Id,
            Date = note.Date,
            Title = note.Title,
            Description = note.Description
        };

        return viewNote;
    }
    
    public static NoteViewModel MapBsonDocumentToNoteViewModel(BsonDocument bsonDocument)
    {
        if (bsonDocument == null)
        {
            return null;
        }

        var noteViewModel = new NoteViewModel
        {
            Id = bsonDocument["_id"].AsObjectId,
            Date = bsonDocument["date"].AsBsonDateTime.ToUniversalTime(),
            Title = bsonDocument["title"].AsString,
            Description = bsonDocument.AsString
        };

        return noteViewModel;
    }
}