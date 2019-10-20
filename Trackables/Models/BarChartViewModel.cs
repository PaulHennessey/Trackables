using System.Collections.Generic;
using Trackables.Domain;

namespace Trackables.Models
{
    public class BarChartViewModel
    {
        public BarChartViewModel()
        {
            Categories = new List<string>();
            Series = new List<Series>();
        }
        public List<string> Categories { get; set; }
        public List<Series> Series { get; set; }

        public void MapToSeries(List<List<decimal?>> data, List<string> names)
        {
            for (int i = 0; i < names.Count; i++)
            {
                Series series = new Series
                {
                    Name = names[i],
                    Data = data[i]
                };
                Series.Add(series);
            }
        }

    }

    //public class Series
    //{
    //    public Series()
    //    {
    //        Data = new List<decimal?>();
    //    }
    //    public string Name { get; set; }
    //    public List<decimal?> Data { get; set; }
    //}
}