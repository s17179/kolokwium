using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public class EventOrganiser
    {
        [ForeignKey("Event")]
        public int IdEvent { get; set; }

        public Event Event { get; set; }

        [ForeignKey("Organiser")]
        public int IdOrganiser { get; set; }

        public Organiser Organiser { get; set; }
    }
}
