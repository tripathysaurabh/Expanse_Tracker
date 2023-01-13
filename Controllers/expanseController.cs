using expanseApigateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace expanseApigateway.Controllers
{
                              
    public class expanseController : ApiController
    {
        apiexpanseEntities3 db = new apiexpanseEntities3();

        [System.Web.Http.HttpGet]
        public IHttpActionResult Getexpanse()
        {
            List<expanse_table> list = db.expanse_table.ToList();
            return Ok(list);

        }
       

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetexpanseById(int id)
        {
            var exp = db.expanse_table.Where(model => model.id == id).FirstOrDefault();
            return Ok(exp);
        }


        [System.Web.Http.HttpPost]
        public IHttpActionResult expinsert(expanse_table e)
        {

            db.expanse_table.Add(e);
            db.SaveChanges();
            return Ok();
        }



        [System.Web.Http.HttpPut]
        public IHttpActionResult expupdate(expanse_table e)
        {
            var exp = db.expanse_table.Where(Model => Model.id == e.id).FirstOrDefault();
            if (exp != null)
            {
                exp.id = e.id;
                exp.Name = e.Name;
                exp.Amount = e.Amount;
                exp.Category = e.Category;
                exp.Description = e.Description;
                db.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

        [System.Web.Http.HttpDelete]

        public IHttpActionResult expdelete(int id)
        {
            var exp = db.expanse_table.Where(model => model.id == id).FirstOrDefault();
            db.Entry(exp).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok(exp);
        }
       
       

    }
}
