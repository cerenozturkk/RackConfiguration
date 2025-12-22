namespace RackConfigurationn.Shared.Models
{
    public class Component
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        public string Material { get; set; }
        public double MaxLoadCapacity { get; set; }
        public bool IsDeck { get; set; }

        public string? DeckType { get; set; }

        public ICollection<Component> Prices { get; set; }//Bir bileşenin birden fazla fiyat kaydı olabilir.
    }
}
