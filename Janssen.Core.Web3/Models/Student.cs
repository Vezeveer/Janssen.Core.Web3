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

        [BsonElement("DateCreated")]
        [Display(Name = "DateCreated")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime DateCreated { get; set; } = DateTime.Now;

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

        [BsonElement("ImageUrlReportCard")]
        [Display(Name = "School Report Card")]
        [DataType(DataType.ImageUrl)]
        [Required]
        public string ImageUrlReportCard { get; set; }

        [BsonElement("Sacraments")]
        [Display(Name = "Sacraments Received")]
        [Required]
        public string Sacraments { get; set; }

        [BsonElement("Nationality")]
        [Display(Name = "Nationality")]
        [Required]
        public string Nationality { get; set; }

        [BsonElement("StayingWith")]
        [Display(Name = "Presently Staying With")]
        [Required]
        public string StayingWith { get; set; }

        [BsonElement("Phone")]
        [Display(Name = "Phone Number")]
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Phone { get; set; }

        [BsonElement("PreviousSchool")]
        [Display(Name = "Last School Attended")]
        [Required]
        public string PreviousSchool { get; set; }

        [BsonElement("PrevSchAddress")]
        [Display(Name = "Address of Last School Attended")]
        [Required]
        public string PrevSchAddress { get; set; }

        [BsonElement("Transport")]
        [Display(Name = "Mode of Transportation to and from")]
        [Required]
        public string Transport { get; set; }

        [BsonElement("Email")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }

        [BsonElement("HowTheyFindUs")]
        [Display(Name = "How did you hear from us?")]
        [Required]
        public string HowTheyFindUs { get; set; }

        [BsonElement("FatherName")]
        [Display(Name = "Father's Name")]
        [Required]
        public string FatherName { get; set; }

        [BsonElement("FatherAge")]
        [Display(Name = "Father's Age")]
        [Required]
        public int FatherAge { get; set; }

        [BsonElement("FatherOccupation")]
        [Display(Name = "Father's Occupation")]
        [Required]
        public string FatherOccupation { get; set; }

        [BsonElement("FatherEducationLevel")]
        [Display(Name = "Father's Education Level")]
        [Required]
        public string FatherEducationLevel { get; set; }

        [BsonElement("FatherPhone")]
        [Display(Name = "Father's Phone")]
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string FatherPhone { get; set; }

        [BsonElement("MotherName")]
        [Display(Name = "Mother's Name")]
        [Required]
        public string MotherName { get; set; }

        [BsonElement("MotherAge")]
        [Display(Name = "Mother's Age")]
        [Required]
        public int MotherAge { get; set; }

        [BsonElement("MotherOccupation")]
        [Display(Name = "Mother's Occupation")]
        [Required]
        public string MotherOccupation { get; set; }

        [BsonElement("MotherEducationLevel")]
        [Display(Name = "Mother's Education Level")]
        [Required]
        public string MotherEducationLevel { get; set; }

        [BsonElement("MotherPhone")]
        [Display(Name = "Mother's Phone")]
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string MotherPhone { get; set; }

        [BsonElement("OtherFamilyMemberName")]
        [Display(Name = "Other Family Member's Name")]
        public string OtherFamilyMemberName { get; set; }


        [BsonElement("OtherFamilyMemberOccupation")]
        [Display(Name = "Other Family Member's Occupation")]
        public string OtherFamilyMemberOccupation { get; set; }

        [BsonElement("OtherFamilyMemberEducationLevel")]
        [Display(Name = "Other Family Member's Education Level")]
        public string OtherFamilyMemberEducationLevel { get; set; }


        [BsonElement("OtherFamilyMemberAge")]
        [Display(Name = "Family Member's Age")]
        public string OtherMemberAge { get; set; }

        [BsonElement("OtherFamilyMemberPhone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        [Display(Name = "Other Family Member's Phone")]
        public string OtherFamilyMemberPhone { get; set; }


    }
}
