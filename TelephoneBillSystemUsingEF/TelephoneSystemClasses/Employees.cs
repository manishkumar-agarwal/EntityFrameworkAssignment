using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TelephoneSystemClasses
{
    public class Employees
    {
        public Employees()
        {
            AssociatedCustomers = new List<Customers>();
        }

        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public List<Customers> AssociatedCustomers { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime JoinDate { get; set; }
        public int TShirtSize { get; set; }

        public override string ToString()
        {
            return (EmployeeId + "\t" +
                    EmployeeName + "\t" +
                    DateOfBirth + "\t" +
                    JoinDate + "\t" +
                    TShirtSize);
        }
    }
}
