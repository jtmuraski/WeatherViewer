using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenWeatherSdk.Models;
using OpenWeatherSdk.Models.ApiCallResponseModels;

namespace WeatherViewer.Core.Models.SyncfusionModels
{
    /// <summary>
    /// This is used to hold a compatible data model to be used with the Synfusion Data Tree Grid when viewing a short summary of previous
    /// weather data. SummmaryReports should only hold ShortSummary's whose StationId property match the StationId of ShortSummaryTreeGrid
    /// </summary>
    public class ShortSummaryTreeGrid
    {
        public string StationId { get; set; }
        public List<ShortSummary> SummaryReports { get; set; }
        public double AvgTemp { get; set; } 
        public double AvgPrecip { get; set; }
        public double AvgPressure { get; set; }

        public ShortSummaryTreeGrid()
        {
            SummaryReports = new List<ShortSummary>();
        }
        /// <summary>
        /// Creates a new object using the StationId. summaryCollection will be filtered to save only those object with a matching 
        /// StationID to stationId
        /// </summary>
        /// <param name="stationId"></param>
        /// <param name="summaryCollection"></param>
        public ShortSummaryTreeGrid(string stationId, List<ShortSummary> summaryCollection)
        {
            StationId = stationId;
            SummaryReports = summaryCollection.Where(report => report.StationId == stationId).ToList();
            AvgTemp = SummaryReports.Average(report => report.TempC);
            AvgPrecip = SummaryReports.Average(report => report.PrecipIn);
            AvgPressure = SummaryReports.Average(report => report.AltimeterInHg);
        }
    }
}
