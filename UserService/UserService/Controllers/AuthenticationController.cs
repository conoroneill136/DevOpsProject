﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Model;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        // controller used for original testing for workshop 2

        //test variables
        readonly Registration TestUser = new Registration { FirstName = "Conor", LastName = "Oneill", Email = "test@version1.com", Password = "test123" };


        // POST api/Authentication
        [HttpPost]
        public object Post(string email, string password)
        {
            if (TestUser.Email == email && TestUser.Password == password)
            {
                return this.Ok("success: all good!");
            }
            else
            {
                return this.Unauthorized();
            }

        } 

    }
}