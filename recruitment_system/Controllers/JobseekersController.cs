using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using recruitment_system.API.Models;
using recruitment_system.Model;
using recruitment_system.Models;

namespace recruitment_system.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobseekersController : ControllerBase
    {
        private readonly OnlineRecruitmentSystemContext _context;

        public JobseekersController(OnlineRecruitmentSystemContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jobseeker>>> GetJobseekers()
        {
            return await _context.Jobseekers.ToListAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{name}")]
        public async Task<ActionResult<Jobseeker>> GetJobseeker(string name)
        {
            var jobseeker = await _context.Jobseekers.FindAsync(name);

            if (jobseeker == null)
            {
                return NotFound();
            }

            return jobseeker;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{name}")]
        public async Task<IActionResult> PutJobseeker(string name, Jobseeker jobseeker)
        {
            if (name!= jobseeker.JobseekerName)
            {
                return BadRequest();
            }

            _context.Entry(jobseeker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobseekerExists(name))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Jobseeker>> PostCustomer(Jobseeker jobseeker)
        {
            _context.Jobseekers.Add(jobseeker);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobseeker", new { id = jobseeker.JobseekerName }, jobseeker);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobseeker(int id)
        {
            var customer = await _context.Jobseekers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Jobseekers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobseekerExists(string name)
        {
            return _context.Jobseekers.Any(e => e.JobseekerName == name);
        }
    }
}