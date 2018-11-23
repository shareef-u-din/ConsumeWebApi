using ConsumeWebApi.Helper;
using ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumeWebApi.Models
{
    public class EmployeeDetails
    {
        public EmployeeDetails()
        {

        }

        public string Name { get; set; }
        public int Salary { get; set; }
        public IEnumerable<DepartmentModel> Departments
        {
            get
            {
                return DataHelper.GetDataFromApi<DepartmentModel>("http://localhost:99/webAPI/api/", "Departments");
            }
        }
        public IEnumerable<LocationModel> Locations
        {
            get
            {
                return DataHelper.GetDataFromApi<LocationModel>("http://localhost:99/webAPI/api/", "Locations");
            }
        }
        public static EmployeeDetails GetInstance()
        {
            return new EmployeeDetails();
        }
        public int DepartmentId { get; set; }
        public int LocationId { get; set; }
    }
}