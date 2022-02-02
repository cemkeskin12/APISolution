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
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Title).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Content).IsRequired().HasColumnType("NVARCHAR(MAX)");
            builder.Property(x => x.PageCount).IsRequired();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();

            builder.HasOne<Author>(a => a.Author).WithMany(b => b.Books).HasForeignKey(a => a.AuthorId);

            builder.HasData(new Book
            {
                Id = 1,
                Title = "Vestibulum ac diam sit",
                Content = "Vestibulum ac diam sit amet quam vehicula elementum sed sit amet dui. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec rutrum congue leo eget malesuada. Curabitur non nulla sit amet nisl tempus convallis quis ac lectus. Vivamus suscipit tortor eget felis porttitor volutpat. Nulla quis lorem ut libero malesuada feugiat. Cras ultricies ligula sed magna dictum porta. Curabitur aliquet quam id dui posuere blandit. Curabitur arcu erat, accumsan id imperdiet et, porttitor at sem. Mauris blandit aliquet elit, eget tincidunt nibh pulvinar a.",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                AuthorId = 1,
            },
            new Book
            {
                Id = 2,
                Title = "Vestibulum ac diam sit lorem ipsum dolor sit amet",
                Content = "Vestibulum ac diam sit amet quam vehicula elementum  malesuada. Curabitur non nulla sit amet nisl tempus convallis quis ac lectus. Vivamus suscipit tortor eget felis porttitor volutpat. Nulla quis lorem ut libero malesuada feugiat. Cras ultricies ligula sed magna dictum porta. Curabitur aliquet quam id dui posuere blandit. Curabitur arcu erat, accumsan id imperdiet et, porttitor at sem. Mauris blandit aliquet elit.",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                AuthorId = 2,
            });
        }
    }
}
