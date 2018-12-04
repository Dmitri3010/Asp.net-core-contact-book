using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace phonebook.Models
{
    public class ContactBook
    {
        public int Id { get; set; }
        public string Soname { get; set; }
        public string Name { get; set; }
        public string Midlename { get; set; }
        public string Data { get; set; }
        public string Phone { get; set; }
    }
}
