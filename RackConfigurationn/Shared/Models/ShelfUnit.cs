using System.Text.Json.Serialization;

namespace RackConfigurationn.Shared.Models
{
    public class ShelfUnit
    {
        public int Id { get; set; }

        public double Height { get; set; }

        public double UnitWidth { get; set; }

        public int NumberOfDecks { get; set; }

        public int OrderIndex { get; set; }
        public int Depth { get; set; }

        // Foreign Key (Yabancı Anahtar)
        // Bu, ShelfUnit'in hangi Rack'e ait olduğunu gösterir
        public int RackId { get; set; }

        // Navigation Property (Gezinme Özelliği)
        // Bu, EF Core'un ilişkili Rack nesnesine erişmesini sağlar
        [JsonIgnore]
        public Rack? Rack { get; set; }

        // İlişki: Bir raf ünitesinin birden fazla katı olabilir
        public ICollection<Deck> Decks { get; set; }


    }
}
