using expanseApigateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace expanseApigateway.Controllers
{
                                              
    public class expansemvcController : Controller
    {
        // GET: expansemvc
        HttpClient client = new HttpClient();
        private object db;
        public ActionResult Index()
        {
            List<expanse_table> emp_list = new List<expanse_table>();
            client.BaseAddress = new Uri("https://localhost:44385/api/expanse");
            var response = client.GetAsync("expanse");
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<expanse_table>>();
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
        public ActionResult create(expanse_table exp)
        {

            client.BaseAddress = new Uri("https://localhost:44385/api/expanse");
            var response = client.PostAsJsonAsync<expanse_table>("expanse", exp);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }
            return View("Create");
        }

        public ActionResult Details(int id)
        {
            expanse_table e = null;
            client.BaseAddress = new Uri("https://localhost:44385/api/expanse");
            var response = client.GetAsync("expanse?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<expanse_table>();
                display.Wait();
                e = display.Result;
            }
            return View(e);

        }
        public ActionResult Edit(int id)
        {
            expanse_table e = null;
            client.BaseAddress = new Uri("https://localhost:44385/api/expanse");
            var response = client.GetAsync("expanse?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<expanse_table>();
                display.Wait();
                e = display.Result;
            }
            return View(e);
        }
        [System.Web.Mvc.HttpPost]
        public ActionResult Edit(expanse_table e)
        {
            client.BaseAddress = new Uri("https://localhost:44385/api/expanse");
            var response = client.PutAsJsonAsync<expanse_table>("expanse", e);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }
            return View("Edit");
        }
        public ActionResult Delete(int id)
        {
            expanse_table e = null;
            client.BaseAddress = new Uri("https://localhost:44385/api/expanse");
            var response = client.GetAsync("expanse?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<expanse_table>();
                display.Wait();
                e = display.Result;
            }
            return View(e);
        }

        [System.Web.Mvc.HttpPost, System.Web.Mvc.ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            client.BaseAddress = new Uri("https://localhost:44385/api/expanse");
            var response = client.DeleteAsync("expanse/"+ id.ToString() );
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }
            return View("Delete");
          
        }

    }
}
