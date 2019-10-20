using System;
using System.Collections.Generic;
using Trackables.Domain;

namespace Trackables.Services.Abstract
{
    public interface IHighchartsServices
    {
        IEnumerable<Series> GetSeries(DateTime start, DateTime end, IEnumerable<int> selectedIds);
        IEnumerable<string> GetCategories(DateTime start, DateTime end);
    }
}
