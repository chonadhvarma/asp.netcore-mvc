using Employee_Management.Data;
using Employee_Management.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Employee_Management.Repository
{
    public class BookRepository
    {
        private readonly BookstoreContext _context;
        public BookRepository(BookstoreContext context)
        {
            _context = context;
        }
        public async Task<int> AddNewBook(BookModel model)
        {
            var newbook = new Books()
            {
                bookname = model.bookname,
                 author = model.author,
                 description=model.description,
                 TotalPages=model.TotalPages.HasValue?model.TotalPages.Value:0
            };
            await _context.Books.AddAsync(newbook);
           await  _context.SaveChangesAsync();
            return newbook.id;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
           
           var allbooks= await _context.Books.ToListAsync();// retun all books via books 
            var books = new List<BookModel>();
            if (allbooks?.Any()==true)                 // but return type is book model
                                                       //  we need to convert books to bookmodel
            {
                foreach (var book in allbooks)
                {
                    books.Add(new BookModel()
                    {
                        bookname = book.bookname,
                        author = book.author,
                        description = book.description,
                        Language = book.Language,
                        Category = book.Category,
                        id = book.id,
                        TotalPages=book.TotalPages
                    }) ;
                }
            }
            return books;
        }
        public async Task<BookModel> GetBookbyId(int id)
        {
            var book =await _context.Books.FindAsync(id);
            if(book!=null)
            {
                var bookdetails = new BookModel()
                {
                    bookname = book.bookname,
                    author = book.author,
                    description = book.description,
                    Language = book.Language,
                    Category = book.Category,
                    id = book.id,
                    TotalPages = book.TotalPages
                };
                return bookdetails;
            }
            return null;
        }
        public List<BookModel> SearchBook(string title, string author)
        {
            return DataSource().Where(x => x.bookname.Contains(title) || x.author.Contains(author)).ToList();
        }
        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){id=1,bookname="MVC",author="Varma",description="This is description of MVC",Category="Framework",TotalPages=135,Language="English"},
                new BookModel(){id=2,bookname="ANGULAR",author="Satish",description="This is description of ANGULAR",Category="Front end Framework",TotalPages=145,Language="English"},
                new BookModel(){id=3,bookname=".NET core",author="Chonadh",description="This is description of .NET Core",Category="Server Side Framework",TotalPages=235,Language="English"},
                new BookModel(){id=4,bookname="ML.NET",author="Palepu",description="This is description of ML.NET",Category=" ML Framework",TotalPages=215,Language="English"},
                new BookModel(){id=11,bookname="AI",author="SatishVarma",description="This is description of AI",Category="AI Framework",TotalPages=105,Language="English"}
            };
        }
    }
}
