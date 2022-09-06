using ApexCharts;
using BlazorApp1.Data;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorApp1.Pages
{
    public partial class WorksButDelayed
    {
        public List<(int id, List<DataItem> data)> Series = new();

        private ApexChart<DataItem>? chart;

        private int id = 0;

        protected override void OnInitialized()
        {
            for (int i = 0; i < 5; i++)
            {
                var data = new List<DataItem>();
                for (int j = 0; j < 20; j++)
                {
                    data.Add(new DataItem(DateTime.UtcNow.AddDays(-20 + 1 + j).Date, Random.Shared.Next(10, 100)));
                }
                Series.Add(new(id++, data));
            }
        }

        private async Task AddSeries(MouseEventArgs args)
        {
            var data = new List<DataItem>();
            for (int j = 0; j < 20; j++)
            {
                data.Add(new DataItem(DateTime.UtcNow.AddDays(-20 + 1 + j).Date, Random.Shared.Next(10, 100)));
            }
            Series.Add(new(id++, data));

            //We need to give blazor a chance to send down the new series
            await Task.Delay(10); 
           
            if (chart != null)
            {
                await chart.UpdateSeriesAsync();
            }
        }
    }
}
