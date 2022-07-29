namespace Falcon.Entities
{
    public class AddressCoordinate
    {
        public int Id { get; set; }
        public double? Latitude { get; set; }
        public double? Longtitude { get; set; }
        public string Address { get; set; } = String.Empty;
    }
}
