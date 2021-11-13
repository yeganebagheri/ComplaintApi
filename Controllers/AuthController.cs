using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Controllers;
using Test.Data;
using Test.Models;
using Test.Repositories;

namespace Complaint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

            private IUserService _userService;
            private readonly TestDbContext _db;




            public AuthController( IUserService userService, TestDbContext db)
            {
                _userService = userService;
                _db = db;

            }



            [HttpGet("index")]
            public IEnumerable<User> Index()
            {
                return _db.Users.ToList();
            }


            // /api/auth/register
            [HttpPost("Register")]
            public async Task<IActionResult> RegisterAsync([FromBody] User model)
            {

            
                var result = await _userService.RegisterUserAsync(model);

                if (result.IsSuccess)
                    return Ok(result); // Status Code: 200 

                return BadRequest(result);
            
            }


        //"FirstName":"dog",
        // "LastName":"smit",
        // "Pass":"1234",
        // "Address":" dogdogdog",
        // "Degree":"master",
        // "NationalCode":"54321" 



        // /api/auth/login
        [HttpPost("Login")]
            public async Task<IActionResult> LoginAsync([FromBody] User model)
            {
                //if (ModelState.IsValid)
                //{
                    var result = await _userService.LoginUserAsync(model);

                    if (result.IsSuccess)
                    {
                        
                        return Ok(result);
                    }

                    return BadRequest(result);
                //}

                //return BadRequest("Some properties are not valid");
            }

        
    }

}

