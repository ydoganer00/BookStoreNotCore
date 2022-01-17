using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreNotCore.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                context.Books.AddRange(new Book()
                {
                    //Id = 1,
                    Title = "kitap 1",
                    GenreId = 1,
                    PublishDate = DateTime.Now
                },
                new Book()
                {
                    //Id = 2,
                    Title = "kitap 2",
                    GenreId = 2,
                    PublishDate = new DateTime(2021, 1, 1)
                },
                new Book()
                {
                    //Id = 3,
                    Title = "kitap 3",
                    GenreId = 2,
                    PublishDate = new DateTime(2021, 1, 15)
                }
            );
                context.SaveChanges();
            }
        }
    }
}
