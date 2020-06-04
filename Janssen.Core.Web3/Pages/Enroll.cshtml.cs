using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Janssen.Core.Web3.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Janssen.Core.Web3.Pages
{
    public class EnrollModel : PageModel
    {
        private readonly IMongoCollection<Student> students;

        public EnrollModel(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("SajctiDB"));
            IMongoDatabase database = client.GetDatabase("StudentsDB");
            students = database.GetCollection<Student>("Students");
        }

        [BindProperty]
        public Student Student { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            var student = Student;

            //if(!ModelState.IsValid)
            //{
            students.InsertOne(student);
            //    return Page();
            //}

            return RedirectToPage("/Enroll");
        }

    }
}