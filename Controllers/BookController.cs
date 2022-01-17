using BookStoreNotCore.BookOperations.CreateBook;
using BookStoreNotCore.BookOperations.GetBooks;
using BookStoreNotCore.BookOperations.UpdateBook;
using BookStoreNotCore.DBOperations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreNotCore.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;//readonlyler sadece contructor ıcınden set edılır uygulama ıcınden degıstırılemez

        public BookController(BookStoreDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBookQuery query = new GetBookQuery(_context);
            var result = query.Handle();
            return Ok(result);//IActionResult kullanmak gerek http koduyla beraber göndermek ıcın
            //return _context.Books.OrderBy(x => x.Id).ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //return _context.Books.SingleOrDefault(x => x.Id == Convert.ToInt32(id));
            try
            {
                GetBookByIdQuery getBook = new GetBookByIdQuery(_context);
                getBook.Id = id;
                var result = getBook.Handle();
                return Ok(result);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            //Book book = _context.Books.SingleOrDefault(x => x.Title == newBook.Title);
            //if (book != null)
            //    return BadRequest();
            //_context.Books.Add(newBook);
            //_context.SaveChanges();

            try
            {
                CreateBookCommand createBookCommand = new CreateBookCommand(_context);
                createBookCommand.Model = newBook;
                createBookCommand.Handle();

                return Ok();
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
            
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel upToDateBook)
        {
            //Book book = _context.Books.SingleOrDefault(x => x.Id == id);
            //if (book == null)
            //    return BadRequest();
            //book.GenreId = upToDateBook.GenreId != default ? upToDateBook.GenreId : book.GenreId;
            //book.PublishDate = upToDateBook.PublishDate != default ? upToDateBook.PublishDate : book.PublishDate;
            //book.Title = upToDateBook.Title != default ? upToDateBook.Title : book.Title;
            //_context.SaveChanges();
            //return Ok();

            try
            {
                UpdateBookCommand updateBookCommand = new UpdateBookCommand(_context);
                updateBookCommand.Model = upToDateBook;
                updateBookCommand.Id = id;
                updateBookCommand.Handle();

                return Ok();
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            Book book = _context.Books.SingleOrDefault(x => x.Id == id);
            if (book == null)
                return BadRequest();
            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok();
        }
    }
}
