using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Service.Models;
using Service.Connector;

namespace Service.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        // GET: api/User/user
        [HttpGet]
        [Route("{userName}")]
        public UserInfo Get(string userName)
        {
            UserDbConnector dbc = new UserDbConnector();
            return dbc.getUser(userName);
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] UserInfo user)
        {
            UserDbConnector dbc = new UserDbConnector();
            dbc.add(user);
        }
    }
}
