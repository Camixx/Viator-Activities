namespace Viator_practice.Services
{
    public class DataModel
    {
        public Filtering filtering { get; set; }
        public string currency { get; set; }

        public DataModel(int destinationId)
        {
            this.filtering = new Filtering(destinationId);
            this.currency = "USD";
        }
    }

    public class Filtering
    {
        public string destination { get; set; }

        public Filtering(int destination)
        {
            this.destination = destination.ToString();
        }
    }
}




