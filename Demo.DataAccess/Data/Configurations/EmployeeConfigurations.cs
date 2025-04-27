using Demo.DataAccess.Models.EmployeeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Data.Configurations
{
    public class EmployeeConfigurations :BaseConfigurtation<Employee>, IEntityTypeConfiguration<Employee>
    {
        public new void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Name).HasColumnType("varchar(50)");
            builder.Property(e => e.Address).HasColumnType("varchar(150)");
            builder.Property(e => e.Salary).HasColumnType("decimal(10,2)");
            builder.Property(e => e.EmployeeType)
                   .HasConversion((emp) => emp.ToString(),
                   (emp1) => (EmployeeType)Enum.Parse(typeof(EmployeeType), emp1));
            builder.Property(e => e.EmployeeType)
                   .HasConversion((emp) => emp.ToString(),
                   (emp1) => (EmployeeType)Enum.Parse(typeof(EmployeeType), emp1));
            builder.HasOne(e => e.Department)
                     .WithMany(d => d.Employees)
                     .HasForeignKey(e => e.DepartmentId)
                     .OnDelete(DeleteBehavior.SetNull);
            base.Configure(builder);
        }
    }
}
