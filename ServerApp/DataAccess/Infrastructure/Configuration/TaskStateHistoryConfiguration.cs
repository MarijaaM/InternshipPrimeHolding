using Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Infrastructure.Configuration;

public class TaskStateHistoryConfiguration : IEntityTypeConfiguration<TaskStateRecord>
{
    public void Configure(EntityTypeBuilder<TaskStateRecord> builder)
    {
        builder.HasKey(x=>x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
         
        
        builder.HasOne(x => x.WorkTask)
            .WithMany(x => x.States)
            .HasForeignKey(x => x.WorkTaskId)
            .OnDelete(DeleteBehavior.Cascade);


    }


}
