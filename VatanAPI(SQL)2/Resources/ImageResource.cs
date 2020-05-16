namespace VatanAPI.Resources
{
    public class ImageResource
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
        public ProductResource Product { get; set; }
    }
}
