using Microsoft.AspNetCore.Mvc;
using Dapper;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
// KRİTİK: Shared Proje'den Modelleri Çekiyoruz
using RackConfigurationn.Shared.Models;

namespace RackConfigurationn.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IDbConnection _db;

        public DataController(IDbConnection db)
        {
            _db = db;
        }

        // [GET] /api/Data/depth-options-dapper 
        // İŞLEV: Tüm benzersiz derinlikleri çeker
        [HttpGet("depth-options-dapper")]
        public async Task<IActionResult> GetDepthOptionsDapper()
        {
            var sql = "SELECT DISTINCT Depth FROM DeckOptions ORDER BY Depth";
            var depths = await _db.QueryAsync<double>(sql);

            return Ok(depths);
        }

        // [GET] /api/Data/deck-options?depth=X
        // İŞLEV: Seçilen derinliğe ait uyumlu DeckOption'ları çeker.
        [HttpGet("deck-options")]
        public async Task<IActionResult> GetDeckOptions([FromQuery] double depth)
        {
            var sql = "SELECT Id, Depth, DeckType, ImageUrl FROM DeckOptions WHERE Depth=@DepthValue";


            var deckOptions = await _db.QueryAsync<DeckOption>(sql, new { DepthValue = depth });


            if (deckOptions == null || !deckOptions.Any())
            {
                return NotFound("Belirtilen derinlik için kat tipi bulunamadı");
            }


            return Ok(deckOptions);
        }
    }
}
