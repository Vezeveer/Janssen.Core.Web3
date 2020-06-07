using Janssen.Core.Web3.CustomAttributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Janssen.Core.Web3.Models
{
    public class Student
    {
        //        Id property:
        //is required for mapping the Common Language Runtime(CLR) object to the MongoDB collection.
        //is annotated with[BsonId] to designate this property as the document’s primary key.
        //is annotated with[BsonRepresentation(BsonType.ObjectId)] to allow passing the parameter as type string instead of ObjectId.Mongo handles the conversion from string to ObjectId.
        //Other properties in the class are annotated with the[BsonElement] attribute.The attribute’s value represents the property name in the MongoDB collection.

        //[YearRange] attribute is a custom attribute that allows only a valid range for the Year property.If you want to use this attribute, add CustomAttributes folder in the project as a new folder and add the following class there :

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        //[BsonIgnoreIfDefault]
        public string Id { get; set; }

        [BsonElement("EnrollmentStatus")]
        [Display(Name = "Enrollment Status")]
        [Required]
        public string EnrollmentStatus { get; set; }

        [BsonElement("FirstName")]
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [BsonElement("MiddleName")]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [BsonElement("LastName")]
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [BsonElement("DateOfBirth")]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        //[YearRange]
        //public int Year { get; set; }

        [BsonElement("Gender")]
        [Display(Name = "Gender")]
        //[DisplayFormat(DataFormatString = "{0:#,0}")]
        public string Gender { get; set; }

        [BsonElement("PermanentAddress")]
        [Display(Name = "Permanent Address")]
        [Required]
        public string PermanentAddress { get; set; }

        [BsonElement("Religion")]
        [Display(Name = "Religion")]
        [Required]
        public string Religion { get; set; }

        [BsonElement("PlaceOfBirth")]
        [Display(Name = "Place Of Birth")]
        [Required]
        public string PlaceOfBirth { get; set; }

        [BsonElement("Age")]
        [Display(Name = "Age")]
        [Required]
        public int Age { get; set; }


        [BsonElement("DateCreated")]
        [Display(Name = "DateCreated")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [BsonElement("ImageUrlPSA")]
        [Display(Name = "PSA Scanned Image")]
        [DataType(DataType.ImageUrl)]
        [Required]
        public string ImageUrlPSA { get; set; }

        [BsonElement("ImageUrlID")]
        [Display(Name = "Photo ID")]
        [DataType(DataType.ImageUrl)]
        [Required]
        public string ImageUrlID { get; set; }

        [BsonElement("ImageUrlMoral")]
        [Display(Name = "Certificate of Good Moral")]
        [DataType(DataType.ImageUrl)]
        [Required]
        public string ImageUrlMoral { get; set; }
    }
}
