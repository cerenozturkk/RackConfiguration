namespace RackConfigurationn.Shared.Models
{
    public class Rack
    {
        public int Id { get; set; }
        public double TotalHeight { get; set; }

        public double  Depth { get; set; }

        public bool IsAddOnRack { get; set; }

        public bool IsDoubleSided { get; set; }

        public DateTime CreatedDateTime { get; set; }
        public double TotalWidth
        {
            get
            {
                // Tüm ünitelerin genişliğini topla
                double totalUnitWidth = ShelfUnits.Sum(u => u.UnitWidth);

                // Toplam Dikme Sayısı (Ünite sayısı + 1 (ilk ve son dikme) + her ünite arası 1 dikme)
                // Basitlik için sadece ünite genişliğini topluyorum, dikme boşluklarını daha sonra dinamik SVG ile yapacağız.
                // Şimdilik sadece ünitelerin genişliğini toplayarak hatayı giderelim.
                return totalUnitWidth;
            }
        }

        //Bir rafın birden çok ünitesi olabilir(1 e çok ilişkisi olduğunu gösterir.)
        public ICollection<ShelfUnit> ShelfUnits { get; set; }




    }
}
