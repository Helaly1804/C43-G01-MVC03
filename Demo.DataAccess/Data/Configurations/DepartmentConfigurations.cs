namespace Demo.DataAccess.Data.Configurations
{
    public class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Department");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).UseIdentityColumn(10, 10);
            builder.Property(d => d.Name).HasColumnType("varchar(20)");
            builder.Property(d => d.Code).HasColumnType("varchar(20)");
            builder.Property(d => d.Description).HasColumnType("varchar(100)");
            builder.Property(d => d.CreatedOn).HasDefaultValueSql("getdate()");
            builder.Property(d => d.LastModifiedOn).HasComputedColumnSql("getdate()");
        }
    }
}
