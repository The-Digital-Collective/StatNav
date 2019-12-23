using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatNav.WebApplication.DAL;
using StatNav.WebApplication.Models;

namespace StatNav.UnitTests
{
    class StatNavTestData : StatNavContext
    {
        public IQueryable<ExperimentProgramme> Get()
        {
            return (new List<ExperimentProgramme>() {
                new ExperimentProgramme() { Name="Test1" },
                new ExperimentProgramme() { Name="Test2" },
            }).AsQueryable<ExperimentProgramme>();
        }
    }
}
