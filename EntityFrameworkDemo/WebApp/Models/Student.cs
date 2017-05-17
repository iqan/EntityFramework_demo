using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class Student
    {
        public Student()
        {
        }

        public int Student_ID { get; set; }
        public string StudentName { get; set; }
        
        //[Index( "IX_REG", IsClustered=true, IsUnique=true )]
        public int RegistrationNumber { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public System.DateTime AddmissionDate { get; set; }

    }
}
