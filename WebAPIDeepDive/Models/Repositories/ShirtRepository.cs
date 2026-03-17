namespace WebAPIDeepDive.Models.Repositories
{
    public static class ShirtRepository
    {
        private static List<Shirt> shirts =
            [
            new Shirt { ShirtId = 1, Brand = "Nike", Color = "Blue", Size = 10, Gender = "Men", price = 25.99 },
            new Shirt { ShirtId = 2, Brand = "Adidas", Color = "Black", Size = 8, Gender = "Women", price = 30.00 },
            new Shirt { ShirtId = 3, Brand = "Puma", Color = "White", Size = 12, Gender = "Men", price = 19.50 },
            new Shirt { ShirtId = 4, Brand = "Reebok", Color = "Red", Size = 6, Gender = "Women", price = 22.00 }
            ];

        public static bool ShirtExists(int id)
        {
            return shirts.Any(x => x.ShirtId == id);
        }

        public static Shirt? GetShirtById(int id)
        {
            return shirts.FirstOrDefault(x => x.ShirtId == id);
        }
    }
}
