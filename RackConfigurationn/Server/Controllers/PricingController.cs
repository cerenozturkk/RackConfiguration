using Microsoft.AspNetCore.Mvc;
using RackConfigurationn.Shared.Models;
using Microsoft.Data.SqlClient;
using Dapper;

namespace RackConfigurationn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingController : ControllerBase
    {
        private readonly IConfiguration _config;

        public PricingController(IConfiguration config)
        {
            _config = config;
        }

        // Helper class to map data from the database (DTO)
        private class ComponentPriceDto
        {
            public string Name { get; set; }
            public double Price { get; set; }
            public int? Depth { get; set; } // Nullable int
        }

        [HttpPost("calculate")]
        public async Task<IActionResult> CalculatePrice([FromBody] Rack rackDraft)
        {
           
            if (rackDraft == null || !rackDraft.ShelfUnits.Any())
            {
                return BadRequest("Konfigürasyon taslağı boş olamaz.");
            }

            var connectionString = _config.GetConnectionString("sqlConnection");

           
            var sql = @"
                SELECT c.Name, cp.Price, cp.Depth 
                FROM Components c 
                JOIN ComponentPrices cp ON c.Id = cp.ComponentId";

            using var connection = new SqlConnection(connectionString);

         
            var allPrices = (await connection.QueryAsync<ComponentPriceDto>(sql)).ToList();

            double totalPrice = 0;

          
            foreach (var unit in rackDraft.ShelfUnits)
            {
               
                int currentDepth = unit.Depth;
                string uprightName = unit.Height switch
                {
                    200 => "Ana Dikme (2m)",
                    250 => "Ana Dikme (2.5m)",
                    300 => "Ana Dikme (3m)",
                    _ => "Ana Dikme (3.5m)" // Default
                };

                
                var upright = allPrices.FirstOrDefault(p => p.Name == uprightName && p.Depth == null);

                if (upright != null)
                {
                    totalPrice += upright.Price * 2; 
                }

                // 2. BEAMS (Kirişler)
              
                string beamName = unit.UnitWidth == 220 ? "Kiriş (220cm)" : "Kiriş (110cm)";
                var beam = allPrices.FirstOrDefault(p => p.Name == beamName && p.Depth == null);

                if (beam != null)
                {
                    totalPrice += beam.Price * (unit.NumberOfDecks * 2);
                }


                foreach (var deck in unit.Decks)
                {
                    string componentName = deck.DeckType switch
                    {
                        "With wooden deck" => "Ahşap Kapak",
                        "With steel deck" => "Çelik Kapak",
                        "With galvanised mesh deck" => "Galvanizli Izgara",
                        "Inclined deck" => "Eğimli Kapak",
                        "Multiplex board" => "Multiplex Pano",
                        "Without layers" => "Katman Yok",
                        _ => null
                    };

                    if (componentName != null)
                    {
                       
                        var matchingPrice = allPrices.FirstOrDefault(p =>
                            p.Name == componentName &&
                            p.Depth == currentDepth 
                        );

                        if (matchingPrice != null)
                        {
                            totalPrice += matchingPrice.Price;
                        }
                    }
                }
            }

            return Ok(new { TotalPrice = Math.Round(totalPrice, 2) });
        }
    }
}