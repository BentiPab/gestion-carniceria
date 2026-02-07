namespace GestionCarniceria.Core.Entities
{
    public class Client : BusinessPartner
    {
        public int Code { get; set; }
        public ICollection<Sale> Sales { get; set; } = new List<Sale>();


    }
}
