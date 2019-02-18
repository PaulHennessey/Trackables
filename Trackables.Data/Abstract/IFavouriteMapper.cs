using System.Collections.Generic;
using System.Data;
using MyFoodDiary.Domain;

namespace MyFoodDiary.Data.Abstract
{
    public interface IFavouriteMapper
    {
        IEnumerable<Favourite> HydrateFavourites(DataTable dataTable);
    }
}
