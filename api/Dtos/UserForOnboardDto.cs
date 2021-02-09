using System;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class UserForOnboardDto
    {
        public string City { get; set; }
        public string State { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Introduction { get; set; }
        public int Mileage { get; set; }
        public int Pace { get; set; }
        public string RunTime { get; set; }
    }
}