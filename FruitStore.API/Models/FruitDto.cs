namespace FruitStore.API.Models
{
    public class FruitDto
    {
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public DateTime? DatePicked { get; set; }
        public bool HasSeeds { get; set; }

    }
}
