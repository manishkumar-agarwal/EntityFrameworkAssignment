using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace UserInterfaceFunctions
{
    class UserInterfaceDisplayFunctions
    {

        internal static void DisplayList<T>(List<T> displayList)
        {
            if (displayList.Count == 0)
            {
                Console.WriteLine("There are no details to Display");
                return;
            }

            foreach (var displayItem in displayList)
            {
                Console.WriteLine(displayItem.ToString());
            }
        }

        internal static void Display<T>(T displayItem)
        {
            if(displayItem == null)
            {
                Console.WriteLine("Details not found!! Please try with a different Criteria");
                return;
            }
            Console.WriteLine(displayItem.ToString());
        }

        internal static void DisplayQueryResult(SqlDataReader queryResult)
        {
            if (!queryResult.HasRows)
            {
                Console.WriteLine("No data found. Please retry with a different Criteria");
                queryResult.Close();
                return;
            }

            DisplayQueryResultHeader(queryResult);

            while (queryResult.Read())
            {
                for (int i = 0; i < queryResult.FieldCount; i++)
                {
                    Console.Write("\t{0}\t", queryResult[i]);
                }
                Console.WriteLine();

            }
            queryResult.Close();
        }

        private static void DisplayQueryResultHeader(SqlDataReader queryResult)
        {
            for (int i = 0; i < queryResult.FieldCount; i++)
            {
                Console.Write("{0}\t", queryResult.GetName(i));
            }
            Console.WriteLine();
        }

        internal static void DisplayEmployeeBonus(List<SqlDataReader> employeeBonus)
        {
            foreach(var employee in employeeBonus)
            {
                DisplayQueryResult(employee);
            }
        }
    }

}

