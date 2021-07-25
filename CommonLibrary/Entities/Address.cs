using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLibrary.Entities
{
    public class Address
    {
        public string AddressLine { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required, Range(1, 81)]
        public int? CityCode { get; set; }
    }
}
