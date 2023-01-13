using expanseApigateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;


namespace expanseApigateway.Controllers
{
                                                 
    public class categoryController : ApiController
    {
        apiexpanseEntities2 db = new apiexpanseEntities2();

        [System.Web.Http.HttpGet]
        public IHttpActionResult Getexpanse()
        {
            List<category> list = db.categories.ToList();
            return Ok(list);

        }


        [System.Web.Http.HttpGet]
        public IHttpActionResult GetexpanseById(int id)
        {
            var exp = db.categories.Where(model => model.id == id).FirstOrDefault();
            return Ok(exp);
        }


        [System.Web.Http.HttpPost]
        public IHttpActionResult expinsert(category e)
        {
            db.categories.Add(e);
            db.SaveChanges();
            return Ok();
        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult expupdate(category e)
        {
            db.Entry(e).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Ok();
           
        }

        [System.Web.Http.HttpDelete]

        public IHttpActionResult expdelete(int id)
        {
            var exp = db.categories.Where(model => model.id == id).FirstOrDefault();
            db.Entry(exp).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok(exp);
        }

    }
}

