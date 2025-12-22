using Microsoft.AspNetCore.Mvc; 
using Microsoft.EntityFrameworkCore; 
using RackConfigurationn.Shared.Models; 
using RackConfigurationn.Repositories; 
using System.Threading.Tasks;
using System.Linq;

namespace RackConfigurationn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RackController : ControllerBase
    {

        private readonly RepositoryContext _context;

        public RackController(RepositoryContext context)
        {
            _context = context;
        }

        [HttpPost]//yeni bir raf konfigürasyonu oluşturmak için kullanılır.

        public async Task<IActionResult> CreateRack([FromBody] Rack rack) //HTTP isteğinin gövdesindeki bir JSON verisini bir Rack nesnesine dönüştürür.
        {
            if (!ModelState.IsValid)//gelen verinin modelle eşleşip eşleşmediğini kontrol eder

            {
                return BadRequest(ModelState);

            }

            _context.Racks.Add(rack);

            await _context.SaveChangesAsync();//veritabanına değişiklikleri asenkron kaydeder

            return CreatedAtAction(nameof(GetRack), new { id = rack.Id }, rack);//işlem başarılı ise oluşturulan kaynağın URL sini döndürür
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRack(int id)//belirli bir Idye sahip rafı çeker
        {
            var rack = await _context.Racks
                .Include(r => r.ShelfUnits)
                .ThenInclude(su => su.Decks)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (rack == null)
            {
                return NotFound();
            }
            return Ok(rack);
        }

        [HttpPut("{id}")]//URL yolunda ID bulunan HTTP Put isteklerini karşılar.

        public async Task<IActionResult> UpdateRack(int id, [FromBody] Rack updatedrack)//güncellenecek kaydın ID si ve yeni veriyi alır
        {
            if (id != updatedrack.Id)
            {
                return BadRequest("geçersiz konfigürasyon kimliği");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //EF Core a ana rack nesnesinin veritabanında değiştiğini belirtir.
            _context.Entry(updatedrack).State = EntityState.Modified;

            foreach (var ShelfUnit in updatedrack.ShelfUnits)
            {
                _context.Entry(ShelfUnit).State = EntityState.Modified;

                foreach (var deck in ShelfUnit.Decks)
                {
                    _context.Entry(deck).State = EntityState.Modified;

                }
            }

            try
            {
                await _context.SaveChangesAsync();//tüm değişikleri veri tabanına kaydet

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RackExists(id))
                {
                    return NotFound();

                }
                else
                {
                    throw;
                }


            }

            return NoContent();
        }
    

        [HttpDelete("{id}")] //silme işlemi

            public async Task<IActionResult> DeleteRack(int id)//belirli bir ID ye ait olan rafı silme 
        {

            var deletedrack=await _context.Racks
                .Include (r => r.ShelfUnits)
                .ThenInclude (su => su.Decks)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (deletedrack == null)
            {
                return NotFound();
            }
            _context.Racks.Remove(deletedrack);//EF core a bu rafın veritabanından silinmek istediğini belirttik.
            await _context.SaveChangesAsync();//silinmek istenen raf dbde silinerek asenkron olarak kaydedilir.

            return NoContent();


        }

        private bool RackExists(int id)
        {
            return _context.Racks.Any(e => e.Id == id);
        }
    }
  
    }
