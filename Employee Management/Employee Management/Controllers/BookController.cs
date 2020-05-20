using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee_Management.Data;
using Employee_Management.Models;
using Employee_Management.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Management.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository br;
        public BookController(BookRepository brr)
        {
            br = brr;
        }
        public async Task<ViewResult> GetAllBooks()
        {
            var data = await br.GetAllBooks();
            return View(data);
        }
        public async Task<ViewResult> GetBook(int id, string name)
        {
            var data = await br.GetBookbyId(id);
            return View(data);
        }
        public List<BookModel> SearchBook(string bookname, string author)
        {
            return br.SearchBook(bookname, author);
        }
        public ViewResult AddNewBook(bool issuccess=false,int bookid=0)
        {
            ViewBag.Issuccess = issuccess;
            ViewBag.BookId = bookid;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bm)
        {
            if(ModelState.IsValid)
            {
                int id = await br.AddNewBook(bm);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { issuccess = true, bookid = id });
                }
            }
         
            return View();
        }
    }
}