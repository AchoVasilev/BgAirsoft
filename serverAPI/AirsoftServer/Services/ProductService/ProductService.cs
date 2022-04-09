namespace Services.ProductService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Data;

    using Microsoft.EntityFrameworkCore;

    using Models;
    using Models.Enums;

    using ViewModels.Item.Guns;

    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext data;

        public ProductService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public async Task<int> CreateGunAsync(GunInputModel model, string dealerId, string imageId)
        {
            var dealer = await this.data.Dealers
                .FirstOrDefaultAsync(x => x.Id == dealerId);
            var subCategoryId = await this.data.SubCategories
                .Where(x => x.Name == model.SubCategoryName)
                .Select(x => x.Id)
                .FirstOrDefaultAsync();

            var gun = new Gun()
            {
                Name = model.Name,
                Magazine = model.Magazine,
                Manufacturer = model.Manufacturer,
                Material = model.Material,
                Barrel = model.Barrel,
                Blowback = model.Blowback,
                Capacity = model.Capacity,
                Color = model.Color,
                SubCategoryId = subCategoryId,
                Firing = model.Firing,
                Hopup = model.Hopup,
                Weight = model.Weight,
                Length = model.Length,
                Speed = model.Speed,
                Price = model.Price,
                Propulsion = Enum.Parse<Propulsion>(model.Propulsion),
                Power = model.Power,
                ImageId = imageId,
            };

            dealer.Guns.Add(gun);
            await this.data.SaveChangesAsync();

            return gun.Id;
        }
    }
}
