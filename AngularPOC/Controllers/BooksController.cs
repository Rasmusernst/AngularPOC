using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AngularPOC.Models;

namespace AngularPOC.Controllers
{
    public class BooksController : ApiController
    {
        private ApplicationDbContext _context;

        public BooksController()
        {
            _context = new ApplicationDbContext();
        }

        //GET API/Books
        [HttpGet]
       public List<Books> GetBooks()
        {
            return _context.Books.ToList();
        }

        //Get API/Books/1
        [HttpGet]
        public Books GetBooks(int id)
        {
            var book = _context.Books.SingleOrDefault(c => c.Id == id);
            if(book == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return book;
        }

       //POST /Api/Books
       [HttpPost]
       public Books CreateBook(Books book)
        {
            if(!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            _context.Books.Add(book);
            _context.SaveChanges();

            return book;
        }


        //PUT API/Books/1 
        [HttpPut]
        public void UpdateBook(int id, Books book)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var bookInDB = _context.Books.SingleOrDefault(c => c.Id == id);

            if (bookInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            bookInDB.BookName = book.BookName;
            _context.SaveChanges();
        }


        //Delete API/Books/1 
        [HttpDelete]
        public void DeleteBook(int id)
        {
            var bookInDB = _context.Books.SingleOrDefault(c => c.Id == id);

            if (bookInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Books.Remove(bookInDB);
            _context.SaveChanges();
        }


    }
}
