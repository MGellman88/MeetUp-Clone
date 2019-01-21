using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheBelt.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Participant> Participants { get; set; }

    }
}