using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace W10D2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private JobsService jobsService;

        public JobsController(JobsService jobsService)
        {
            this.jobsService = jobsService;
        }

        [HttpGet]
        public ActionResult<List<Job>> GetAllJobs(){
            try 
            {
                List<Job> jobs = jobsService.getAllJobs();
                return Ok(jobs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Job> GetOneJob(int id){
            try 
            {
                Job job = jobsService.GetOneJob(id);
                return Ok(job);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        public ActionResult<Job> CreateJob([FromBody] Job jobData){
            try 
            {
                Job job = jobsService.CreateJob(jobData);
                return Ok(job);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("{id}")]
        public ActionResult<Job> UpdateJob(int id, [FromBody] Job jobData){
            try 
            {
                jobData.id = id;
                Job job = jobsService.UpdateJob(jobData);
                return Ok(job);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}