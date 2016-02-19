using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelephoneSystemClasses;

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
    }
}
