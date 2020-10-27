using System;

namespace ProjectManager.Person.Dtos
{
    public class PersonDto
    {
        public int PersonId { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Telephone { get; set; }
        public string Country { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
