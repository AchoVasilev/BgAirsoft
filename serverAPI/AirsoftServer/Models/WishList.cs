namespace Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    using Models.Base;

    public class WishList : BaseModel<string>
    {
        public WishList()
        {
            this.Id = Guid.NewGuid().ToString();
            this.ItemsInWishList = new HashSet<ItemInWishList>();
        }

        [ForeignKey(nameof(Client))]
        public string ClientId { get; set; }

        public virtual Client Client { get; set; }

        public virtual ICollection<ItemInWishList> ItemsInWishList { get; set; }
    }
}
