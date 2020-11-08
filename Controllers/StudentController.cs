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

        // Get One Student
        [HttpGet("{Id}")]
        public Student GetStudent(int Id)
        {
            var Student = _context.students.Where(a => a.Id == Id).SingleOrDefault();
            return Student;
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
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            _context.students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // Edit - post

    }
}