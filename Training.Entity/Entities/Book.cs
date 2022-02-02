using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Entity.Entities
{
    public class Book : EntityBase
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int PageCount { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }

    }
}
