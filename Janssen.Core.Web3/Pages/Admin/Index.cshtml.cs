using System.Collections.Generic;
using System.Threading.Tasks;
using Janssen.Core.Web3.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Janssen.Core.Web3.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly IMongoCollection<Student> students;

        public IndexModel(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("SajctiDB"));
            IMongoDatabase database = client.GetDatabase("StudentsDB");
            students = database.GetCollection<Student>("Students");
        }

        [BindProperty]
        public List<Student> Student { get; set; }

        public void OnGet()
        {
            Student = students.Find(student => true).ToList();
        }

        public async Task<IActionResult> OnPost()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/login/logout");
        }


        public ActionResult OnGetEdit(string id)
        {
            return RedirectToPage("/admin/edit?id="+id);
        }

        public ActionResult OnGetDelete(string id)
        {
            students.DeleteOne(student => student.Id == id);
            return RedirectToPage("index");
        }

    }
}