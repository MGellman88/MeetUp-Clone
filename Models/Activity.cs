using System;
using System.Collections.Generic;

namespace TheBelt.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }

        public int ParticipantId { get; set; }
        public string Event { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public TimeSpan Duration { get; set; }
        public int UserId { get; set; }
        public User Coordinator { get; set; }
        public string Location { get; set; }

        public List<Participant> Participants { get; set; }

        


    }
}