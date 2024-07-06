using Gestion_Notes.api.Data.Entities;
using Gestion_Notes.api.Models;
using Gestion_Notes.api.Repositories;
using MongoDB.Bson;

namespace Gestion_Notes.api.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository noteRepository;
        public NoteService(INoteRepository noteRepository)
        {
            this.noteRepository = noteRepository;
        }

        public async Task<List<NoteOutputModel>> GetNotes(int patientId)
        {
            try
            {
                var notes = await noteRepository.List(patientId);
                var output = new List<NoteOutputModel>();
                foreach (var note in notes)
                {
                    output.Add(ToOutputModel(note));
                }
                return output;
            }
            catch
            {
                throw;
            }
        }

        public async Task<NoteOutputModel> Create(NoteInputModel noteModel)
        {
            try
            {
                return ToOutputModel(await noteRepository.Create(new Note
                {
                    Content = noteModel.Content,
                    PatientId = noteModel.PatientId,
                }));
            }
            catch
            {
                throw;
            }
        }

        public async Task<NoteOutputModel?> Delete(ObjectId id)
        {
            try
            {
                var note = await noteRepository.Delete(id);
                if (note is null)
                {
                    return null;
                }
                return ToOutputModel(note);
            }
            catch
            {
                throw;
            }
        }

        public async Task<NoteOutputModel?> GetById(ObjectId id)
        {
            try
            {
                var note = await noteRepository.Read(id);
                if (note is not null)
                {
                    return ToOutputModel(note);
                }
                return null;
            }
            catch
            {
                throw;
            }
        }

        public async Task<NoteOutputModel?> Update(NoteInputModel noteModel, ObjectId id)
        {
            try
            {
                var noteUpdated = await noteRepository.Update(new Note
                {
                    Id = id,
                    Content = noteModel.Content,
                    PatientId = noteModel.PatientId,
                });

                if (noteUpdated is not null)
                {
                    return ToOutputModel(noteUpdated);
                }
                return null;
            }
            catch
            {
                throw;
            }
        }

        private NoteOutputModel ToOutputModel(Note note)
        {
            return new NoteOutputModel
            {
                Id = note.Id,
                Content = note.Content,
                PatientId = note.PatientId,
            };
        }
    }
}
