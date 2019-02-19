using System.Collections.Generic;
using System.Data;
using Trackables.Domain;

namespace Trackables.Data.Abstract
{
    public interface ITrackablesMapper
    {
        IEnumerable<Trackable> HydrateTrackables(DataTable dataTable);
    }
}
