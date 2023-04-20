﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace WFBC.Shared.Models
{
    public class Draft
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public List<string>? Teams { get; set; }
        public List<string>? Picks { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public string DraftType { get; set; }
        public DateTime? Date { get; set; }
        public int Rounds { get; set; }
    }
}
