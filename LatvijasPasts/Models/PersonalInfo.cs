﻿namespace LatvijasPasts.Models
{
    public class PersonalInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<WorkExperience>? WorkExperiences { get; set; }
        public List<Education>? Educations { get; set; }
    }
}