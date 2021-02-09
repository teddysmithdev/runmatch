using System;
using System.Collections.Generic;
using API.Entities;

namespace API.Dtos
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PhotoUrl { get; set; }
        public int Age { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string Gender { get; set; }
        public string Introduction { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Pace { get; set; }
        public int Mileage { get; set; }
        public string RunTime { get; set; }
        public ICollection<PhotoDto> Photos { get; set; }
        
    }
}