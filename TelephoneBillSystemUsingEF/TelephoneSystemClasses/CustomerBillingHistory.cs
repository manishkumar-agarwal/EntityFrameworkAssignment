using System;
using System.ComponentModel.DataAnnotations;
using TelephoneBillingSystemChoices;

namespace TelephoneSystemClasses
{
    public class CustomerBillingHistory
    {
        [Key]
        public int BillPaymentId { get; set; }
        public DateTime BillPaidDate { get; set; } = DateTime.Now;
        [Required]
        public Customers Customer { get; set; }
        public int CustomerMobileNumber { get; set; }
        public BillPaymentMode BillPaymentMode { get; set; }
        public decimal BillAmount { get; set; }
    }
}
