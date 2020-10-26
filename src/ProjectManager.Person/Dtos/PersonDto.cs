using System;

namespace ProjectManager.Person.Dtos
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int PersonalDataId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
