using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRAM.UI.Models
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class Employee : Attribute
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public long CNP { get; set; }
        public DateTime Bday { get; set; }
        public string IdBatch { get; set; }
        public int IdNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Salary { get; set; }
        public string Gender { get; set; }
        public string CivilStatus { get; set; }
        public string Nationality { get; set; }
        public string Languages { get; set; }
        public string Position { get; set; }
        public DateTime EmploymentDate { get; set; }
        public string Schedule { get; set; }
        public int ManId { get; set; }
        public int DepId { get; set; }
        public int HolId { get; set; }
        public int Status { get; set; }
    }
}
