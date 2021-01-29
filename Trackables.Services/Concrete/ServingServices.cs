using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Trackables.Data.Abstract;
using Trackables.Domain;
using Trackables.Services.Abstract;

namespace Trackables.Services.Concrete
{
    public class ServingServices : IServingServices
    {
        private readonly IServingRepository _servingRepository;
        private readonly IServingMapper _servingMapper;
        private readonly IFavouriteRepository _favouriteRepository;
        private readonly IFavouriteMapper _favouriteMapper;


        public ServingServices()
        { }


        public ServingServices(IServingRepository servingRepository, IServingMapper servingMapper, IFavouriteRepository favouriteRepository, IFavouriteMapper favouriteMapper)
        {
            _servingRepository = servingRepository;
            _servingMapper = servingMapper;
            _favouriteRepository = favouriteRepository;
            _favouriteMapper = favouriteMapper;
        }

        public IEnumerable<Serving> GetServings(DateTime dt, string userId)
        {
            DataTable servings = _servingRepository.GetServings(dt, userId);
            return _servingMapper.HydrateServings(servings);
        }

        public Day GetDay(DateTime dt, string userId)
        {
            return new Day()
            {
                Date = dt,
                Food = _servingMapper.HydrateServings(_servingRepository.GetServings(dt, userId)).ToList()
            };
        }

        public IEnumerable<Day> GetDays(DateTime start, DateTime end, string userId)
        {
            var days = new List<Day>();

            while (start <= end)
            {
                days.Add(GetDay(start, userId));
                start = start.AddDays(1);
            }
            return days;
        }

        public void InsertServing(string code, int quantity, DateTime dt, int userId)
        {
            _servingRepository.InsertServing(code, quantity, dt, userId);
        }

        public void InsertServing(string code, int quantity, DateTime dt, string userId)
        {
            _servingRepository.InsertServing(code, quantity, dt, userId);
        }

        public void UpdateServing(int id, int quantity)
        {
            _servingRepository.UpdateServing(id, quantity);
        }


        public void DeleteServing(int id)
        {
            _servingRepository.DeleteServing(id);
        }


        public IEnumerable<Favourite> GetFavourites(int userId)
        {
            DataTable favourites = _favouriteRepository.GetFavourites(userId);
            return _favouriteMapper.HydrateFavourites(favourites);
        }


        public void MergeFavourite(int userId, int id, int quantity)
        {
            _favouriteRepository.MergeFavourite(userId, id, quantity);
        }


        public void DeleteFavourite(int userId, string code)
        {
            _favouriteRepository.DeleteFavourite(userId, code);
        }
    }
}
