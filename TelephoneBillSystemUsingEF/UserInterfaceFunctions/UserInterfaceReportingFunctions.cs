using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TelephoneBillingSystemChoices;
using TelephoneSystemClasses;

namespace UserInterfaceFunctions
{
    public class UserInterfaceReportingFunctions
    {
        public static void UserReportingFunction(TelephoneBillSystemChoices userChoice)
        {
            try
            {
                switch (userChoice)
                {
                    case TelephoneBillSystemChoices.DisplayAllCustomers:
                    case TelephoneBillSystemChoices.DisplayCustomerByID:
                    case TelephoneBillSystemChoices.DisplayCustomerBillingHistory:
                         CustomerRelatedReporting(userChoice);
                        break;
                    case TelephoneBillSystemChoices.DisplayAllEmployees:
                    case TelephoneBillSystemChoices.DisplayEmployeeByID:
                    case TelephoneBillSystemChoices.DisplayCustomersOfEmployee:
                    case TelephoneBillSystemChoices.DisplayTransactionSummaryforEmployees:
                    case TelephoneBillSystemChoices.CalculateEmployeeBonus:
                         EmployeeRelatedReporting(userChoice);
                        break;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Exception Occured" + ex.Message);
            }
        }

        private static void CustomerRelatedReporting(TelephoneBillSystemChoices userChoice)
        {
            
            switch (userChoice)
            {
                case TelephoneBillSystemChoices.DisplayAllCustomers:
                     UserInterfaceToDbAccessFunctions.DisplayAllCustomers();
                    break;
                case TelephoneBillSystemChoices.DisplayCustomerByID:
                     UserInterfaceToDbAccessFunctions.DisplayCustomerByID();
                    break;
                case TelephoneBillSystemChoices.DisplayCustomerBillingHistory:
                    UserInterfaceToDbAccessFunctions.DisplayCustomerBillHistory();
                    break;
            }

        }

        private static void EmployeeRelatedReporting(TelephoneBillSystemChoices userChoice)
        {

            switch (userChoice)
            {
                case TelephoneBillSystemChoices.DisplayAllEmployees:
                     UserInterfaceToDbAccessFunctions.DisplayAllEmployees();
                    break;
                case TelephoneBillSystemChoices.DisplayEmployeeByID:
                     UserInterfaceToDbAccessFunctions.DisplayEmployeeByID();
                    break;
                case TelephoneBillSystemChoices.DisplayCustomersOfEmployee:
                     UserInterfaceToDbAccessFunctions.DisplayEmployeesCustomers();
                    break;
                case TelephoneBillSystemChoices.DisplayTransactionSummaryforEmployees:
                     UserInterfaceToDbAccessFunctions.DisplayTransactionSummaryForEmployees();
                    break;
                case TelephoneBillSystemChoices.CalculateEmployeeBonus:
                     UserInterfaceToDbAccessFunctions.DisplayBonusForEmployee();
                    break;
            }
        }
    }
}
