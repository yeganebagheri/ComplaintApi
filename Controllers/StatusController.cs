using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Http;
using Test.Data;
using Test.Models;
using Test.Repositories;

namespace Complaint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private IUserService _userService;
        private readonly TestDbContext _db;

        public StatusController(IUserService userService, TestDbContext db)
        {
            _userService = userService;
            _db = db;

        }

        
        
        [HttpPut]
        public async Task<ActionResult<ComplaintModel>> PutComplaint([FromBody] ComplaintModel model)
        {

            var result = await _userService.PutStatusAsync(model);

            if (result.IsSuccess)
                return Ok(result); // Status Code: 200 

            return BadRequest(result);


        }

    }
}

       