

using Demo.DataAccess.Models.DepartmentModel;

namespace Demo.DataAccess.Data.Configurations
{
    public class DepartmentConfigurations :BaseConfigurtation<Department>, IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Department");           
            builder.Property(d => d.Name).HasColumnType("varchar(50)");
            builder.Property(d => d.Code).HasColumnType("varchar(60)");
            builder.Property(d => d.Description).HasColumnType("varchar(100)");
            base.Configure(builder);
        }
    }
}
