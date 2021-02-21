using System;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class UserForOnboardDto
    {
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        [DataType(DataType.DateTime, ErrorMessage="Please enter a valid datetime.")]
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; }
        public string Introduction { get; set; }
        [Required]
        public int Mileage { get; set; }
        [Required]
        public int Pace { get; set; }
        [Required]
        public string RunTime { get; set; }
    }
}