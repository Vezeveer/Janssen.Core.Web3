using Janssen.Core.Web3.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Janssen.Core.Web3.Services
{
    public class StudentService
    {
        private readonly IMongoCollection<Student> students;

        public StudentService(IStudentDatabaseSettings config)
        {
            MongoClient client = new MongoClient(config.ConnectionString);
            IMongoDatabase database = client.GetDatabase(config.DatabaseName);
            students = database.GetCollection<Student>("Students");
        }

        public List<Student> Get()
        {
            return students.Find(student => true).ToList();
        }

        public Student Get(string id)
        {
            return students.Find(student => student.Id == id).FirstOrDefault();
        }

        public Student Create(Student student)
        {
            students.InsertOne(student);
            return student;
        }

        public void Update(string id, Student studentIn)
        {
            students.ReplaceOne(student => student.Id == id, studentIn);
        }

        public void Remove(Student studentIn)
        {
            students.DeleteOne(student => student.Id == studentIn.Id);
        }

        public void Remove(string id)
        {
            students.DeleteOne(student => student.Id == id);
        }
    }
}
