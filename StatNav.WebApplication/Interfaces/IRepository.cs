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
        List<Experiment> GetExperiments(int Id);
        IList<PackageContainer> GetPCs();
    }
    public interface IExperimentRepository : IRepository<Experiment>
    {
        IList<MarketingAssetPackage> GetMAPs();
        List<Experiment> SortList(List<Experiment> experiments, string sortOrder);
        List<Variant> GetVariants(int Id);
    }

    public interface IVariantRepository : IRepository<Variant>
    {
        IList<Experiment> GetExperiments();
        IList<MetricModel> GetMetricModels();
        List<Variant> SortList(List<Variant> variants, string sortOrder);
    }
}
