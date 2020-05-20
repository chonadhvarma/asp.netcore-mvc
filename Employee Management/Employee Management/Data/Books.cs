using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Management.Data
{
    public class Books
    {
        public int id { get; set; }
        public string bookname { get; set; }
        public string author { get; set; }
        public string description { get; set; }
        public string Category { get; set; }

        public int TotalPages { get; set; }
        public string Language { get; set; }
    }
}
