using Gestion_Notes.api.Models;
using MongoDB.Bson;

namespace Gestion_Notes.api.Services
{
    public interface INoteService
    {
        Task<NoteOutputModel> Create(NoteInputModel noteModel);
        Task<NoteOutputModel?> GetById(ObjectId id);
        Task<NoteOutputModel?> Update(NoteInputModel noteModel, ObjectId id);
        Task<NoteOutputModel?> Delete(ObjectId id);
        Task<List<NoteOutputModel>> GetNotes(int patientId);
    }
}
