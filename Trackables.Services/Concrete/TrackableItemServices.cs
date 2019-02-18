using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MyFoodDiary.Data.Abstract;
using MyFoodDiary.Domain;
using MyFoodDiary.Services.Abstract;

namespace MyFoodDiary.Services.Concrete
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


        public IEnumerable<TrackableItem> GetTrackableItems(DateTime dt, int userId)
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
