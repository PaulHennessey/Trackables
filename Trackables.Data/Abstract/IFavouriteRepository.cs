using System.Data;

namespace Trackables.Data.Abstract
{
    public interface IFavouriteRepository
    {
        DataTable GetFavourites(int userId);
        void MergeFavourite(int userId, int id, int quantity);
        void DeleteFavourite(int userId, string code);
    }
}
