using System.Collections.Generic;
using System.Data;
using System.Linq;
using Trackables.Data.Abstract;
using Trackables.Domain;
using Trackables.Services.Abstract;

namespace Trackables.Services.Concrete
{
    public class TrackablesServices : ITrackablesServices
    {
        private readonly ITrackablesRepository _trackablesRepository;
        private readonly ITrackablesMapper _trackablesMapper;

        public TrackablesServices()
        { }

        public TrackablesServices(ITrackablesRepository productRepository, ITrackablesMapper productMapper)
        {
            _trackablesRepository = productRepository;
            _trackablesMapper = productMapper;
        }

        public IEnumerable<Trackable> GetTrackables(string userId)
        {
            DataTable dataTable = _trackablesRepository.GetTrackables(userId);
            return _trackablesMapper.HydrateTrackables(dataTable);
        }

        public Trackable GetTrackable(int id)
        {
            DataTable dataTable = _trackablesRepository.GetTrackable(id);
            return _trackablesMapper.HydrateTrackables(dataTable).FirstOrDefault();
        }

        public void CreateTrackable(Trackable trackable, string userId)
        {
            _trackablesRepository.CreateTrackable(trackable, userId);
        }

        public void UpdateTrackable(Trackable trackable)
        {
            _trackablesRepository.UpdateTrackable(trackable);
        }

        public void DeleteTrackable(int id)
        {
            _trackablesRepository.DeleteTrackable(id);
        }
    }
}
