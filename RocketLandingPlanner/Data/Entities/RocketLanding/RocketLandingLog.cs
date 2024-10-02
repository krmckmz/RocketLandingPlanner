using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RocketLandingPlanner.Data.Entities.RocketLanding
{
    [CollectionName("RocketLandingLog")]
    public class RocketLandingLog
    {
        [BsonId]
        [BsonElement("_id")]
        [Key]
        public ObjectId Id { get; set; }
        public string BatchRequestId { get; set; }
        public int HorizontalIndex { get; set; }
        public int VerticalIndex { get; set; }
        public string ResponseType { get; set; }
        public string ErrorMessage { get; set; }
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
