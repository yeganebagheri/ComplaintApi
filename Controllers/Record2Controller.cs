using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data;
using Test.Models;
using Test.Repositories;

namespace Complaint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Record2Controller : ControllerBase
    {
        private readonly TestDbContext _db;
        private IUserService _userService;

        public Record2Controller(IUserService userService, TestDbContext db)
        {
            _userService = userService;
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComplaintModel>>> Get()
        {
            return await _db.ComplaintModels.ToListAsync();
        }

        //GET: api/Record2/

        [HttpGet("{id}")]
        public async Task<ActionResult<ComplaintModel>> GetComplaint(long id)
        {

            var X = await _db.ComplaintModels.FindAsync(id);

            if (X == null)
            {
                return NotFound();
            }

            return X;
        }



        [HttpPost]
        public async Task<ActionResult<ComplaintModel>> PostComplaint([FromBody]ComplaintModel model)
        {

            var result = await _userService.RecordAsync(model);

            if (result.IsSuccess)
                return Ok(result); // Status Code: 200 

            return BadRequest(result);

            
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
