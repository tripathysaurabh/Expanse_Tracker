using expanseApigateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace expanseApigateway.Controllers
{
                                               
    public class Total_expansemvcController : Controller
    {
        HttpClient client = new HttpClient();
    
        // GET: Total_expansemvc
        public ActionResult limitIndex()
        {
            List<expanse_limit> emp_list = new List<expanse_limit>();
            client.BaseAddress = new Uri("https://localhost:44385/api/TotalExpanse");
            var response = client.GetAsync("Total_expanse");
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<expanse_limit>>();
                display.Wait();
                emp_list = display.Result;

            }
            return View(emp_list);
      

        }
       

        public ActionResult Edit(int id)
        {
            expanse_limit e = null;
            client.BaseAddress = new Uri("https://localhost:44385/api/TotalExpanse");
            var response = client.GetAsync("Total_expanse?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<expanse_limit>();
                display.Wait();
                e = display.Result;
            }
            return View(e);
        }
        [System.Web.Mvc.HttpPost]
        public ActionResult Edit(expanse_limit e)
        {
            client.BaseAddress = new Uri("https://localhost:44385/api/TotalExpanse");
            var response = client.PutAsJsonAsync<expanse_limit>("Total_expanse", e);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("limiIndex");
            }
            return View("Edit");
        }
    }
    }
