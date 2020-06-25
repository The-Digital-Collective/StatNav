using StatNav.WebApplication.BLL;
using StatNav.WebApplication.Interfaces;
using StatNav.WebApplication.Models;
using System.Collections.Generic;
using System.Linq;



namespace StatNav.UnitTests.TestData
{
    class DummyCandidateRepository : ICandidateRepository
    {
        List<ExperimentCandidate> dummyCandidates = null;

        public DummyCandidateRepository(List<ExperimentCandidate> candidates)
        {
            dummyCandidates = candidates;
        }
        public List<ExperimentCandidate> LoadList(string sortOrder, string searchString = "")
        {
            IQueryable<ExperimentCandidate> queryCandidates = dummyCandidates.AsQueryable();
            queryCandidates = CandidateLogic.FilterCandidates(queryCandidates, searchString);
            return SortList(queryCandidates.ToList(), sortOrder);
        }
        public List<ExperimentCandidate> SortList(List<ExperimentCandidate> candidates, string sortOrder)
        {
            return candidates = CandidateLogic.SortCandidates(candidates, sortOrder);
        }
        public ExperimentCandidate Load(int id)
        {
            return dummyCandidates.Where(x => x.Id == id).FirstOrDefault();
        }
        public void Add(ExperimentCandidate ec)
        {
            dummyCandidates.Add(ec);
        }
        public void Edit(ExperimentCandidate ec)
        {
            int id = ec.Id;
            Remove(id);
            dummyCandidates.Add(ec);

        }
        public void Remove(int id)
        {
            ExperimentCandidate candidateToDel = dummyCandidates.Where(x => x.Id == id).FirstOrDefault();
            dummyCandidates.Remove(candidateToDel);
        }

        public IList<Experiment> GetExperiments()
        {
            Experiment experiment1 = new Experiment { ExperimentName = "experiment1", Id = 1};
            Experiment experiment2 = new Experiment() { ExperimentName = "experiment2", Id = 2};
            return new List<Experiment> { experiment1, experiment2 };
        }
        public IList<MetricModel> GetMetricModels()
        {
            MetricModel m1 = new MetricModel { Id = 0, Title = "Bounce Rate" };
            MetricModel m2 = new MetricModel { Id = 1, Title = "Basket Adds" };
            return new List<MetricModel> { m1, m2 };
        }
    }
}
