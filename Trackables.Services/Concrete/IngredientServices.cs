using System.Collections.Generic;
using System.Data;
using System.Linq;
using MyFoodDiary.Data.Abstract;
using MyFoodDiary.Domain;
using MyFoodDiary.Services.Abstract;

namespace MyFoodDiary.Services.Concrete
{
    public class IngredientServices : IIngredientServices
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IIngredientMapper _ingredientMapper;

        public IngredientServices()
        { }

        public IngredientServices(IIngredientRepository ingredientRepository, IIngredientMapper ingredientMapper)
        {
            _ingredientRepository = ingredientRepository;
            _ingredientMapper = ingredientMapper;
        }

        //public IEnumerable<Ingredient> GetIngredients(int userId)
        //{
        //    DataTable dataTable = _ingredientRepository.GetIngredients(userId);
        //    return _ingredientMapper.HydrateIngredients(dataTable);
        //}

        public void CreateIngredient(string code, int mealId)
        {
            _ingredientRepository.CreateIngredient(code, mealId);
        }

        public void DeleteIngredient(int id)
        {
            _ingredientRepository.DeleteIngredient(id);
        }

        public void UpdateIngredient(int id, int quantity)
        {
            _ingredientRepository.UpdateIngredient(id, quantity);
        }

    //public void UpdateIngredient(Ingredient meal)
    //{
    //    _ingredientRepository.UpdateIngredient(meal);
    //}

    //public Ingredient GetIngredient(int id)
    //{
    //    DataTable dataTable = _ingredientRepository.GetIngredient(id);
    //    return _ingredientRepository.HydrateIngredients(dataTable).FirstOrDefault();
    //}


}
}
