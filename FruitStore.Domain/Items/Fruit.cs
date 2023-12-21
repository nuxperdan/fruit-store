namespace FruitStore.Domain.Items
{
    public abstract class Fruit
    {
        protected bool _edible = false;

        public Fruit() : this(-1)
        {

        }

        public Fruit(string name) : this()
        {
            Name = name;
        }

        public Fruit(int id)
        {
            Id = id;
            Name = string.Empty;
            Weight = 0;
            Color = string.Empty;
            Price = 0;
            DatePicked = null;
            HasSeeds = false;
        }

        public int Id { get; }
        public string Name { get; private set; }
        public decimal Weight { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public DateTime? DatePicked { get; set; }
        public bool HasSeeds { get; set; }

        public virtual void MakeEdible()
        {
            _edible = true;
        }
    }
}