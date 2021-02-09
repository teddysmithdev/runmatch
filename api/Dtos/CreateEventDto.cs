using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Entities;

namespace API.Domain
{
    public class CreateEventDto
    {
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
    }
}