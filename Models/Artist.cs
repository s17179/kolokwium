using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public class Artist
    {
        public int IdArtist { get; set; }

        public string Nickname { get; set; }

        public virtual ICollection<ArtistEvent> ArtistEvents { get; set; }

        public Artist()
        {
            ArtistEvents = new HashSet<ArtistEvent>();
        }
    }
}
