using Acme.Data.Types;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Acme.Data.Models
{
    [Table("Addresses")]
    public class Address: BaseModel
    {
        
        [Column("Street")]        
        
        public string[] Street { get; set; }

        [Column("City")]
        public string City { get; set; }

        [Column("State")]
        public string State { get; set; }

        [Column("Zip")]
        public string Zip { get; set; }

        [Column("Primary")]
        public bool Primary { get; set; } = false;

        AddressType AddressType { get; set; } = AddressType.Unknown;

        public Address()
        {

        }

        public Address(string[] street, string city, string state, string zip, bool primary)
        {
            Street = street;
            City = city;
            State = state;
            Zip = zip;
            Primary = primary;
            AddressType = AddressType.Unknown;
        }
    }
}
