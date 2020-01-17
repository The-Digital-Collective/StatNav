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
    public interface IProgrammeRepository : IRepository<ExperimentProgramme>
    {
        IList<MetricModel> GetMetricModels();
        IList<ExperimentStatus> GetStatuses();
        IList<Method> GetMethods();
        List<ExperimentProgramme> SortList(List<ExperimentProgramme> programmes, string sortOrder);
        List<ExperimentIteration> GetIterations(int Id);
    }
    public interface IIterationRepository : IRepository<ExperimentIteration>
    {
        IList<ExperimentProgramme> GetProgrammes();
        List<ExperimentIteration> SortList(List<ExperimentIteration> iterations, string sortOrder);
    }

    public interface ICandidateRepository : IRepository<ExperimentCandidate>
    {
        IList<ExperimentIteration> GetIterations();
        IList<MetricModel> GetMetricModels();
        List<ExperimentCandidate> SortList(List<ExperimentCandidate> candidates, string sortOrder);
    }
}
