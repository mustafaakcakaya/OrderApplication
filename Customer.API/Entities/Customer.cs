using CommonLibrary.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.API.Entities
{
    public class Customer : BaseEntity
    {
        [BsonElement("Name"), Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public Address Address { get; set; }
    }
}
