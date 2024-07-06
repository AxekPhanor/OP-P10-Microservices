using MongoDB.Bson;

namespace Gestion_Notes.api.Data.Entities
{
    public class Note
    {
        public ObjectId Id { get; set; }
        public string Content { get; set; }
        public int PatientId { get; set; }
    }
}
