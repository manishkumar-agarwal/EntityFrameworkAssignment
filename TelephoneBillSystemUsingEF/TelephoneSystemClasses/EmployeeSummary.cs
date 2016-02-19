namespace TelephoneSystemClasses
{
    public class EmployeeSummary
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int NoOfCustomers { get; set; }
        public decimal TransactionAmount { get; set; }
        public decimal EmployeeBonus { get; set; }

        public override string ToString()
        {
            return (EmployeeId +"\t"+
                    EmployeeName + "\t"+
                    NoOfCustomers + "\t"+
                    TransactionAmount + "\t"+
                    EmployeeBonus);
        }
    }
}
