using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using StatNav.WebApplication.Interfaces;
using StatNav.WebApplication.Models;

namespace StatNav.WebApplication.DAL
{
    public class IterationLogic : IIterationRepository
    {
        protected StatNavContext Db = new StatNavContext();

        public virtual void Add(ExperimentIteration t)
        {
            Db.Set<ExperimentIteration>().Add(t);
            Db.SaveChanges();
        }

        public virtual void Edit(ExperimentIteration t)
        {
            Db.Entry(t).State = EntityState.Modified;
            Db.SaveChanges();
        }
        public List<ExperimentIteration> LoadList()
        {
            List<ExperimentIteration> iterations = Db.ExperimentIterations
                                                     .OrderBy(x => x.Name)
                                                     .ToList();
            return iterations;

        }

        public ExperimentIteration Load(int id)
        {
            ExperimentIteration iteration = Db.ExperimentIterations
                .Where(x => x.Id == id)
                .Include(x => x.ExperimentProgramme)
                .Include(x=>x.ExperimentCandidates)
                .FirstOrDefault();

            return iteration;
        }
        public void Remove(int id)
        {
            ExperimentIteration iteration = Db.ExperimentIterations
                      .Include(x => x.ExperimentCandidates) 
                      .FirstOrDefault(x => x.Id == id);
            if (iteration != null)
            {
                iteration?.ExperimentCandidates.ToList().ForEach(n => Db.ExperimentCandidates.Remove(n)); 
                Db.ExperimentIterations.Remove(iteration);
                Db.SaveChanges();
            }
        }

        public IList<ExperimentProgramme> GetProgrammes()
        {
            IList<ExperimentProgramme> ep = Db.ExperimentProgrammes
                                              .OrderBy(x => x.Name).ToList();
            return ep;
        }
        
    }
}