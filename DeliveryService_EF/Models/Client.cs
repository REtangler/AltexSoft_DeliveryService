using System.ComponentModel.DataAnnotations.Schema;

namespace AltexFood_Delivery.DAL.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [NotMapped]
        public string FullName => FirstName + " " + LastName;
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
