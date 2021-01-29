using System;

namespace Trackables.Domain
{
    public class Serving
    {
        public Serving()
        { }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }

        public override bool Equals(Object obj)
        {
            Serving other = obj as Serving;

            if (other == null)
                return false;

            return (this.Id == other.Id) &&
                   (this.Code == other.Code) &&
                   (this.Name == other.Name) &&
                   (this.Quantity == other.Quantity) &&
                   (this.Date == other.Date);
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + Id.GetHashCode();

                if (Code != null)
                    hash = hash * 23 + Code.GetHashCode();

                if (Name != null)
                    hash = hash * 23 + Name.GetHashCode();

                hash = hash * 23 + Quantity.GetHashCode();
                hash = hash * 23 + Date.GetHashCode();

                return hash;
            }
        }

    }
}
