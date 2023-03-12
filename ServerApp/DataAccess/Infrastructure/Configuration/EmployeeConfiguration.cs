using Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Infrastructure.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x=>x.FullName).IsRequired();
            builder.Property(x=>x.Email).IsRequired();
            builder.Property(x=>x.MonthlySalary).IsRequired();
            builder.Property(x=>x.PhoneNumber).IsRequired();
        }
    }
}
