using System;

namespace ProjectManager.Person.Dtos
{
    public class PersonDto
    {
        public int PersonId { get; set; }
        public string UserId { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string CompanyName { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
    }
}
