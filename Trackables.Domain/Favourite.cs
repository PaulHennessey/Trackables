using System;

namespace MyFoodDiary.Domain
{
    public class Favourite
    {
        public Favourite()
        { }

        public Favourite(string code, string name, int quantity)
        {
            Code = code;
            Name = name;
            Quantity = quantity;
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public override bool Equals(Object obj)
        {
            Favourite other = obj as Favourite;

            if (other == null)
                return false;

            return (this.Code == other.Code) &&
                   (this.Name == other.Name) &&
                   (this.Quantity == other.Quantity);
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;

                if (Code != null)
                    hash = hash * 23 + Code.GetHashCode();

                if (Name != null)
                    hash = hash * 23 + Name.GetHashCode();

                hash = hash * 23 + Quantity.GetHashCode();

                return hash;
            }
        }

    }
}
