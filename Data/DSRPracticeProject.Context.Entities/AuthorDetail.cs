﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSRPracticeProject.Context.Entities
{
    public class AuthorDetail
    {
        [Key]
        public int Id { get; set; }
        public virtual Author Author { get; set; }

        public string Family { get; set; }
        public string Country { get; set; }
    }
}
