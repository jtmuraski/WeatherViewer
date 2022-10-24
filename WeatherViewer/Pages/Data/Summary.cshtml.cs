using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OpenWeatherSdk;
using OpenWeatherSdk.Services;
using OpenWeatherSdk.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace WeatherViewer.Pages.Data
{
    public class SummaryModel : PageModel
    {
        public string Message { get; set; }
        public IEnumerable<ShortSummary> WeatherData { get; set; }
        public void OnGet()
        {
            var weatherSummary = OpenWeatherActions.GetShortSummary();
            if(weatherSummary.ApiResponse == OpenWeatherSdk.Models.Enums.ApiCallStatus.Complete)
            {
                WeatherData = weatherSummary.ShortSummaryCollection;
                Debug.WriteLine("Number of records returned: " + weatherSummary.ShortSummaryCollection.Count);
                Message = string.Empty;
            }
            else
            {
                Message = "Oh no! Something went wrong and the summary weather data could not be retrieved.";
                Message += weatherSummary.Message + "\n";
                Message += weatherSummary.ApiResponse.ToString();
            }
        }
    }
}
