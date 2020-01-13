using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using StatNav.WebApplication.BLL;
using StatNav.WebApplication.Interfaces;
using StatNav.WebApplication.Models;

namespace StatNav.WebApplication.DAL
{
    public class IterationRepository : GenericRepository<ExperimentIteration>, IIterationRepository
    {       
        public override List<ExperimentIteration> LoadList(string sortOrder, string searchString)
        {
            IQueryable<ExperimentIteration> iterations = Db.ExperimentIterations;
            iterations = IterationLogic.FilterIterations(iterations, searchString);
            return SortList(iterations.ToList(), sortOrder);
        }

        public List<ExperimentIteration> SortList(List<ExperimentIteration> iterations, string sortOrder)
        {
            return IterationLogic.SortIterations(iterations, sortOrder);
        }
        public override ExperimentIteration Load(int id)
        {
            ExperimentIteration iteration = Db.ExperimentIterations
                .Where(x => x.Id == id)
                .Include(x => x.ExperimentProgramme)
                .Include(x=>x.ExperimentCandidates)
                .FirstOrDefault();

            return iteration;
        }
        public override void Remove(int id)
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
                                              .OrderBy(x => x.ProgrammeName).ToList();
            return ep;
        }
        
    }
}