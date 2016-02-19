using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TelephoneBillingSystemChoices;

namespace TelephoneSystemClasses
{
    public class Customers
    {
        public Customers()
        {
            CustomerBills = new List<CustomerBillingHistory>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MobileNumber { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public Employees Employee { get; set; }
        public int EmployeeId { get; set; }
        public string CustomersIdentity { get; set; }
        public List<CustomerBillingHistory> CustomerBills { get; set; }

        public override string ToString()
        {
            return (MobileNumber + "\t" +
                     Name + "\t" +
                     EmailAddress + "\t" +
                     EmployeeId + "\t" +
                     CustomersIdentity + "\t");
        }

    }
}
