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
        private Context _context;
        public StudentController(Context context)
        {
            _context = context;
        }



        // Get all the students
        [HttpGet]
        public async Task<List<Student>> Get()
        {
            return await _context.students.ToListAsync();
        }



        // [HttpGet]
        // [Route("~/api/meta/schema/{​​​​​​schemaName}​​​​​​")]
        // [Produces(typeof(ModelSchemaSummaries))]
        // public async Task<IActionResult> GetSchemaMeta([FromRoute]string schemaName)
        // {​​​​​​
        //     try
        //     {​​​​​​
        //         var meta = _workflowService.GetSchemaMeta(schemaName);
        //     return Ok(meta);
        //     }​​​​​​
        //     catch (Exception ex)
        //     {​​​​​​
        //         return NotFound(ex.Message);
        //     }​​​​​​
        // }​​​​​​


    }
}