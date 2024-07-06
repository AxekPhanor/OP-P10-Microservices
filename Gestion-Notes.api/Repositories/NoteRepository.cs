using Gestion_Notes.api.Data;
using Gestion_Notes.api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

namespace Gestion_Notes.api.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly MongoDbContext dbContext;
        public NoteRepository(MongoDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }
        public async Task<Note> Create(Note note)
        {
            try
            {
                await dbContext.Notes.AddAsync(note);
                await dbContext.SaveChangesAsync();
                return note;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Note?> Delete(ObjectId id)
        {
            try
            {
                var note = await dbContext.Notes.FirstOrDefaultAsync(note => note.Id == id);
                if (note is not null)
                {
                    dbContext.Notes.Remove(note);
                    await dbContext.SaveChangesAsync();
                }
                return note;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Note>> List(int patientId)
        {
            try
            {
                return await dbContext.Notes.Where(note => note.PatientId == patientId).ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Note?> Read(ObjectId id)
        {
            try
            {
                var note = await dbContext.Notes.FirstOrDefaultAsync(note => note.Id == id);
                return note;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Note?> Update(Note note)
        {
            try
            {
                var noteToUpdate = await dbContext.Notes.FirstOrDefaultAsync(n => n.Id == note.Id);
                if (noteToUpdate is not null)
                {
                    noteToUpdate.Content = note.Content;
                    noteToUpdate.PatientId = note.PatientId;
                    await dbContext.SaveChangesAsync();
                }
                return noteToUpdate;
            }
            catch
            {
                throw;
            }
        }
    }
}
