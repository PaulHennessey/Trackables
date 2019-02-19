using System.Collections.Generic;
using System.Data;
using Trackables.Domain;

namespace Trackables.Data.Abstract
{
    public interface ITrackablesRepository
    {
        DataTable GetTrackables(int userId);
        DataTable GetTrackable(int id);
        void CreateTrackable(Trackable trackable, int userId);
        void UpdateTrackable(Trackable trackable);
        void DeleteTrackable(int id);
    }
}
