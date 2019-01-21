using System;
using System.ComponentModel.DataAnnotations;

namespace TheBelt.ViewModels
{
    public class ActivityViewModel
    {
        [Required(ErrorMessage = "Required Field")]
        public string Event { get; set; }
      
        [Required(ErrorMessage = "Required Field")]
        [DataType (DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Required Field")]
        public string Description { get; set; }

        [Required]
        public string Location { get; set; }

        public TimeSpan Duration { get; set; }
    }
}