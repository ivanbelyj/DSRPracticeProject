using DSRPracticeProject.Context.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSRPracticeProject.Context.Entities
{
    public class Category : BaseEntity
    {
        public string Title { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
