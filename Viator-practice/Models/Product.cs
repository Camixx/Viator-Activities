using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Viator_practice.Models;

public class Product
{
    [Key]
    public string productCode { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public string image { get; set; }
    public float pricing { get; set; }
    public string productUrl { get; set; }
    public int destinationId { get; set; }
    public float rating { get; set; }
    [ForeignKey("destinationId")]
    public virtual Destination Destination { get; set; }


    public Product(string productCode, string title, string description, string image, float pricing, string productUrl, int destinationId, float rating)
    {
        this.productCode = productCode;
        this.title = title;
        this.description = description;
        this.image = image;
        this.pricing = pricing;
        this.productUrl = productUrl;
        this.destinationId = destinationId;
        this.rating = rating;
    }

    public Product()
    {
    }
}

