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
    public class DetailsModel : PageModel
    {
        private readonly IMongoCollection<Student> students;

        public DetailsModel(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("SajctiDB"));
            IMongoDatabase database = client.GetDatabase("StudentsDB");
            students = database.GetCollection<Student>("Students");


        }

        //[BindProperty]
        //public List<Student> Students { get; set; }

        [BindProperty]
        public Student Student { get; set; }

        //public string StudentToView { get; set; }

        public void OnGet(string id)
        {
            //StudentToView = id;
            //Students = students.Find(student => true).ToList();
            try
            {
                Student = students.Find(student => student.Id == id).ToList()[0];
            }
            catch
            {
                RedirectToPage("/index");
            }
        }

    }
}