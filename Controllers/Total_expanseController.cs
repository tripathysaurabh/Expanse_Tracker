using expanseApigateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace expanseApigateway.Controllers
{
                                         
    public class Total_expanseController : ApiController
    {
        apiexpanseEntities4 db = new apiexpanseEntities4();

        [System.Web.Http.HttpGet]
        public IHttpActionResult Getexpansetotal()
        {
            List<expanse_limit> list = db.expanse_limit.ToList();
            return Ok(list);

        }
        [System.Web.Http.HttpPut]
        public IHttpActionResult expupdate(expanse_limit e)
        {
            db.Entry(e).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Ok();

        }

    }
}
