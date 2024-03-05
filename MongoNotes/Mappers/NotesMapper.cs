using MongoNotes.Models;
using MongoNotes.ModelViews;
using ZstdSharp.Unsafe;

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

    public static NoteViewModel MapTNoteViewModel(Note note)
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
}