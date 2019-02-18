using System;
using System.Collections.Generic;
using System.Linq;

namespace MyFoodDiary.Domain
{
    public class Trackable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //public override bool Equals(Object obj)
        //{
        //    Product other = obj as Product;

        //    if (other == null)
        //        return false;

        //    return (this.Code == other.Code) &&
        //           (this.Name == other.Name) &&
        //           (this.ProductMacronutrients.ProductNutrients.SequenceEqual(other.ProductMacronutrients.ProductNutrients));
        //}

        //public override int GetHashCode()
        //{
        //    unchecked // Overflow is fine, just wrap
        //    {
        //        int hash = 17;
        //        hash = hash * 23 + Code.GetHashCode();

        //        if (Name != null)
        //            hash = hash * 23 + Name.GetHashCode();

        //        if (ProductMacronutrients.ProductNutrients != null)
        //            hash = hash * 23 + ProductMacronutrients.ProductNutrients.GetHashCode();

        //        return hash;
        //    }
        //}
    }
}
