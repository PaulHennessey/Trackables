using System;
using System.Collections.Generic;
using System.Linq;

namespace MyFoodDiary.Domain
{
    public class Ingredient
    {
        public int Id { get; set; }
        public int MealId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public override bool Equals(Object obj)
        {
            Ingredient other = obj as Ingredient;

            if (other == null)
                return false;

            return (this.Id == other.Id) &&
                   (this.Code == other.Code);
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + Id.GetHashCode();

                if (Code != null)
                    hash = hash * 23 + Code.GetHashCode();

                return hash;
            }
        }
    }
}
