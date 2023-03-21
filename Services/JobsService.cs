using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace W10D2.Services
{
    public class JobsService
    {
        private JobsRepository _repo;

        public JobsService(JobsRepository repo)
        {
            _repo = repo;
        }

        internal List<Job> getAllJobs()
        {
            List<Job> jobs = _repo.getAllJobs();
            return jobs;
        }

        internal Job GetOneJob(int id)
        {
            Job job = _repo.GetOneJob(id);
            return job;
        }

        internal Job CreateJob(Job jobData)
        {
            Job job = _repo.CreateJob(jobData);
            return job;
        }

        internal Job UpdateJob(Job jobData)
        {
            throw new Exception("not implemented yet!");
        }

    }
}