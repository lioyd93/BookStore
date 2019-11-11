﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore2.Models
{
    public class Book
    {
        public int id { get; set; }
        public string  Title { get; set; }
        public string  Description { get; set; }

        public Author Author { get; set; }
    }
}
