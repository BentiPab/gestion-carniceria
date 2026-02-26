namespace GestionCarniceria.Core.Entities
{
    public class Client : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<Branch> Branches { get; set; } = new List<Branch>();


    }
}
