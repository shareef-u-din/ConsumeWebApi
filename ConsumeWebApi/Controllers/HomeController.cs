using ConsumeWebApi.Helper;
using ConsumeWebApi.Models;
using ModelClasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ConsumeWebApi.Controllers
{

    public class HomeController : Controller
    {
        public HomeController()
        {

        }
        // GET: values
        public ActionResult Index(string Id, string SearchBy="All")
        {
            if (SearchBy != "All" && !String.IsNullOrEmpty(Id))
            {
                return GetData(SearchBy, Id);
            }
            IEnumerable<EmployeeModel> employeeModels = null;
            employeeModels = DataHelper.GetDataFromApi<EmployeeModel>("http://localhost:99/webAPI/api/", "values");
            return View(employeeModels);
        }
        [HttpGet]
        public ActionResult Create()
        {
            EmployeeDetails employeeDetails = EmployeeDetails.GetInstance();
            if (employeeDetails.Departments == null || employeeDetails.Locations == null)
            {
                return View();
            }
            return View(employeeDetails);
        }
        [HttpPost]
        public ActionResult Create(EmployeeDetails employeeDetails)
        {
            EmployeeModel employeeModel = new EmployeeModel();
            employeeModel.Name = employeeDetails.Name;
            employeeModel.DepartmentId = employeeDetails.DepartmentId;
            employeeModel.LocationId = employeeDetails.LocationId;
            employeeModel.Salary = employeeDetails.Salary;
            bool status = DataHelper.Add<EmployeeModel>(employeeModel, "http://localhost:99/webAPI/api/", "values");
            if (status)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ViewResult GetData(string SearchBy, string Id)
        {
            string actionWithId = null;

            if (SearchBy == "DepartmentId")
            {
                actionWithId = @"values/GetByDepartmentId/" + Id;
            }
            else
            {
                actionWithId = @"values/GetByLocationId/" + Id;
            }

            IEnumerable<EmployeeModel> employeeModels = null;
            employeeModels = DataHelper.GetDataFromApi<EmployeeModel>("http://localhost:99/webAPI/api/", actionWithId);
            return View(employeeModels);
        }
    }
}