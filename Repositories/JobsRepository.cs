using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace W10D2.Repositories
{
    public class JobsRepository
    {
        private readonly IDbConnection _db;

        public JobsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<Job> getAllJobs()
        {
            string sql = @"
            SELECT
            *
            FROM jobs;
            ";
            List<Job> jobs = _db.Query<Job>(sql).ToList();
            return jobs;
        }

        internal Job CreateJob(Job jobData)
        {
            string sql = @"
            INSERT INTO jobs
            (title, pay)
            VALUES
            (@title, @pay);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, jobData);
            jobData.id = id;
            return jobData;
        }
    }
}