using System;

namespace API.Dtos
{
    public class MemberUpdateDto
    {
        public string Introduction { get; set; }
        public string Username { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}