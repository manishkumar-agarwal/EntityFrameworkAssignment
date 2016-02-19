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

        public static Employees GetEmployeeById(int employeeId)
        {
            return TelephoneSystemDBContext.Employees.Where(employee => employee.EmployeeId == employeeId).SingleOrDefault();
        }

        public static int UpdateCustomer(int customerMobileNumber, string customerEmail)
        {
            Customers customer = GetCustomerByID(customerMobileNumber);

            if(customer == null)
            {
                Console.WriteLine("Customer with mobile number "+customerMobileNumber + " does not exists" );
                return 0;
            }

            customer.EmailAddress = customerEmail;
            var updateCount = TelephoneSystemDBContext.SaveChanges();

            return updateCount;

        }

        public static int RecordBillPaymentForCustomer(int customerMobileNumber, string billPaymentMode, decimal billAmount)
        {
            //TelephoneSystemDBContext.Database.Log = Console.WriteLine;
            if (GetCustomerByID(customerMobileNumber) == null)
            {
                Console.WriteLine("Customer with mobile number " + customerMobileNumber + " does not exists");
                return 0;
            }
            CustomerBillingHistory customerBill = DBInterfaceSetup.SetupCustomer(customerMobileNumber, billPaymentMode, billAmount);
            TelephoneSystemDBContext.CustomerBills.Add(customerBill);
            return TelephoneSystemDBContext.SaveChanges();
        }

        public static List<CustomerBillingHistory> GetCustomerBillHistory(int customerMobileNumber)
        {
            //TelephoneSystemDBContext.Database.Log = Console.WriteLine;
            if (GetCustomerByID(customerMobileNumber) == null)
            {
                Console.WriteLine("Customer with mobile number " + customerMobileNumber + " does not exists");
                return new List<CustomerBillingHistory>();
            }
            return TelephoneSystemDBContext.CustomerBills.Where(customerBill => customerBill.CustomerMobileNumber == customerMobileNumber).ToList();

        }

        public static List<Customers> GetCutomersForEmployee(int employeeId)
        {
            if(GetEmployeeById(employeeId) == null)
            {
                Console.WriteLine("Employee does not exists");
                return new List<Customers>();
            }

            return TelephoneSystemDBContext.Customers.Where(customer => customer.EmployeeId == employeeId).ToList();
        }

        public static List<SqlDataReader> GetBonusForEmployee(int employeeId)
        {
            /*
            //return TelephoneSystemDBContext.Database.ExecuteSqlCommand("EXEC [dbo].[uspGetBonusForEmployee] {0}", employeeId);

            */

            return TelephoneSystemDBContext.Database.
                SqlQuery<SqlDataReader>("EXEC [dbo].[uspGetBonusForEmployee] {0}", employeeId).ToList();
            //return null;

        }

    }
}
