using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RackConfigurationn.Shared.Models;

namespace RackConfigurationn.Repositories
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
        }

        public DbSet<Rack> Racks { get; set; }
        public DbSet<ShelfUnit> ShelfUnits { get; set; }
        public DbSet<Deck> Decks { get; set; }
        public DbSet<DeckOption> DeckOptions { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<ComponentPrice> ComponentPrices { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // --- RELATIONSHIP DEFINITIONS ---
            modelBuilder.Entity<Rack>()
                .HasMany(r => r.ShelfUnits)
                .WithOne(su => su.Rack)
                .HasForeignKey(su => su.RackId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ShelfUnit>()
                .HasMany(su => su.Decks)
                .WithOne(d => d.ShelfUnit)
                .HasForeignKey(d => d.ShelfUnitId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ComponentPrice>()
                .HasOne(cp => cp.Component)
                .WithMany()
                .HasForeignKey(cp => cp.ComponentId)
                .OnDelete(DeleteBehavior.Cascade);


            // --- DECK OPTION SEED DATA (Visual Options for UI) ---
            modelBuilder.Entity<DeckOption>().HasData(
                // 40 cm
                new DeckOption { Id = 1, Depth = 40, DeckType = "Without layers", ImageUrl = "/imagesdecktypes/withoutlayers.jpg" },
                new DeckOption { Id = 2, Depth = 40, DeckType = "With wooden deck", ImageUrl = "/imagesdecktypes/woodendeck.jpg" },
                new DeckOption { Id = 3, Depth = 40, DeckType = "With steel deck", ImageUrl = "/imagesdecktypes/steeldeck.jpg" },

                // 50 cm
                new DeckOption { Id = 4, Depth = 50, DeckType = "Without layers", ImageUrl = "/imagesdecktypes/withoutlayers.jpg" },
                new DeckOption { Id = 5, Depth = 50, DeckType = "With wooden deck", ImageUrl = "/imagesdecktypes/woodendeck.jpg" },
                new DeckOption { Id = 6, Depth = 50, DeckType = "With steel deck", ImageUrl = "/imagesdecktypes/steeldeck.jpg" },

                // 60 cm
                new DeckOption { Id = 7, Depth = 60, DeckType = "Without layers", ImageUrl = "/imagesdecktypes/withoutlayers.jpg" },
                new DeckOption { Id = 8, Depth = 60, DeckType = "With wooden deck", ImageUrl = "/imagesdecktypes/woodendeck.jpg" },
                new DeckOption { Id = 9, Depth = 60, DeckType = "With steel deck", ImageUrl = "/imagesdecktypes/steeldeck.jpg" },
                new DeckOption { Id = 10, Depth = 60, DeckType = "With galvanised mesh deck", ImageUrl = "/imagesdecktypes/galvaniseddeck.jpg" },
                new DeckOption { Id = 11, Depth = 60, DeckType = "Inclined deck", ImageUrl = "/imagesdecktypes/inclineddeck.jpg" },
                new DeckOption { Id = 12, Depth = 60, DeckType = "Multiplex board", ImageUrl = "/imagesdecktypes/multiplexdeck.jpg" },

                // 80 cm
                new DeckOption { Id = 13, Depth = 80, DeckType = "Without layers", ImageUrl = "/imagesdecktypes/withoutlayers.jpg" },
                new DeckOption { Id = 14, Depth = 80, DeckType = "With wooden deck", ImageUrl = "/imagesdecktypes/woodendeck.jpg" },
                new DeckOption { Id = 15, Depth = 80, DeckType = "With steel deck", ImageUrl = "/imagesdecktypes/steeldeck.jpg" },
                new DeckOption { Id = 16, Depth = 80, DeckType = "With galvanised mesh deck", ImageUrl = "/imagesdecktypes/galvaniseddeck.jpg" },
                new DeckOption { Id = 17, Depth = 80, DeckType = "Inclined deck", ImageUrl = "/imagesdecktypes/inclineddeck.jpg" },
                new DeckOption { Id = 18, Depth = 80, DeckType = "Multiplex board", ImageUrl = "/imagesdecktypes/multiplexdeck.jpg" },

                // 100 cm
                new DeckOption { Id = 19, Depth = 100, DeckType = "Without layers", ImageUrl = "/imagesdecktypes/withoutlayers.jpg" },
                new DeckOption { Id = 20, Depth = 100, DeckType = "With wooden deck", ImageUrl = "/imagesdecktypes/woodendeck.jpg" },
                new DeckOption { Id = 21, Depth = 100, DeckType = "With steel deck", ImageUrl = "/imagesdecktypes/steeldeck.jpg" },

                // 120 cm
                new DeckOption { Id = 22, Depth = 120, DeckType = "Without layers", ImageUrl = "/imagesdecktypes/withoutlayers.jpg" },
                new DeckOption { Id = 23, Depth = 120, DeckType = "With wooden deck", ImageUrl = "/imagesdecktypes/woodendeck.jpg" },
                new DeckOption { Id = 24, Depth = 120, DeckType = "With steel deck", ImageUrl = "/imagesdecktypes/steeldeck.jpg" },
                new DeckOption { Id = 25, Depth = 120, DeckType = "With galvanised mesh deck", ImageUrl = "/imagesdecktypes/galvaniseddeck.jpg" }
            );

            // --- COMPONENT SEED DATA (Product Definitions) ---
            modelBuilder.Entity<Component>().HasData(
                // Uprights (Posts) - Various Heights
                // 3.5m (Existing)
                new Component { Id = 1, Name = "Ana Dikme (3.5m)", Category = "Upright", Material = "Çelik", MaxLoadCapacity = 1000, IsDeck = false, DeckType = null },
                new Component { Id = 2, Name = "Yan Dikme (3.5m)", Category = "Upright", Material = "Çelik", MaxLoadCapacity = 1000, IsDeck = false, DeckType = null },

                // 2.0m (New)
                new Component { Id = 30, Name = "Ana Dikme (2m)", Category = "Upright", Material = "Çelik", MaxLoadCapacity = 800, IsDeck = false, DeckType = null },
                new Component { Id = 31, Name = "Yan Dikme (2m)", Category = "Upright", Material = "Çelik", MaxLoadCapacity = 800, IsDeck = false, DeckType = null },

                // 2.5m (New)
                new Component { Id = 32, Name = "Ana Dikme (2.5m)", Category = "Upright", Material = "Çelik", MaxLoadCapacity = 900, IsDeck = false, DeckType = null },
                new Component { Id = 33, Name = "Yan Dikme (2.5m)", Category = "Upright", Material = "Çelik", MaxLoadCapacity = 900, IsDeck = false, DeckType = null },

                // 3.0m (New)
                new Component { Id = 34, Name = "Ana Dikme (3m)", Category = "Upright", Material = "Çelik", MaxLoadCapacity = 1000, IsDeck = false, DeckType = null },
                new Component { Id = 35, Name = "Yan Dikme (3m)", Category = "Upright", Material = "Çelik", MaxLoadCapacity = 1000, IsDeck = false, DeckType = null },


                // Beams
                new Component { Id = 3, Name = "Kiriş (220cm)", Category = "Beam", Material = "Çelik", MaxLoadCapacity = 500, IsDeck = false, DeckType = null },
                new Component { Id = 4, Name = "Kiriş (110cm)", Category = "Beam", Material = "Çelik", MaxLoadCapacity = 250, IsDeck = false, DeckType = null },

                // Decks (Panels)
                new Component { Id = 5, Name = "Ahşap Kapak", Category = "Panel", Material = "Ahşap", MaxLoadCapacity = 300, IsDeck = true, DeckType = "With wooden deck" },
                new Component { Id = 6, Name = "Çelik Kapak", Category = "Panel", Material = "Çelik", MaxLoadCapacity = 350, IsDeck = true, DeckType = "With steel deck" },
                new Component { Id = 7, Name = "Galvanizli Izgara", Category = "Panel", Material = "Galvaniz", MaxLoadCapacity = 400, IsDeck = true, DeckType = "With galvanised mesh deck" },
                new Component { Id = 8, Name = "Eğimli Kapak", Category = "Panel", Material = "Çelik", MaxLoadCapacity = 100, IsDeck = true, DeckType = "Inclined deck" },
                new Component { Id = 9, Name = "Multiplex Pano", Category = "Panel", Material = "Kompozit", MaxLoadCapacity = 300, IsDeck = true, DeckType = "Multiplex board" },
                new Component { Id = 10, Name = "Katman Yok", Category = "Panel", Material = "Yok", MaxLoadCapacity = 0, IsDeck = true, DeckType = "Without layers" }
            );


           
            var today = new DateTime(2025, 10, 24);

            modelBuilder.Entity<ComponentPrice>().HasData(
               

                // 3.5m Prices
                new ComponentPrice { Id = 1, ComponentId = 1, Price = 55.00, Depth = null, EffectiveDate = today }, // Main Upright 3.5m
                new ComponentPrice { Id = 2, ComponentId = 2, Price = 50.00, Depth = null, EffectiveDate = today }, // Side Upright 3.5m

                // 2.0m Prices
                new ComponentPrice { Id = 30, ComponentId = 30, Price = 35.00, Depth = null, EffectiveDate = today }, // Main Upright 2m
                new ComponentPrice { Id = 31, ComponentId = 31, Price = 30.00, Depth = null, EffectiveDate = today }, // Side Upright 2m

                // 2.5m Prices
                new ComponentPrice { Id = 32, ComponentId = 32, Price = 42.00, Depth = null, EffectiveDate = today }, // Main Upright 2.5m
                new ComponentPrice { Id = 33, ComponentId = 33, Price = 38.00, Depth = null, EffectiveDate = today }, // Side Upright 2.5m

                // 3.0m Prices
                new ComponentPrice { Id = 34, ComponentId = 34, Price = 48.00, Depth = null, EffectiveDate = today }, // Main Upright 3m
                new ComponentPrice { Id = 35, ComponentId = 35, Price = 44.00, Depth = null, EffectiveDate = today }, // Side Upright 3m


                // Beams
                new ComponentPrice { Id = 3, ComponentId = 3, Price = 30.00, Depth = null, EffectiveDate = today }, // Beam 220
                new ComponentPrice { Id = 4, ComponentId = 4, Price = 15.00, Depth = null, EffectiveDate = today }, // Beam 110

                // 2. WOODEN DECK (ComponentId: 5)
                new ComponentPrice { Id = 5, ComponentId = 5, Price = 18.00, Depth = 40, EffectiveDate = today },
                new ComponentPrice { Id = 6, ComponentId = 5, Price = 22.00, Depth = 50, EffectiveDate = today },
                new ComponentPrice { Id = 7, ComponentId = 5, Price = 26.00, Depth = 60, EffectiveDate = today },
                new ComponentPrice { Id = 8, ComponentId = 5, Price = 34.00, Depth = 80, EffectiveDate = today },
                new ComponentPrice { Id = 9, ComponentId = 5, Price = 42.00, Depth = 100, EffectiveDate = today },
                new ComponentPrice { Id = 10, ComponentId = 5, Price = 50.00, Depth = 120, EffectiveDate = today },

                // 3. STEEL DECK (ComponentId: 6)
                new ComponentPrice { Id = 11, ComponentId = 6, Price = 25.00, Depth = 40, EffectiveDate = today },
                new ComponentPrice { Id = 12, ComponentId = 6, Price = 30.00, Depth = 50, EffectiveDate = today },
                new ComponentPrice { Id = 13, ComponentId = 6, Price = 35.00, Depth = 60, EffectiveDate = today },
                new ComponentPrice { Id = 14, ComponentId = 6, Price = 45.00, Depth = 80, EffectiveDate = today },
                new ComponentPrice { Id = 15, ComponentId = 6, Price = 55.00, Depth = 100, EffectiveDate = today },
                new ComponentPrice { Id = 16, ComponentId = 6, Price = 65.00, Depth = 120, EffectiveDate = today },

                // 4. GALVANISED MESH (ComponentId: 7)
                new ComponentPrice { Id = 17, ComponentId = 7, Price = 35.00, Depth = 60, EffectiveDate = today },
                new ComponentPrice { Id = 18, ComponentId = 7, Price = 45.00, Depth = 80, EffectiveDate = today },
                new ComponentPrice { Id = 19, ComponentId = 7, Price = 65.00, Depth = 120, EffectiveDate = today },

                // 5. OTHERS
                new ComponentPrice { Id = 20, ComponentId = 8, Price = 22.00, Depth = null, EffectiveDate = today }, // Inclined
                new ComponentPrice { Id = 21, ComponentId = 9, Price = 28.00, Depth = null, EffectiveDate = today }, // Multiplex
                new ComponentPrice { Id = 22, ComponentId = 10, Price = 0.00, Depth = null, EffectiveDate = today }  // No Layer
            );

            modelBuilder.Entity<User>().HasData(
                 new User
                 {
                     Id = 1,
                     Username = "admin",
                     Email = "admin@rack.com",
                     Password = "123",
                     Role = "Admin",
                     FirstName = "Sistem",
                     LastName = "Yöneticisi",
                     CreatedDate = new DateTime(2025, 1, 1)
                 },
                new User
                {
                    Id = 2,
                    Username = "ceren",
                    Email = "ceren@rack.com",
                    Password = "password",
                    Role = "Customer",
                    FirstName = "Ceren",
                    LastName = "Öztürk",
                    CreatedDate = new DateTime(2025, 2, 3)
                }
                );
        }
    }
}