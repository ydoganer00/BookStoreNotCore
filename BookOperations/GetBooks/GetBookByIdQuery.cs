using BookStoreNotCore.Common;
using BookStoreNotCore.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreNotCore.BookOperations.GetBooks
{
    public class GetBookByIdQuery
    {
        private readonly BookStoreDbContext _dbContext;
        public int Id { get; set; }
        public GetBookByIdQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public GetBookModel Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == Id);
            if(book == null)
            {
                throw new Exception("Kitap bulunamadı");
            }

            var bookModel = new GetBookModel
            {
                Genre = ((GenreEnum)book.GenreId).ToString(),
                PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy"),
                Title = book.Title
            };
            return bookModel;
        }
    }

    public class GetBookModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string PublishDate { get; set; }
    }
}
