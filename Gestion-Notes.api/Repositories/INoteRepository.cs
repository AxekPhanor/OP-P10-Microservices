using Gestion_Notes.api.Data.Entities;
using MongoDB.Bson;

namespace Gestion_Notes.api.Repositories
{
    public interface INoteRepository
    {
        Task<Note> Create(Note note);
        Task<Note?> Update(Note note);
        Task<Note?> Delete(ObjectId id);
        Task<Note?> Read(ObjectId id);
        Task<List<Note>> List(int patientId);
    }
}
