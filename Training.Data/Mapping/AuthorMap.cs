using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Entity.Entities;

namespace Training.Data.Mapping
{
    public class AuthorMap : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();
            builder.Property(x => x.Age).IsRequired();

            builder.HasData(new Author
            {
                Id = 1,
                FirstName = "Cem",
                LastName = "Keskin",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Age = 22,
            },
            new Author
            {
                Id = 2,
                FirstName = "Training",
                LastName = "Two",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Age = 33,
            }
            );



        }
    }
}
