using System;

namespace MyFoodDiary.Domain
{
    public class TrackableItem
    {
        public TrackableItem()
        { }

        public int? Id { get; set; }
        public int TrackableId { get; set; }
        public string Name { get; set; }
        public decimal? Quantity { get; set; }

        public override bool Equals(Object obj)
        {
            TrackableItem other = obj as TrackableItem;

            if (other == null)
                return false;

            return (this.Id == other.Id) &&
                   (this.TrackableId == other.TrackableId) &&
                   (this.Name == other.Name) &&
                   (this.Quantity == other.Quantity);
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;

                if (Id != null)
                    hash = hash * 23 + Id.GetHashCode();

                hash = hash * 23 + TrackableId.GetHashCode();

                if (Name != null)
                    hash = hash * 23 + Name.GetHashCode();

                hash = hash * 23 + Quantity.GetHashCode();

                return hash;
            }
        }

    }
}
