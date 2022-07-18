namespace Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    using Models.Base;

    public class Cart : BaseModel<string>
    {
        public Cart()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Guns = new HashSet<Gun>();
        }

        [ForeignKey(nameof(Client))]
        public string ClientId { get; set; }

        public virtual Client Client { get; set; }

        public virtual ICollection<Gun> Guns { get; set; }
    }
}