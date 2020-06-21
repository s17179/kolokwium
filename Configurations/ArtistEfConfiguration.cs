using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Configurations
{
    public class ArtistEfConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.HasKey(a => a.IdArtist);

            builder
                .Property(a => a.Nickname)
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
