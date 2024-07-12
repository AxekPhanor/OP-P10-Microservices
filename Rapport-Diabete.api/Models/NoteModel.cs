using MongoDB.Bson;

namespace Rapport_Diabete.api.Models
{
    public class NoteModel
    {
        public ObjectId Id { get; set; }
        public string Content { get; set; }
        public int PatientId { get; set; }
    }
}
