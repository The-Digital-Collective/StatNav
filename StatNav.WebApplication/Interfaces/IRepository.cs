using System.Collections.Generic;
using StatNav.WebApplication.Models;

namespace StatNav.WebApplication.Interfaces
{
    public interface IRepository<T>
    {

        List<T> LoadList(string sortOrder, string searchString);
        T Load(int id);
        void Add(T t);
        void Edit(T t);
        void Remove(int id);

    }

    public interface IPackageContainerRepository : IRepository<PackageContainer>
    {
        IList<MetricModelStage> GetStages();
        List<MarketingAssetPackage> GetMAPs(int Id);
    }
    public interface IMAPRepository : IRepository<MarketingAssetPackage>
    {
        IList<MetricModel> GetMetricModels();
        IList<ExperimentStatus> GetStatuses();
        IList<Method> GetMethods();
        List<MarketingAssetPackage> SortList(List<MarketingAssetPackage> maps, string sortOrder);
        List<ExperimentIteration> GetIterations(int Id);
        IList<PackageContainer> GetPCs();
    }
    public interface IIterationRepository : IRepository<ExperimentIteration>
    {
        IList<MarketingAssetPackage> GetMAPs();
        List<ExperimentIteration> SortList(List<ExperimentIteration> iterations, string sortOrder);
        List<ExperimentCandidate> GetCandidates(int Id);
    }

    public interface ICandidateRepository : IRepository<ExperimentCandidate>
    {
        IList<ExperimentIteration> GetIterations();
        IList<MetricModel> GetMetricModels();
        List<ExperimentCandidate> SortList(List<ExperimentCandidate> candidates, string sortOrder);
    }
}
