using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Management.Models
{
    public class BookModel
    {
        [DataType(DataType.Date)]
        public string myfield { get; set; }
        public int id { get; set; }
        [Required(ErrorMessage ="please enter the bookname")]
        public string bookname { get; set; }
        [Required (ErrorMessage ="please enter the author name")]
        public string author { get; set; }
        public string description { get; set; }
        public string Category { get; set; }

        [Required(ErrorMessage ="please enter the total pages")]
        [Display(Name ="Total Pages of book")]
        public int? TotalPages { get; set; }
        public string Language { get; set; }
    }
}
