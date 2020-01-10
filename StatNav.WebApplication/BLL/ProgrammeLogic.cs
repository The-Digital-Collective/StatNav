using StatNav.WebApplication.Models;
using System.Collections.Generic;
using System.Linq;

namespace StatNav.WebApplication.BLL
{
    public  class ProgrammeLogic
    {
        public static List<ExperimentProgramme> SortProgrammes(List<ExperimentProgramme> programmeList, string sortOrder)
        {
            IOrderedEnumerable<ExperimentProgramme> sortedList;
            switch (sortOrder)
            {
                case "name_desc":
                    sortedList = programmeList.OrderByDescending(x => x.ProgrammeName);
                    break;
                case "Status":
                    sortedList = programmeList.OrderBy(x => x.ExperimentStatus.StatusName);
                    break;
                case "status_desc":
                    sortedList = programmeList.OrderByDescending(x => x.ExperimentStatus.StatusName);
                    break;
                case "Id":
                    sortedList = programmeList.OrderBy(x => x.Id);
                    break;
                case "id_desc":
                    sortedList = programmeList.OrderByDescending(x => x.Id);
                    break;
                default:
                    sortedList = programmeList.OrderBy(x => x.ProgrammeName);
                    break;
            }

            return sortedList.ToList();
        }
    }
}