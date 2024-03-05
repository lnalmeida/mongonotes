using MongoDB.Bson;
using MongoDB.Driver;
using MongoNotes.Mappers;
using MongoNotes.Models;
using MongoNotes.ModelViews;

namespace MongoNotes.Repositories;

public class NotesRepository : IRepository
{
    private readonly IMongoCollection<Note> _noteCollection;

    public NotesRepository(IMongoCollection<Note> noteCollection)
    {
        _noteCollection = noteCollection;
    }

    public async Task<ICollection<NoteViewModel>> FindAll()
    {
        var notes = await _noteCollection.Find(_ => true).ToListAsync();
        var result = notes.Select(n => NotesMapper.MapTNoteViewModel(n)).ToList();
        return result;
    }

    public Task<NoteViewModel> Find(ObjectId id)
    {
        throw new NotImplementedException();
    }

    public Task<NoteViewModel> CreateNote(NoteViewModel entity)
    {
        throw new NotImplementedException();
    }

    public Task<NoteViewModel> EditNote(ObjectId id, NoteViewModel note)
    {
        throw new NotImplementedException();
    }

    public void DeleteNote(ObjectId id)
    {
        throw new NotImplementedException();
    }
}