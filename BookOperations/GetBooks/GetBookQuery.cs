using BookStoreNotCore.Common;
using BookStoreNotCore.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreNotCore.BookOperations.GetBooks
{
    public class GetBookQuery
    {
        private readonly BookStoreDbContext _dbContext;
        public GetBookQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<BooksViewModel> Handle()
        {
            var bookList = _dbContext.Books.OrderBy(x => x.Id).ToList();
            List<BooksViewModel> vm = new List<BooksViewModel>();

            foreach (var book in bookList)
            {
                vm.Add(new BooksViewModel { 
                    Title = book.Title,
                    Genre = ((GenreEnum)book.GenreId).ToString(),
                    PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy"),
                });
            }
            return vm;
        }
    }

    public class BooksViewModel
    {
        public string Title { get; set; }

        public string PublishDate { get; set; }

        public string Genre { get; set; } // viewmodelde ne kadar az data o kadar hız
    }
}
