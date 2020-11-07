using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using studentApi.Data;
using studentApi.Models;

namespace studentApi.Controllers
{
    [Route("api/[Controller]")]
    public class StudentController : Controller
    {
        // Database injection
        private Context _context;
        public StudentController(Context context)
        {
            _context = context;
        }

        // Get all the students from database
        [HttpGet]
        public async Task<List<Student>> Get()
        {
            return await _context.students.ToListAsync();
        }

        // CREATE - POST - (if the request from the client is valid then post it here.)
        [HttpPost]
        public IActionResult PostStudent([FromBody]Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model!");
            }

            _context.students.Add(student);
            _context.SaveChanges();

            return Ok();
        }

        // Delete - post
        // Edit - post
        // Details - post

    }
}