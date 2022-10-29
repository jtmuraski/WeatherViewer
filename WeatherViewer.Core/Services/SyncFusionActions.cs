using OpenWeatherSdk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherViewer.Core.Models;
using WeatherViewer.Core.Models.SyncfusionModels;

namespace WeatherViewer.Core.Services
{
    public static class SyncFusionActions
    {
        public static List<ShortSummaryTreeGrid> CreateShortSummaryTreeGrid(List<ShortSummary> data)
        {
            var summaryCollection = new List<ShortSummaryTreeGrid>();
            var stationList = data.Select(x => x.StationId).Distinct().ToList();
            foreach(var station in stationList)
                summaryCollection.Add(new ShortSummaryTreeGrid(station, data.Where(item => item.StationId == station).ToList()));

            return summaryCollection;
        }
    }
}
