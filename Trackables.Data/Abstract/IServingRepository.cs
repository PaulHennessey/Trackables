using System;
using System.Data;

namespace Trackables.Data.Abstract
{
    public interface IServingRepository
    {
        DataTable GetServings(DateTime dt, string userId);
        void InsertServing(string code, int quantity, DateTime dt, int userId);
        void InsertServing(string code, int quantity, DateTime dt, string userId);
        void UpdateServing(int id, int quantity);
        void DeleteServing(int id);
    }
}
