using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace Acme.Data.Models
{
    [Table("Contacts")]
    public class Contact: BaseModel
    {
        
        [Column("First_Name")]
        public string FirstName { get; set; }

        [Column("Last_Name")]
        public string LastName { get; set; }


        public virtual ICollection<Address> Addresses { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("Phone")]
        public string Phone { get; set; }

        public Contact()
        {

        }
        public Contact(string firstName, string lastName, IList<Address> addresses, string email, string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Addresses = addresses ?? Array.Empty<Address>();
            Email = email;
            Phone = phone;
        }
    }
}
