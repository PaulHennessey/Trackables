using System;
using System.Collections.Generic;
using System.Data;
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
    }
}
