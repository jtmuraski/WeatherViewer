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
        public string seriesName { get; set; }
        public List<TimePairValue> tempChartValues { get; set; }
    }
}
