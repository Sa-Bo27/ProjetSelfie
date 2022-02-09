using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SelfieAWookies.Core.Selfies.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookies.Core.Selfies.Infrastructures.Data.TypeConfigurations
{
    /// <summary>
    /// Permet de gerer sois meme la configuration des tables dans sql
    /// </summary>
    class SelfieEntityTypeConfiguration : IEntityTypeConfiguration<Selfie>
    {
        public void Configure(EntityTypeBuilder<Selfie> builder)
        {
            builder.ToTable("Selfie");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Wookie)
                .WithMany(x => x.Selfies);

        }
    }
}
