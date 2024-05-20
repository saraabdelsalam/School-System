using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using School_System.Data.Entities;

namespace School_System.Infrastructure.Configurations
{
    public class Ins_SubjectConfigurations : IEntityTypeConfiguration<Instructor_Subjects>
    {
        public void Configure(EntityTypeBuilder<Instructor_Subjects> builder)
        {
            builder
                .HasKey(x => new { x.SubjectId, x.InstructorId });


            builder.HasOne(ds => ds.instructor)
                     .WithMany(d => d.Ins_Subjects)
                     .HasForeignKey(ds => ds.InstructorId);

            builder.HasOne(ds => ds.Subjects)
                 .WithMany(d => d.Ins_Subjects)
                 .HasForeignKey(ds => ds.SubjectId);

        }
    }
}
