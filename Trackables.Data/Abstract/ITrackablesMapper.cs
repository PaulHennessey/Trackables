using System.Collections.Generic;
using System.Data;
using MyFoodDiary.Domain;

namespace MyFoodDiary.Data.Abstract
{
    public interface ITrackablesMapper
    {
        IEnumerable<Trackable> HydrateTrackables(DataTable dataTable);
    }
}
