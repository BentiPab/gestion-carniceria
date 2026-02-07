namespace GestionCarniceria.Core.Entities
{
    public class BusinessPartner : BaseEntity
    {

        public string Name { get; set; } = string.Empty;

        public ICollection<PriceList> PriceLists { get; set; } = new List<PriceList>();
    }
}
