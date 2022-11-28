using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherViewer.Core.Models.SyncfusionModels.ChartModels;

namespace WeatherViewer.Core.Models.SyncfusionModels
{
    /// <summary>
    /// Contains a List of TimePairValues that contains the times and temperature for that time
    /// seriesName is the StationId name
    /// </summary>
    public class TimeLineData
    {
        public string SeriesName { get; set; }
        public List<TimePairValue> TempChartValues { get; set; }

        public TimeLineData(string name)
        {
            SeriesName = name;
            TempChartValues = new List<TimePairValue>();
        }

        public TimeLineData(string name, List<TimePairValue> temps)
        {
            SeriesName = name;
            TempChartValues = temps;
        }

        public TimeLineData()
        {
            SeriesName = "Temp Name";
            TempChartValues = new List<TimePairValue>();
        }
    }
}
