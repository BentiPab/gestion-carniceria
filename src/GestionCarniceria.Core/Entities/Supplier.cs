namespace GestionCarniceria.Core.Entities
{
    public class Supplier : BusinessPartner
    {

        public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
    }
}
