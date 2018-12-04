using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace phonebook.Models
{
    public class ContactBookContext: DbContext
    {
        public DbSet<ContactBook> ContactBooks { get; set; }

        public ContactBookContext(DbContextOptions<ContactBookContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
