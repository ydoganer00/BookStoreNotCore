using BookStoreNotCore.Common;
using BookStoreNotCore.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreNotCore.BookOperations.GetBookDetail
{
    public class GetBookDetailQuery
    {
        private readonly BookStoreDbContext _dbContext;
        public int Id { get; set; }
        public GetBookDetailQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public GetBookViewModel Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == Id);
            if (book == null)
            {
                throw new InvalidOperationException("Kitap bulunamadı");
            }

            var bookModel = new GetBookViewModel
            {
                Genre = ((GenreEnum)book.GenreId).ToString(),
                PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy"),
                Title = book.Title
            };
            return bookModel;
        }

        public class GetBookViewModel
        {
            public string Title { get; set; }
            public string Genre { get; set; }
            public string PublishDate { get; set; }
        }
    }
}
