using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Book_Store.Data
{
    public class DataContext:DbContext
    {

        public DataContext (DbContextOptions<DataContext>options):base(options){}
        public DbSet<Book> Books {get; set;} 
        public DbSet<BookCategory> Categories {get;set;}
    }
}