using TelephoneSystemClasses;
using TelephoneBillingSystemChoices;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;


namespace DBWrapper
{
    public class DBInterface
    {
        public static TelephoneSystemDBContext TelephoneSystemDBContext = new TelephoneSystemDBContext();

        public static List<Customers> GetAllCustomers()
        {
            return TelephoneSystemDBContext.Customers.ToList();
        }

        public static int AddCutomer(int customerMobileNumber, string customerName, string customerEmail, int employeeId, string customerIdentity)
        {
                
                    TelephoneSystemDBContext.Database.Log = Console.WriteLine;
                    Customers customer = DBInterfaceSetup.SetupCustomer(customerMobileNumber, customerName, customerEmail, employeeId, customerIdentity);
                    TelephoneSystemDBContext.Customers.Add(customer);
                    return TelephoneSystemDBContext.SaveChanges();
        }

        public static Customers GetCustomerByID(int customerMobileNumber)
        {
            return TelephoneSystemDBContext.Customers.Where(customer => customer.MobileNumber == customerMobileNumber).SingleOrDefault();
        }

        public static List<Employees> GetAllEmployees()
        {
                return TelephoneSystemDBContext.Employees.ToList();
        }

        public static object GetEmployeeById(int employeeId)
        {
            return TelephoneSystemDBContext.Employees.Where(employee => employee.EmployeeId == employeeId).SingleOrDefault();
        }
    }
}
