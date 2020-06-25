using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using StatNav.WebApplication.BLL;
using StatNav.WebApplication.Interfaces;
using StatNav.WebApplication.Models;

namespace StatNav.WebApplication.DAL
{
    public class CandidateRepository : GenericRepository<ExperimentCandidate>, ICandidateRepository
    {
        public override List<ExperimentCandidate> LoadList(string sortOrder, string searchString)
        {
            IQueryable<ExperimentCandidate> candidates = Db.ExperimentCandidates;
            candidates = CandidateLogic.FilterCandidates(candidates, searchString);
            return SortList(candidates.ToList(), sortOrder);

        }

        public List<ExperimentCandidate> SortList(List<ExperimentCandidate> candidates, string sortOrder)
        {
            return CandidateLogic.SortCandidates(candidates, sortOrder);
        }

        public override ExperimentCandidate Load(int id)
        {
            ExperimentCandidate candidate = Db.ExperimentCandidates
                                              .Where(x => x.Id == id)
                                              .Include(x => x.Experiment)
                                              .Include(x=>x.CandidateImpactMetricModel)
                                              .Include(x=>x.CandidateTargetMetricModel)
                                              .FirstOrDefault();
            return candidate;
        }        

        public IList<Experiment> GetExperiments()
        {
            IList<Experiment> ex = Db.Experiments
                                              .OrderBy(x => x.ExperimentName).ToList();
            return ex;
        }
        public IList<MetricModel> GetMetricModels()
        {
            IList<MetricModel> mm = Db.MetricModels
              .OrderBy(x => x.Title).ToList();
            return mm;
        }
    }
}