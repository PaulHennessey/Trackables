using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Trackables.Data.Abstract;
using Trackables.Domain;
using Trackables.Services.Abstract;

namespace Trackables.Services.Concrete
{
    public class TrackableItemServices : ITrackableItemServices
    {
        private readonly ITrackableItemRepository _trackableItemRepository;
        private readonly ITrackableItemMapper _trackableItemMapper;
        private readonly ITrackablesRepository _trackablesRepository;
        private readonly ITrackablesMapper _trackablesMapper;

        public TrackableItemServices()
        { }


        public TrackableItemServices(ITrackableItemRepository trackableItemRepository, ITrackableItemMapper trackableItemMapper, ITrackablesRepository productRepository, ITrackablesMapper productMapper)
        {
            _trackableItemRepository = trackableItemRepository;
            _trackableItemMapper = trackableItemMapper;
            _trackablesRepository = productRepository;
            _trackablesMapper = productMapper;
        }


        public IEnumerable<TrackableItem> GetTrackableItems(DateTime dt, string userId)
        {
            DataTable trackableItems = _trackableItemRepository.GetTrackableItems(dt, userId);
            return _trackableItemMapper.HydrateTrackableItems(trackableItems);
        }


        public void InsertTrackableItem(int? trackableId, DateTime dt, decimal? quantity)
        {
            _trackableItemRepository.InsertTrackableItem(trackableId, dt, quantity);
        }


        public void UpdateTrackableItem(int? id, decimal? quantity)
        {
            _trackableItemRepository.UpdateTrackableItem(id, quantity);
        }


        public IEnumerable<ChartItemList> GetTrackableChartItems(DateTime start, DateTime end, IEnumerable<int> selectedIds)
        {
            var items = new List<ChartItemList>();

            foreach(int id in selectedIds)
            {
                items.Add(GetChartItemList(start, end, id));
            }

            return items;
        }

        private ChartItemList GetChartItemList(DateTime start, DateTime end, int selectedId)
        {
            var list = new ChartItemList();

            list.Name = GetChartItemListName(selectedId);

            while (start <= end)
            {
                list.ChartItems.Add(GetChartItem(start, selectedId));
                start = start.AddDays(1);
            }

            return list;
        }


        private string GetChartItemListName(int selectedId)
        {
            return _trackablesMapper.HydrateTrackables(_trackablesRepository.GetTrackable(selectedId)).First().Name;
        }

        private ChartItem GetChartItem(DateTime day, int selectedId)
        {
            return _trackableItemMapper.HydrateTrackableItem(_trackableItemRepository.GetTrackableItem(day, selectedId)).First();
        }

        //public Day GetDay(DateTime dt, int userId)
        //{
        //    return new Day()
        //    {
        //        Date = dt,
        //        Food = _foodItemMapper.HydrateFoodItems(_foodItemRepository.GetFoodItems(dt, userId)).ToList()
        //    };
        //}

        //public IEnumerable<Day> GetDays(DateTime start, DateTime end, int userId)
        //{
        //    var days = new List<Day>();

        //    while (start <= end)
        //    {
        //        days.Add(GetDay(start, userId));
        //        start = start.AddDays(1);
        //    }
        //    return days;
        //}



        //public void UpdateFoodItem(int id, int quantity)
        //{
        //    _foodItemRepository.UpdateFoodItem(id, quantity);
        //}


        //public void DeleteFoodItem(int id)
        //{
        //    _foodItemRepository.DeleteFoodItem(id);
        //}
    }
}
