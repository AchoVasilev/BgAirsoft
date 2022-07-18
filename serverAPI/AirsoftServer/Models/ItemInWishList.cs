namespace Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using Models.Base;

    public class ItemInWishList : BaseModel<string>
    {
        public ItemInWishList()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [ForeignKey(nameof(Gun))]
        public int GunId { get; set; }

        public virtual Gun Gun { get; set; }

        [ForeignKey(nameof(WishList))]
        public string WishListId { get; set; }

        public virtual WishList WishList { get; set; }
    }
}
