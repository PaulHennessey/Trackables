using System.Collections.Generic;
using System.Data;
using Trackables.Domain;

namespace Trackables.Data.Abstract
{
    public interface IIngredientMapper
    {
        IEnumerable<Ingredient> HydrateIngredients(DataTable dataTable);
    }
}
