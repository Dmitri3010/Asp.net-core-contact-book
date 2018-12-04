using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using phonebook.Models;

namespace phonebook.Controllers
{
    public class HomeController : Controller
    {
        ContactBookContext db;
        public HomeController(ContactBookContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View(db.ContactBooks.ToList());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                ContactBook contactBook = await db.ContactBooks.FirstOrDefaultAsync(p => p.Id == id);
                if (contactBook != null)
                    return View(contactBook);
            }
            return NotFound();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                ContactBook contactBook = await db.ContactBooks.FirstOrDefaultAsync(p => p.Id == id);
                if (contactBook != null)
                    return View(contactBook);
            }
            return NotFound();

       }

        public IActionResult ContactAdd()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ContactAdd(ContactBook contactBook)
        {
            db.ContactBooks.Add(contactBook);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                ContactBook contactBook = await db.ContactBooks.FirstOrDefaultAsync(p => p.Id == id);
                if (contactBook != null)
                    return View(contactBook);
            }
            return NotFound();
        }



        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                ContactBook contactBook = await db.ContactBooks.FirstOrDefaultAsync(p => p.Id == id);
                if (contactBook != null)
                {
                    db.ContactBooks.Remove(contactBook);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ContactBook contactBook)
        {
            db.ContactBooks.Update(contactBook);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
