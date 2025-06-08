using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HospedaFacil.Domain.Models
{
    public class Hotel
    {
        [BsonId]
        public string? MongoId { get; set; }  // Campo Bson do MongoDB

        [BsonElement("sql_id")]
        public int Id { get; set; } // Campo próprio Id para ser usado na integração com SQL Server

        [BsonElement("nome")]
        public required string Nome { get; set; }
    }
}
