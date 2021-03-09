using System;
using System.Linq;
using System.Threading.Tasks;
using Database.Db.Context;
using Model;

namespace DataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                if (!databaseContext.itemsDbSet.Any())
                {
                    Console.WriteLine("Seeding");
                    Seed(databaseContext);
                }
            }
        }
        
        private static async Task Seed(DatabaseContext ctx)
        {
            Item[] items =
            {
                new Item
                {
                    cost = 42,
                    description = "This item is the literal answer to the universe..... or so the legends go",
                    imageName = "42.jpg",
                    nameOfItem = "42"
                },
                new Item
                {
                    cost = 1,
                    description = "Here, take this Duck... it may help you when you are stuck programming",
                    imageName = "duck.jpg",
                    nameOfItem = "Helper Ducki duckius"
                },
                new Item
                {
                    cost = 1986,
                    description = "It's Dangerous to Go Alone! Taaaaake this",
                    imageName = "zwooord.png",
                    nameOfItem = "The Master Sword"
                },
                new Item
                {
                    cost = 5,
                    description = "I used to be an adventurer like you until I took an arrow to the knee",
                    imageName = "arrow.png",
                    nameOfItem = "Guards tale"
                },
                new Item
                {
                    cost = 2007,
                    description = "Dont trust it",
                    imageName = "cake.jpg",
                    nameOfItem = "Cake"
                },
                new Item
                {
                    cost = 1992,
                    description = "The Friendship destroyer 2.0",
                    imageName = "blueTurtle.png",
                    nameOfItem = "Blue shell"
                },
                new Item
                {
                    cost = 1987,
                    description = "The perfect camouflage",
                    imageName = "CardbordBox.jpg",
                    nameOfItem = "Cardboard box"
                }
            };
            foreach (var item in items)
            {
                ctx.itemsDbSet.Add(item);
            }
            ctx.SaveChangesAsync();
        }
    }
}