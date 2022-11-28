using OpenWeatherSdk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherViewer.Core.Models;
using WeatherViewer.Core.Models.SyncfusionModels;
using WeatherViewer.Core.Models.SyncfusionModels.ChartModels;
using System.Diagnostics;

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
        public static List<TimeLineData> CreateSummaryChartData(List<ShortSummary> data)
        {
            List<TimeLineData> chartData = new List<TimeLineData>();
            List<string> summaryStations = data.Select(x => x.StationId).Distinct().ToList(); 
            foreach(var station in summaryStations)
            {
                var seriesData = new TimeLineData(station);
                List<ShortSummary> stationData = data.Where(report => report.StationId == station).OrderBy(report => report.ObservationTime).ToList();
                foreach (var report in stationData)
                {
                    DateTime localTime = report.ObservationTime.ToLocalTime();
                    seriesData.TempChartValues.Add(new TimePairValue()
                    {
                        xTime = new DateTime(localTime.Year, localTime.Month, localTime.Day, localTime.Hour, 0, 0),
                        yValue = report.TempC
                    });
                }
                chartData.Add(seriesData);
            }
            return chartData;
        }
    }
}
