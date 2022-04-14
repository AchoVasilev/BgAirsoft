namespace Models
{
    using Models.Base;

    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Image : BaseModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string RemoteImageUrl { get; set; }

        public string Url { get; set; }

        public string Name { get; set; }

        public string Extension { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [ForeignKey(nameof(Category))]
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [ForeignKey(nameof(Courier))]
        public int? CourierId { get; set; }

        public virtual Courier Courier { get; set; }
    }
}
