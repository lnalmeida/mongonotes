using MongoDB.Bson;
using MongoNotes.Models;
using MongoNotes.ModelViews;

namespace MongoNotes.Repositories;

public interface IRepository
{
    Task<ICollection<NoteViewModel>> FindAll();
    Task<NoteViewModel> Find(ObjectId id);
    Task<NoteViewModel> CreateNote(NoteViewModel entity);
    Task<NoteViewModel> EditNote(ObjectId id, NoteViewModel note);
    void DeleteNote(ObjectId id);
}