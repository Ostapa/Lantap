using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Comp229_Project
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string FirstMidName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Province { get; set; }

        public Patient() { }
    }
}