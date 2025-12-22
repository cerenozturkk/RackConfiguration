namespace RackConfigurationn.Shared.Models
{
    public class ComponentPrice
    {
        public int Id { get; set; }

        public double Price { get; set; }

        public DateTime EffectiveDate { get; set; }

      
        public int? Depth { get; set; }

        public int ComponentId { get; set; }

        public Component? Component { get; set; }
    }
}