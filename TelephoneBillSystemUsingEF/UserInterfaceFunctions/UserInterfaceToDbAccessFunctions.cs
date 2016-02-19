using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBWrapper;
using TelephoneSystemClasses;

namespace UserInterfaceFunctions
{
    class UserInterfaceToDbAccessFunctions
    {
        internal static void DisplayAllCustomers()
        {
             List<Customers> customerList = DBInterface.GetAllCustomers();
            UserInterfaceDisplayFunctions.DisplayList(customerList);
        }

        internal static void DisplayCustomerByID()
        {
            var customerMobileNumber = UserInterfaceSetupFunctions.GetMobileNumber();
            Customers customer = DBInterface.GetCustomerByID(customerMobileNumber);
            UserInterfaceDisplayFunctions.Display(customer);
        }

        internal static void AddCustomer()
        {
            var customerMobileNumber = UserInterfaceSetupFunctions.GetMobileNumber();
            var customerName = UserInterfaceSetupFunctions.GetCustomerName();
            var customerEmail = UserInterfaceSetupFunctions.GetCustomerEmail();
            var employeeId = UserInterfaceSetupFunctions.GetEmployeeId();
            var customerIdentity = UserInterfaceSetupFunctions.GetCustomerIdentity();
            int insertCount = DBInterface.AddCutomer(customerMobileNumber, customerName, customerEmail,
                employeeId, customerIdentity);
            if(insertCount > 0)
            {
                Console.WriteLine("Inserted Customer Successfully");
            }
        }

        internal static void RecordBillPayment()
        {
            var customerMobileNumber = UserInterfaceSetupFunctions.GetMobileNumber();
            var billPaymentMode = UserInterfaceSetupFunctions.GetBillPaymemtMode();
            var billAmount = UserInterfaceSetupFunctions.GetBillAmount();
           /* int insertCount = DBInterface.RecordBillPaymentForCustomer(customerMobileNumber, billPaymentMode, billAmount);
            if (insertCount > 0)
            {
                Console.WriteLine("Inserted Customer Bill Successfully");
            }*/
        }

        internal static void UpdateCustomer()
        {
            var customerMobileNumber = UserInterfaceSetupFunctions.GetMobileNumber();
            var customerEmail = UserInterfaceSetupFunctions.GetCustomerEmail();
           /* int updateCount = DBInterface.UpdateCustomer(customerMobileNumber, customerEmail);

            if(updateCount == 0)
            {
                Console.WriteLine("Update Customer Not Successful");
            }
            else
            {
                Console.WriteLine("Updated Customer successfully");
            }*/
        }

        internal static SqlDataReader DisplayCustomerBillHistory()
        {
            var customerMobileNumber = UserInterfaceSetupFunctions.GetMobileNumber();
            return null;
            // return DBInterface.GetCustomerBillHistory(customerMobileNumber);
        }

        internal static void DisplayAllEmployees()
        {
            List<Employees> employeeList = DBInterface.GetAllEmployees();
            UserInterfaceDisplayFunctions.DisplayList(employeeList);

        }

        internal static void DisplayEmployeeByID()
        {
            var employeeId = UserInterfaceSetupFunctions.GetEmployeeId();
            var employee = DBInterface.GetEmployeeById(employeeId);
            UserInterfaceDisplayFunctions.Display(employee);
        }

        internal static SqlDataReader DisplayEmployeesCustomers()
        {
            var employeeId = UserInterfaceSetupFunctions.GetEmployeeId();
            return null;
            //return DBInterface.GetCutomersForEmployee(employeeId);
        }

        internal static SqlDataReader DisplayBonusForEmployee()
        {
            var employeeId = UserInterfaceSetupFunctions.GetEmployeeId();
            return null;
            //return DBInterface.GetBonusForEmployee(employeeId);
        }

        internal static SqlDataReader DisplayTransactionSummaryForEmployees()
        {
            return null;
            //return DBInterface.GetSummaryForEmployees();
        }
    }
}
