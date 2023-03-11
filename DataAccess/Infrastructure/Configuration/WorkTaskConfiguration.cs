using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace DataAccess.Infrastructure.Configuration;

public class WorkTaskConfiguration:IEntityTypeConfiguration<WorkTask>
{
    public void Configure(EntityTypeBuilder<WorkTask> builder)
    {
        builder.HasKey(x=>x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x=>x.Title).IsRequired();
        builder.Property(x=>x.Description).IsRequired(); 
        
        builder.HasOne(x => x.Assignee)
            .WithMany(x => x.WorkTasks)
            .HasForeignKey(x => x.AssigneeId)
            .OnDelete(DeleteBehavior.SetNull);


    }


}
