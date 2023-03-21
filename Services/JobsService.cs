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
            if(job == null) throw new Exception("No car with that id");
            return job;
        }

        internal Job UpdateJob(Job jobData)
        {
            Job original = this.GetOneJob(jobData.id);
            original.title = jobData != null ? jobData.title : original.title;
            original.pay = jobData != null ? jobData.pay : original.pay;
            int check = _repo.UpdateJob(original);
            if(check != 1) throw new Exception($"UPDATED {check} jobs");
            return original;
        }

    }
}