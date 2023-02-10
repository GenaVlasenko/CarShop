namespace CarShop.Domain.Layer
{
    public class Car
    {
        public int Id { get; set; }
        public string Picture { get; set; }
        public string CarName { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Color { get; set; }
        public string Engine { get; set; }
        public string TypeofCar { get; set; }
        public string Transmission { get; set; }
        public string Mileage { get; set; }
        public string CarAccident { get; set; }
        public string CarInStock { get; set; }
        public decimal Price { get; set; }
        public int SaleId { get; set; }
        public int CategoryId { get; set; }
    }
}
