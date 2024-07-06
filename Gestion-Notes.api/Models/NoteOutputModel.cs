using MongoDB.Bson;

namespace Gestion_Notes.api.Models
{
    public class NoteOutputModel
    {
        public ObjectId Id { get; set; }
        public string Content { get; set; }
        public int PatientId { get; set; }
    }
}
