﻿using BookStoreNotCore.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreNotCore.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public int Id { get; set; }
        public DeleteBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            Book book = _dbContext.Books.SingleOrDefault(x => x.Id == Id);
            if (book == null)
                throw new InvalidOperationException("Silinecek Kitap Bulunamadı.");
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }
    }
}
