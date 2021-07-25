using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLibrary.Entities
{
    public class Product
    {
        [Required, BsonId]
        public string Id { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required, BsonElement("Name")]
        public string Name { get; set; }

    }
}
