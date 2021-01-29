using System.Collections.Generic;
using System.Data;
using Trackables.Domain;

namespace Trackables.Data.Abstract
{
    public interface IServingMapper
    {
        IEnumerable<Serving> HydrateServings(DataTable dataTable);
    }
}
