using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using StatNav.WebApplication.BLL;
using StatNav.WebApplication.Interfaces;
using StatNav.WebApplication.Models;

namespace StatNav.WebApplication.DAL
{
    public class PackageContainerRepository : GenericRepository<PackageContainer>, IPackageContainerRepository
    {

        public override List<PackageContainer> LoadList(string sortOrder, string searchString)
        {
            IQueryable<PackageContainer> containers = Db.PackageContainer
                               .Include(x => x.MetricModelStage);

            // TODO
            // containers = ProgrammeLogic.FilterProgrammes(programmes, searchString); 
            return SortList(containers.ToList(), sortOrder);
        }

        public List<ExperimentIteration> GetIterations(int Id)
        {
            return Db.ExperimentIterations
                     .Where(x => x.ExperimentProgrammeId == Id)
                     .OrderBy(i => i.IterationName)
                     .ToList();
        }

        public List<PackageContainer> SortList(List<PackageContainer> containers, string sortOrder)
        {
            // TODO
            // return ProgrammeLogic.SortProgrammes(programmes, sortOrder);
            return containers;
        }

        public override PackageContainer Load(int id)
        {
            PackageContainer container = Db.PackageContainer
                                              .Include(x => x.ExperimentProgrammes)
                                              .Where(x => x.Id == id)
                                              .FirstOrDefault();

            return container;
        }
        public override void Remove(int id)
        {
            PackageContainer pc = Db.PackageContainer
                      .Include(p => p.ExperimentProgrammes.Select(i => i.ExperimentIterations.Select(c => c.ExperimentCandidates)))
                      .FirstOrDefault(x => x.Id == id);
            if (pc != null)
            {
                //remove candidates
                pc?.ExperimentProgrammes.ToList().ForEach(i => i.ExperimentIterations.ToList().ForEach(c => c.ExperimentCandidates.ToList().ForEach(n => Db.ExperimentCandidates.Remove(n))));
                //remove iterations
                pc?.ExperimentProgrammes.ToList().ForEach(i => i.ExperimentIterations.ToList().ForEach(n => Db.ExperimentIterations.Remove(n)));
                //remove marketing asset packages
                pc?.ExperimentProgrammes.ToList().ForEach(n => Db.ExperimentProgrammes.Remove(n));
                Db.PackageContainer.Remove(pc);
                Db.SaveChanges();
            }
        }

        public IList<MetricModelStage> GetStages()
        {
            IList<MetricModelStage> mms = Db.MetricModelStages
                                            .OrderBy(x => x.SortOrder).ToList();
            return mms;
        }

        public List<ExperimentProgramme> GetProgrammes(int Id)
        {
            return Db.ExperimentProgrammes
                    .Where(x => x.PackageContainerId == Id)
                    .OrderBy(i => i.ProgrammeName)
                    .ToList();
        }
    }
}