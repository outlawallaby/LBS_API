namespace LBS_API.Model
{
    public class Load
    {
        public int Id { get; set; }
        public string Broker { get; set; }
        public string LoadNumber { get; set; }
        public decimal Price { get; set; }
        public string Shipper { get; set; }
        public string Consignee { get; set; }
        public Unit UnitType { get; set; }
    }
}
