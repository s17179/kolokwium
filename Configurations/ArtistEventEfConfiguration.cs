using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Configurations
{
    public class ArtistEventEfConfiguration : IEntityTypeConfiguration<ArtistEvent>
    {
        public void Configure(EntityTypeBuilder<ArtistEvent> builder)
        {
            builder.HasKey(a => new { a.IdArtist, a.IdEvent });
        }
    }
}
