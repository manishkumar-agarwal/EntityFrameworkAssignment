using System;
using System.Collections.Generic;

namespace TelephoneSystemClasses
{
    public class Employees
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public List<Customers> AssociatedCustomers { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime JoinDate { get; set; }
        public int TShirtSize { get; set; }
    }
}
