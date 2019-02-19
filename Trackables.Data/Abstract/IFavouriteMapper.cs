using System.Collections.Generic;
using System.Data;
using Trackables.Domain;

namespace Trackables.Data.Abstract
{
    public interface IFavouriteMapper
    {
        IEnumerable<Favourite> HydrateFavourites(DataTable dataTable);
    }
}
