using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Janssen.Core.Web3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Janssen.Core.Web3.Pages.Admin
{
    public class EditModel : PageModel
    {
        private readonly IMongoCollection<Student> students;

        public EditModel(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("SajctiDB"));
            IMongoDatabase database = client.GetDatabase("StudentsDB");
            students = database.GetCollection<Student>("Students");
        }

        [BindProperty]
        public Student Student { get; set; }

        public void OnGet(string id)
        {
            Student =  students.Find(student => student.Id == id).FirstOrDefault();
        }

        public ActionResult OnPost(string id)
        {
            students.ReplaceOne(student => student.Id == id, Student);
            return RedirectToPage("/admin/index");
        }
    }
}