using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Domain;

namespace Products.Persistence.EntityTypeConfigurations
{
    public class EventLogConfiguration : IEntityTypeConfiguration<EventLog>
    {
        public void Configure(EntityTypeBuilder<EventLog> builder)
        {
            builder.ToTable("EventLog");

            builder.HasIndex(e => e.EventDate, "IX_EventLog_EventDate");

            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.EventDate)
                .HasColumnType("date")
                .HasDefaultValueSql("(getdate())");
        }
    }
}
