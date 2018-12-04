using phonebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace phonebook.Services
{
    public static class DataInit
    {
        public static void Initialize(ContactBookContext context)
        {
            if (!context.ContactBooks.Any())
            {
                context.ContactBooks.AddRange(
                   new ContactBook
                   {
                       Name ="Иван",
                       Soname = "Иванов",
                       Midlename="Алексеевич",
                       Data="30.10.1998",
                       Phone="8-800-555-35-35"
                   },
                   new ContactBook
                   {
                       Name = "Аркаша",
                       Soname = "Ивлеев",
                       Midlename = "Алексеевич",
                       Data = "31.11.1988",
                       Phone = "8-880-455-35-35"
                   },
                    new ContactBook
                    {
                        Name = "Кирилл",
                        Soname = "Купи",
                        Midlename = "Энергетос",
                        Data = "31.11.1988",
                        Phone = "8-880-455-35-35"
                    }

                );
                context.SaveChanges();
            }
        }
    }
}
