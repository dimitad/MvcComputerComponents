namespace EF.ComponentData.Migrations
{
    using EF.ComponentData.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EF.ComponentData.DbContexts.ComponentEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EF.ComponentData.DbContexts.ComponentEntities context)
        {
            var categories = new List<ComponentCategory>
            {
                new ComponentCategory { ID = 1, Name = "Processor", CategoryCode = "processor", Position = 1 },
                new ComponentCategory { ID = 2, Name = "Motherboard", CategoryCode = "motherboard", Position = 2 },
                new ComponentCategory { ID = 3, Name = "Memory", CategoryCode = "memory", Position = 3 },
                new ComponentCategory { ID = 4, Name = "Storage", CategoryCode = "storage", Position = 4 },
                new ComponentCategory { ID = 5, Name = "Video Card", CategoryCode = "video-card", Position = 5 },
                new ComponentCategory { ID = 6, Name = "Monitor", CategoryCode = "monitor", Position = 6 },
                new ComponentCategory { ID = 7, Name = "Accessories", CategoryCode = "accessories", Position = 7 },
                new ComponentCategory { ID = 8, Name = "Power Supply", CategoryCode = "power-supply", Position = 8 }
            };

            categories.ForEach(c => context.ComponentCategory.AddOrUpdate(x => x.CategoryCode, c));

            context.ComponentItems.AddOrUpdate(c => new { c.Name, c.Description },
                new ComponentItem { ID = 1, Name = "Intel Core i3", Description = "2.8 Ghz", Price = 199.99m, Rating = 3, ComponentCategory = categories[0] });
            context.ComponentItems.AddOrUpdate(c => new { c.Name, c.Description },
                new ComponentItem { ID = 2, Name = "Intel Core i5", Description = "3.6 Ghz", Price = 299.99m, Rating = 4, ComponentCategory = categories[0] });
            context.ComponentItems.AddOrUpdate(c => new { c.Name, c.Description },
                new ComponentItem { ID = 3, Name = "Intel Core i7", Description = "4.2 Ghz", Price = 399.99m, Rating = 5, ComponentCategory = categories[0] });
            context.ComponentItems.AddOrUpdate(c => new { c.Name, c.Description },
                new ComponentItem { ID = 4, Name = "ASUS", Description = "2 RAM Slots", Price = 79.99m, Rating = 3, ComponentCategory = categories[1] });
            context.ComponentItems.AddOrUpdate(c => new { c.Name, c.Description },
                new ComponentItem { ID = 5, Name = "ASUS", Description = "4 RAM Slots", Price = 99.99m, Rating = 5, ComponentCategory = categories[1] });
            context.ComponentItems.AddOrUpdate(c => new { c.Name, c.Description },
                new ComponentItem { ID = 6, Name = "ASUS", Description = "8 RAM Slots", Price = 129.99m, Rating = 5, ComponentCategory = categories[1] });
            context.ComponentItems.AddOrUpdate(c => new { c.Name, c.Description },
                new ComponentItem { ID = 7, Name = "Kingston", Description = "8 GB", Price = 89.99m, Rating = 3, ComponentCategory = categories[2] });
            context.ComponentItems.AddOrUpdate(c => new { c.Name, c.Description },
                new ComponentItem { ID = 8, Name = "Kingston", Description = "16 GB", Price = 109.99m, Rating = 4, ComponentCategory = categories[2] });
            context.ComponentItems.AddOrUpdate(c => new { c.Name, c.Description },
                new ComponentItem { ID = 9, Name = "Kingston", Description = "32 GB", Price = 119.99m, Rating = 5, ComponentCategory = categories[2] });
            context.ComponentItems.AddOrUpdate(c => new { c.Name, c.Description },
                new ComponentItem { ID = 10, Name = "Western Digital", Description = "250 GB", Price = 59.99m, Rating = 3, ComponentCategory = categories[3] });
            context.ComponentItems.AddOrUpdate(c => new { c.Name, c.Description },
                new ComponentItem { ID = 11, Name = "Western Digital", Description = "500 GB", Price = 69.99m, Rating = 4, ComponentCategory = categories[3] });
            context.ComponentItems.AddOrUpdate(c => new { c.Name, c.Description },
                new ComponentItem { ID = 12, Name = "Western Digital", Description = "1 TB", Price = 81.99m, Rating = 4, ComponentCategory = categories[3] });
            context.ComponentItems.AddOrUpdate(c => new { c.Name, c.Description },
                new ComponentItem { ID = 13, Name = "NVIDIA", Description = "GTX - 1050", Price = 400.99m, Rating = 3, ComponentCategory = categories[4] });
            context.ComponentItems.AddOrUpdate(c => new { c.Name, c.Description },
                new ComponentItem { ID = 14, Name = "NVIDIA", Description = "GTX - 1070", Price = 500.99m, Rating = 4, ComponentCategory = categories[4] });
            context.ComponentItems.AddOrUpdate(c => new { c.Name, c.Description },
                new ComponentItem { ID = 15, Name = "NVIDIA", Description = "GTX - 1080", Price = 600.99m, Rating = 5, ComponentCategory = categories[4] });
            context.ComponentItems.AddOrUpdate(c => new { c.Name, c.Description },
                new ComponentItem { ID = 16, Name = "LG", Description = "1920 x 1080", Price = 219.99m, Rating = 3, ComponentCategory = categories[5] });
            context.ComponentItems.AddOrUpdate(c => new { c.Name, c.Description },
                new ComponentItem { ID = 17, Name = "Samsung", Description = "1920 x 1080", Price = 259.99m, Rating = 5, ComponentCategory = categories[5] });
            context.ComponentItems.AddOrUpdate(c => new { c.Name, c.Description },
                new ComponentItem { ID = 18, Name = "Dell", Description = "3440 x 1440", Price = 309.99m, Rating = 4, ComponentCategory = categories[5] });
            context.ComponentItems.AddOrUpdate(c => new { c.Name, c.Description },
               new ComponentItem { ID = 19, Name = "Master 1", Description = "650W", Price = 19.99m, Rating = 3, ComponentCategory = categories[7] });
            context.ComponentItems.AddOrUpdate(c => new { c.Name, c.Description },
                new ComponentItem { ID = 20, Name = "Master 2", Description = "1000", Price = 92.99m, Rating = 5, ComponentCategory = categories[7] });
            
        }
    }
}   
