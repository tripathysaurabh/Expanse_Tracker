using expanseApigateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace expanseApigateway.Controllers
{

                                                   
    public class categorymvcController : Controller
    {

        HttpClient client = new HttpClient();
        // GET: categorymvc
        public ActionResult CategoryIndex()
        {

            List<category> emp_list = new List<category>();
            client.BaseAddress = new Uri("https://localhost:44385/api/category");
            var response = client.GetAsync("category");
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<category>>();
                display.Wait();
                emp_list = display.Result;

            }
            return View(emp_list);
        }

        public ActionResult Create()
        {
         return View();
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult create(category exp)
        {
            client.BaseAddress = new Uri("https://localhost:44385/api/category");
            var response = client.PostAsJsonAsync<category>("category", exp);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("CategoryIndex");
            }
            return View("Create");
        }

        public ActionResult Details(int id)
        {
            category e = null;
            client.BaseAddress = new Uri("https://localhost:44385/api/category");
            var response = client.GetAsync("category?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<category>();
                display.Wait();
                e = display.Result;
            }
            return View(e);

        }
        public ActionResult Edit(int id)
        {
            category e = null;
            client.BaseAddress = new Uri("https://localhost:44385/api/category");
            var response = client.GetAsync("category?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<category>();
                display.Wait();
                e = display.Result;
            }
            return View(e);
        }
        [System.Web.Mvc.HttpPost]
        public ActionResult Edit(category e)
        {
            client.BaseAddress = new Uri("https://localhost:44385/api/category");
            var response = client.PutAsJsonAsync<category>("category", e);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("CategoryIndex");
            }
            return View("Edit");
        }
        public ActionResult Delete(int id)
        {
            category e = null;
            client.BaseAddress = new Uri("https://localhost:44385/api/category");
            var response = client.GetAsync("category?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<category>();
                display.Wait();
                e = display.Result;
            }
            return View(e);
        }

        [System.Web.Mvc.HttpPost, System.Web.Mvc.ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            client.BaseAddress = new Uri("https://localhost:44385/api/category");
            var response = client.DeleteAsync("category/" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("CategoryIndex");
            }
            return View("Delete");

        }
    }
}