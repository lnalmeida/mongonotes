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

    public async Task<NoteViewModel?> FindOne(string id)
    {
        var objectId = ObjectId.Parse(id);
        var filter =  Builders<Note>.Filter.Eq("_id", objectId);
        var note =  await _noteCollection.Find(filter).FirstOrDefaultAsync();
        if (note != null)
        {
            return NotesMapper.MapTNoteViewModel(note);
        }
        return null;
    }

    public async Task<NoteViewModel> CreateNote(NoteViewModel entity)
    {
        if (entity != null)
        {
            var newNote = NotesMapper.MapToNote(entity);
            await _noteCollection.InsertOneAsync(newNote);
            return entity;
        }
        return null;
    }

    public async Task<NoteViewModel> EditNote(string id, NoteViewModel note)
    {
        var objectId = ObjectId.Parse(id);
        var filter =  Builders<Note>.Filter.Eq("_id", objectId);
        var noteToUpdateCursor = await _noteCollection.Find(filter).FirstOrDefaultAsync();
        if (noteToUpdateCursor is not null)
        {
            noteToUpdateCursor.Id = note.Id;
            noteToUpdateCursor.Date = note.Date;
            noteToUpdateCursor.Title = note.Title;
            noteToUpdateCursor.Description = note.Description;

            await _noteCollection.ReplaceOneAsync(filter, noteToUpdateCursor);
            
            var viewModel = NotesMapper.MapTNoteViewModel(noteToUpdateCursor);
            return viewModel;
        }

        return null;
    }

    public Task DeleteNote(string id)
    {
        var objectId = ObjectId.Parse(id);
        var filter = Builders<Note>.Filter.Eq("_id", objectId);
        var noteToDelete = _noteCollection.Find(filter).FirstOrDefault();
        if (noteToDelete is not null)
        {
            _noteCollection.DeleteOne(filter);
            return Task.CompletedTask;
        }

        return null;
    }
}