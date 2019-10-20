using System;
using System.Collections.Generic;
using System.Linq;
using Trackables.Data.Abstract;
using Trackables.Domain;
using Trackables.Services.Abstract;

namespace Trackables.Services.Concrete
{
    public class HighchartsServices : IHighchartsServices
    {
        private readonly ITrackableItemRepository _trackableItemRepository;
        private readonly ITrackableItemMapper _trackableItemMapper;
        private readonly ITrackablesRepository _trackablesRepository;
        private readonly ITrackablesMapper _trackablesMapper;

        public HighchartsServices()
        { }

        public HighchartsServices(ITrackableItemRepository trackableItemRepository, ITrackableItemMapper trackableItemMapper, ITrackablesRepository productRepository, ITrackablesMapper productMapper)
        {
            _trackableItemRepository = trackableItemRepository;
            _trackableItemMapper = trackableItemMapper;
            _trackablesRepository = productRepository;
            _trackablesMapper = productMapper;
        }

        public IEnumerable<Series> GetSeries(DateTime start, DateTime end, IEnumerable<int> selectedIds)
        {
            var series = new List<Series>();

            foreach (int id in selectedIds)
            {
                series.Add(GetSeries(start, end, id));
            }

            return series;
        }

        public IEnumerable<string> GetCategories(DateTime start, DateTime end)
        {
            var categories = new List<string>();

            while (start <= end)
            {
                categories.Add(start.ToShortDateString());
                start = start.AddDays(1);
            }

            return categories;
        }

        private Series GetSeries(DateTime start, DateTime end, int selectedId)
        {
            var series = new Series();

            series.Name = GetSeriesName(selectedId);

            while (start <= end)
            {
                series.Data.Add(GetQuantity(start, selectedId));
                start = start.AddDays(1);
            }

            return series;
        }

        private string GetSeriesName(int selectedId)
        {
            return _trackablesMapper.HydrateTrackables(_trackablesRepository.GetTrackable(selectedId)).First().Name;
        }

        private decimal? GetQuantity(DateTime day, int selectedId)
        {
            return _trackableItemMapper.HydrateTrackableItem(_trackableItemRepository.GetTrackableItem(day, selectedId)).First().Quantity;
        }

    }
}
