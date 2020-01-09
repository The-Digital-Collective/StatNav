using StatNav.WebApplication.Interfaces;
using StatNav.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatNav.UnitTests.TestData
{
    class DummyCandidateRepository : ICandidateRepository
    {
        List<ExperimentCandidate> dummyCandidates = null;

        public DummyCandidateRepository(List<ExperimentCandidate> candidates)
        {
            dummyCandidates = candidates;
        }
        public List<ExperimentCandidate> LoadList()
        {
            return dummyCandidates;
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

        public IList<ExperimentIteration> GetIterations()
        {
            ExperimentIteration iteration1 = new ExperimentIteration { IterationName = "Iteration1", Id = 1};
            ExperimentIteration iteration2 = new ExperimentIteration() { IterationName = "Iteration2", Id = 2};
            return new List<ExperimentIteration> { iteration1, iteration2 };
        }
        public IList<MetricModel> GetMetricModels()
        {
            MetricModel m1 = new MetricModel { Id = 0, Title = "Bounce Rate" };
            MetricModel m2 = new MetricModel { Id = 1, Title = "Basket Adds" };
            return new List<MetricModel> { m1, m2 };
        }
    }
}
