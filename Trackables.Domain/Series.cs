using System.Collections.Generic;

namespace Trackables.Domain
{
    public class Series
    {
        public Series()
        {
            Data = new List<decimal?>();
        }
        public string Name { get; set; }
        public List<decimal?> Data { get; set; }
    }
}