using DSRPracticeProject.Context.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSRPracticeProject.Context.Entities
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }
        public virtual AuthorDetail Detail { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
