using System.Text.Json.Serialization;

namespace RackConfigurationn.Shared.Models
{
    public class Deck
    {

        public int Id { get; set; }
        public string DeckType { get; set; }

        public int level { get; set; }

        public int ShelfUnitId { get; set; }

        [JsonIgnore]

        public ShelfUnit? ShelfUnit { get; set; }
    }
}
