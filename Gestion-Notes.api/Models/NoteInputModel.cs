using MongoDB.Bson;

namespace Gestion_Notes.api.Models
{
    public class NoteInputModel
    {
        public string Content { get; set; }
        public int PatientId { get; set; }
    }
}
