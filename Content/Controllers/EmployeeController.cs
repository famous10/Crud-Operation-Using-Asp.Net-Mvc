using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebMvcCrudService.Models;

namespace WebMvcCrudService.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<mvcEmployeemodel> empList;
            HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Employee").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<mvcEmployeemodel>>().Result;
            return View(empList);
        }
        public ActionResult AssOrEdit( int id = 0)
        {
            if(id == 0)
            return View(new mvcEmployeemodel());
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Employee/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcEmployeemodel>().Result);
            }
        }
        [HttpPost]
        public ActionResult AssOrEdit(mvcEmployeemodel emp)
        {
            if (emp.EmployeeID == 0)
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PostAsJsonAsync("Employee", emp).Result;
                TempData["SuccessMessage"] = "Saved Sucessfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PutAsJsonAsync("Employee/"+emp.EmployeeID, emp).Result;
                TempData["SuccessMessage"] = "Updated Sucessfully";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.webapiclient.DeleteAsync("Employee/"+id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Sucessfully";
            return RedirectToAction("Index");
        }
    }
}
