using System;
using System.Collections.Generic;
using Trackables.Domain;

namespace Trackables.Services.Abstract
{
    public interface IServingServices
    {
        IEnumerable<Serving> GetServings(DateTime dt, string userId);
        IEnumerable<Day> GetDays(DateTime start, DateTime end, string userId);
        Day GetDay(DateTime date, string userId);
        void InsertServing(string code, int quantity, DateTime dt, string userId);
        void UpdateServing(int id, int quantity);
        void DeleteServing(int id);
        //IEnumerable<Favourite> GetFavourites(int userId);
        //void MergeFavourite(int userId, int id, int quantity);
        //void DeleteFavourite(int userId, string code);
    }
}
