using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Trackables.Data.Abstract;
using Trackables.Domain;
using Trackables.Domain.Extensions;

namespace Trackables.Data.Concrete
{
    public class TrackablesMapper : ITrackablesMapper
    {
        public IEnumerable<Trackable> HydrateTrackables(DataTable dataTable)
        {
            return from DataRow row in dataTable.Rows select new Trackable
            {
                Id = Convert.ToInt32(row["Id"]),
                Name = row["Name"].ToString(),
            };
        }
    }
}