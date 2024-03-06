using MongoDB.Bson;
using MongoNotes.Models;
using MongoNotes.ModelViews;

namespace MongoNotes.Repositories;

public interface IRepository
{
    Task<ICollection<NoteViewModel>> FindAll();
    Task<NoteViewModel?> FindOne(string id);
    Task<NoteViewModel> CreateNote(NoteViewModel entity);
    Task<NoteViewModel> EditNote(string id, NoteViewModel note);
    Task DeleteNote(string id);
}