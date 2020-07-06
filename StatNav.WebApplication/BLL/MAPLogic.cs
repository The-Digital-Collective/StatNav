using StatNav.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StatNav.WebApplication.BLL
{
    public static class MAPLogic
    {
        public static IQueryable<MarketingAssetPackage> FilterMAPs(IQueryable<MarketingAssetPackage> maps, string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                maps = maps.Where(x => x.MAPName.ToLower().Contains(searchString.ToLower()) );
            }
            return maps;
        }
        public static List<MarketingAssetPackage> SortMAPs(List<MarketingAssetPackage> mapList, string sortOrder)
        {
            IOrderedEnumerable<MarketingAssetPackage> sortedList;
            switch (sortOrder)
            {
                case "name_desc":
                    sortedList = mapList.OrderByDescending(x => x.MAPName);
                    break;
                //story 2069 status and ID removed from UI
                //case "Status":
                //    sortedList = mapList.OrderBy(x => x.ExperimentStatus.StatusName);
                //    break;
                //case "status_desc":
                //    sortedList = mapList.OrderByDescending(x => x.ExperimentStatus.StatusName);
                //    break;
                //case "Id":
                //    sortedList = mapList.OrderBy(x => x.Id);
                //    break;
                //case "id_desc":
                //    sortedList = mapList.OrderByDescending(x => x.Id);
                //    break;
                default:
                    sortedList = mapList.OrderBy(x => x.MAPName);
                    break;
            }

            return sortedList.ToList();
        }
    }
}