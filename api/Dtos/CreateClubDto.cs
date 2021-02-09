using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Domain;
using API.Entities;

namespace API.Dtos
{
    public class CreateClubDto
    {
        public string Name { get; set; }
        public string Intro { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public CreateEventDto Events { get; set; }
    }
}