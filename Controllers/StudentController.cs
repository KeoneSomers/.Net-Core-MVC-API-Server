using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using studentApi.Data;
using studentApi.Models;

namespace studentApi.Controllers
{
    [Route("api/StudentController")]
    public class StudentController : Controller
    {
        // DATABASE CONNECTION -------------------------------------------------------------------------------
        private Context database;

        public StudentController(Context context)
        {
            database = context;
        }
        // ----------------------------------------------------------------------------------------------------




        // Return a list of All Students ----------------------------------------------------------------------
        [HttpGet("getAll")]
        public async Task<List<Student>> Get()
        {
            return await database.students.ToListAsync();
        }



        // Return just one Student ----------------------------------------------------------------------------
        [HttpGet("GetSingle/{Id}")]
        public async Task<Student> GetStudent(int Id)
        {
            var Student = database.students.Where(student => student.Id == Id).SingleOrDefaultAsync();

            return await Student;
        }



        // Create a new Student -------------------------------------------------------------------------------
        [HttpPost("Create")]
        public async Task<IActionResult> PostStudent([FromBody]Student student)
        {
            if (!ModelState.IsValid) {return BadRequest();}

            database.students.Add(student);
            await database.SaveChangesAsync();

            return Ok();
        }



        // Delete a Student ----------------------------------------------------------------------------------
        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await database.students.FindAsync(id);

            if (student == null) {return NotFound();}

            database.students.Remove(student);
            await database.SaveChangesAsync();

            return NoContent();
        }

        // Edit a Student -------------------------------------------------------------------------------------
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit([FromBody]Student updatedStudent)
        {
            if (!ModelState.IsValid) {return BadRequest("Not a valid model");}

            var existingStudent = await database.students.FindAsync(updatedStudent.Id);

            if (existingStudent != null)
            {
                existingStudent.Id = updatedStudent.Id;
                existingStudent.Name = updatedStudent.Name;

                await database.SaveChangesAsync();
            }
            else {return NotFound();}

            return Ok();
        }

    }
}