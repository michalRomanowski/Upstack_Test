using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using UpstackTest.Models;

namespace UpstackTest.Controllers
{
    public class UsersController : ApiController
    {
        private DBManager db = new DBManager();

        [Route("api/Users/Activate/{id}")]
        [HttpGet]
        public IHttpActionResult Activate(int id)
        {
            if (db.ActivateUser(id) == ActivateUserResult.Ok)
                return Ok();

            return NotFound();
        }
    }
}