namespace GestionCarniceria.Core.Entities
{
    public class Branch : BaseEntity
    {
        public int Code { get; set; } 
        public string Name { get; set; } = string.Empty;
        public ICollection<Sale> Sales { get; set; } = new List<Sale>();
        public ICollection<PriceAgreement> PriceList { get; set; } = new List<PriceAgreement>();

        public Client Owner { get; set; } = null!;
        public int OwnerId { get; set; }


    }
}
