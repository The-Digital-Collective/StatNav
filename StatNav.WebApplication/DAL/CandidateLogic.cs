using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using StatNav.WebApplication.Interfaces;
using StatNav.WebApplication.Models;

namespace StatNav.WebApplication.DAL
{
    public class CandidateLogic : ICandidateRepository
    {
        protected StatNavContext Db = new StatNavContext();

        public virtual void Add(ExperimentCandidate t)
        {
            Db.Set<ExperimentCandidate>().Add(t);
            Db.SaveChanges();
        }

        public virtual void Edit(ExperimentCandidate t)
        {
            Db.Entry(t).State = EntityState.Modified;
            Db.SaveChanges();
        }
        public List<ExperimentCandidate> LoadList()
        {
            List<ExperimentCandidate> candidates = Db.ExperimentCandidates
                                                     .OrderBy(x => x.Name)
                                                     .ToList();
            return candidates;

        }

        public ExperimentCandidate Load(int id)
        {
            ExperimentCandidate candidate = Db.ExperimentCandidates
                                              .Where(x => x.Id == id)
                                              .Include(x => x.ExperimentIteration)
                                              .Include(x=>x.ImpactMetricModel)
                                              .Include(x=>x.TargetMetricModel)
                                              .FirstOrDefault();
            return candidate;
        }
        public virtual void Remove(int id)
        {
            ExperimentCandidate candidate = Db.ExperimentCandidates.Find(id);
            if (candidate != null)
            {
                Db.ExperimentCandidates.Remove(candidate);
                Db.SaveChanges();
            }
        }

        public IList<ExperimentIteration> GetIterations()
        {
            IList<ExperimentIteration> ei = Db.ExperimentIterations
                                              .OrderBy(x => x.Name).ToList();
            return ei;
        }
        public IList<MetricModel> GetMetricModels()
        {
            IList<MetricModel> mm = Db.MetricModels
              .OrderBy(x => x.Title).ToList();
            return mm;
        }
    }
}