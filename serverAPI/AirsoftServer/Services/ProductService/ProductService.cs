namespace Services.ProductService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Data;

    using Microsoft.EntityFrameworkCore;

    using Models;
    using Models.Enums;

    using ViewModels.Item.Guns;

    using static GlobalConstants.Constants;

    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext data;
        private readonly IMapper mapper;

        public ProductService(ApplicationDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
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

        public async Task<ICollection<GunViewModel>> GetNewestEightGunsAsync()
            => await this.data.Guns
                        .Where(x => x.IsDeleted == null)
                        .OrderBy(x => x.CreatedOn)
                        .Take(DataConstants.PopularItemsCount)
                        .ProjectTo<GunViewModel>(this.mapper.ConfigurationProvider)
                        .ToListAsync();

        public async Task<ICollection<AllGunViewModel>> GetAllGuns()
            => await this.data.Guns
                        .Where(x => x.IsDeleted == null)
                        .OrderBy(x => x.CreatedOn)
                        .ProjectTo<AllGunViewModel>(this.mapper.ConfigurationProvider)
                        .ToListAsync();
    }
}
