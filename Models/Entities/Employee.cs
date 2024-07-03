using System.ComponentModel.DataAnnotations;

namespace employeePortal.web.Models.Entities
{
    public class Employee
    {
        [Key]
        public Guid empId { get; set; }
        public string empFullName { get; set; }
        public string empDept { get; set; }
        public decimal salary { get; set; }
    }
}
