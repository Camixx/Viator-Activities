namespace Viator_practice.Models
{
    public class Destination
    {
        public int sortOrder { get; set; }
        public bool selectable { get; set; }
        public string destinationUrlName { get; set; }
        public string defaultCurrencyCode { get; set; }
        public string lookupId { get; set; }
        public int parentId { get; set; }
        public string timeZone { get; set; }
        public string iataCode { get; set; }
        public string destinationName { get; set; }
        public int destinationId { get; set; }
        public string destinationType { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }

        public Destination(int sortOrder, bool selectable, string destinationUrlName, string defaultCurrencyCode, string lookupId, int parentId, string timeZone, string iataCode, string destinationName, int destinationId, string destinationType, float latitude, float longitude)
        {
            this.sortOrder = sortOrder;
            this.selectable = selectable;
            this.destinationUrlName = destinationUrlName;
            this.defaultCurrencyCode = defaultCurrencyCode;
            this.lookupId = lookupId;
            this.parentId = parentId;
            this.timeZone = timeZone;
            this.iataCode = iataCode;
            this.destinationName = destinationName;
            this.destinationId = destinationId;
            this.destinationType = destinationType;
            this.latitude = latitude;
            this.longitude = longitude;
        }
    }
}



