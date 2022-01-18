using BookStoreNotCore.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreNotCore.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        public UpdateBookViewModel Model { get; set; }
        public int Id { get; set; }
        private readonly BookStoreDbContext _dbContext;
        public UpdateBookCommand(BookStoreDbContext context)
        {
            _dbContext = context;
        }

        public void Handle()
        {
            Book book = _dbContext.Books.SingleOrDefault(x => x.Id == Id);
            if (book == null)
                throw new InvalidOperationException("Güncellenecek Kitap bulunamadı");
            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            book.PublishDate = Model.PublishDate != default ? Model.PublishDate : book.PublishDate;
            book.Title = Model.Title != default ? Model.Title : book.Title;
            _dbContext.SaveChanges();
        }
    }

    public class UpdateBookViewModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
