using System;

namespace TheBelt.Models
{
    public class Participant
    {
        public int ParticipantId { get; set; }
        public int UserId { get; set; }

        public User Attending { get; set; }

        public int AcitivityId { get; set; }

        public Activity Activity { get; set; }
    }
}