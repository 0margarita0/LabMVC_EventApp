using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lab04.Models
{
    public class EventModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Името на настанот е задолжително.")]
        public string name { get; set; }

        [Required(ErrorMessage = "Локацијата на настанот е задолжителна.")]
        [StringLength(30, MinimumLength = 5)]
        public string location { get; set; }
    }
}