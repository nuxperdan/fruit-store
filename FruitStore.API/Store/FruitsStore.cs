using FruitStore.Domain.Items;

namespace FruitStore.API.Store
{
    public class FruitsStore
    {
        private List<Fruit> _fruits;

        public static FruitsStore Instance { get; } = new FruitsStore();

        public FruitsStore()
        {
            Init();
        }

        public IEnumerable<Fruit> GetFruits() {
            return _fruits;
        }

        private void Init()
        {
            _fruits = new List<Fruit>()
            {
                new Banana()
                {
                    Color = "Yellow",
                    HasSeeds = false,
                    Price = 1M,
                    Weight = .25M,
                },
                new Apple()
                {
                    Color = "Green",
                    HasSeeds = true,
                    Price = .75M,
                    Weight = .28M,
                    DatePicked = new DateTime(2023, 11, 20)
                },
                new Apple()
                {
                    Color = "Red",
                    HasSeeds = true,
                    Price = .75M,
                    Weight = .28M,
                    DatePicked = new DateTime(2023, 11, 20)
                },
                new Apple()
                {
                    Color = "Yellow",
                    HasSeeds = true,
                    Price = .75M,
                    Weight = .28M,
                    DatePicked = new DateTime(2023, 11, 20)
                },
                new Banana() {
                    Color = "Yellow",
                    HasSeeds = false,
                    Price = 1.2M,
                    Weight = .30M,
                    DatePicked = new DateTime(2023, 11, 21)
                },
                new Kiwi() {
                    Color = "Green",
                    HasSeeds = false,
                    Price = 1.2M,
                    Weight = .20M,
                    DatePicked = new DateTime(2023, 11, 21)
                },
                new Coconut() {
                    Color = "Brown",
                    HasSeeds = false,
                    Price = 3M,
                    Weight = 1M,
                    DatePicked = new DateTime(2023, 11, 22)
                },
                new Strawberry() {
                    Color = "Red",
                    HasSeeds = true,
                    Price = 0.1M,
                    Weight = 0.01M,
                    DatePicked = new DateTime(2023, 11, 23)
                },
                new Coconut() {
                    Color = "Brown",
                    HasSeeds = false,
                    Price = 3.1M,
                    Weight = 1.1M,
                    DatePicked = new DateTime(2023, 11, 22)
                },
                new Strawberry() {
                    Color = "Red",
                    HasSeeds = true,
                    Price = 0.15M,
                    Weight = 0.05M,
                    DatePicked = new DateTime(2023, 11, 23)
                },
            };  
        }
    }
}
