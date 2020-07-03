using StatNav.WebApplication.BLL;
using StatNav.WebApplication.Interfaces;
using StatNav.WebApplication.Models;
using System.Collections.Generic;
using System.Linq;



namespace StatNav.UnitTests.TestData
{
    class DummyVariantRepository : IVariantRepository
    {
        List<Variant> dummyVariants = null;

        public DummyVariantRepository(List<Variant> variants)
        {
            dummyVariants = variants;
        }
        public List<Variant> LoadList(string sortOrder, string searchString = "")
        {
            IQueryable<Variant> queryVariants = dummyVariants.AsQueryable();
            queryVariants = VariantLogic.FilterVariants(queryVariants, searchString);
            return SortList(queryVariants.ToList(), sortOrder);
        }
        public List<Variant> SortList(List<Variant> variants, string sortOrder)
        {
            return variants = VariantLogic.SortVariants(variants, sortOrder);
        }
        public Variant Load(int id)
        {
            return dummyVariants.Where(x => x.Id == id).FirstOrDefault();
        }
        public void Add(Variant ec)
        {
            dummyVariants.Add(ec);
        }
        public void Edit(Variant ec)
        {
            int id = ec.Id;
            Remove(id);
            dummyVariants.Add(ec);

        }
        public void Remove(int id)
        {
            Variant variantToDel = dummyVariants.Where(x => x.Id == id).FirstOrDefault();
            dummyVariants.Remove(variantToDel);
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
