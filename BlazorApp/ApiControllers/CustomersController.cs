
using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
namespace BlazorApp.Controllers 
{
  
    public class CustomersController : ODataController
    {


        [EnableQuery]
        public ActionResult<IEnumerable<User>> Get()
        {
            var us = new DAL.UsersService();
            var users = us.GetUsers();
            return Ok(users);
        }

        [EnableQuery]
        public ActionResult<User> Get([FromRoute] int key)
        {   var us = new DAL.UsersService();
            var users = us.GetUsers();
            var item = users.SingleOrDefault(d => d.Id.Equals(key));

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }
    }




}
