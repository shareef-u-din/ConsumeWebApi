using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClasses
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public int DepartmentId { get; set; }
        public int LocationId { get; set; }

        public DepartmentModel Department { get; set; }
        public LocationModel Location { get; set; }
    }
}
