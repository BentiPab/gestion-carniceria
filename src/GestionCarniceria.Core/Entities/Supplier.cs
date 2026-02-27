namespace GestionCarniceria.Core.Entities
{
    public class Supplier : BaseEntity
    {   
        public string Name { get; set; } = string.Empty;
        public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
        public ICollection<PriceAgreement> PriceList { get; set; } = new List<PriceAgreement>();
    }
}
