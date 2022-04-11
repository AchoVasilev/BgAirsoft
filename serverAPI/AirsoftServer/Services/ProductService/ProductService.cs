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

        public async Task<ICollection<AllGunViewModel>> GetAllGunsAsync()
            => await this.data.Guns
                        .Where(x => x.IsDeleted == null)
                        .OrderBy(x => x.CreatedOn)
                        .ProjectTo<AllGunViewModel>(this.mapper.ConfigurationProvider)
                        .ToListAsync();

        public async Task<ICollection<AllGunViewModel>> FilterGunsByManufacturerAsync(List<string> query)
            => await this.data.Guns
                    .Where(x => query.Contains(x.Manufacturer) && x.IsDeleted == null)
                    .ProjectTo<AllGunViewModel>(this.mapper.ConfigurationProvider)
                    .ToListAsync();

        public async Task<ICollection<AllGunViewModel>> FilterGunsByDealerAsync(List<string> query)
            => await this.data.Guns
                    .Where(x => query.Contains(x.Dealer.Name) && x.IsDeleted == null)
                    .ProjectTo<AllGunViewModel>(this.mapper.ConfigurationProvider)
                    .ToListAsync();

        public async Task<ICollection<AllGunViewModel>> FilterGunsByColorAsync(List<string> query)
            => await this.data.Guns
                    .Where(x => query.Contains(x.Color) && x.IsDeleted == null)
                    .ProjectTo<AllGunViewModel>(this.mapper.ConfigurationProvider)
                    .ToListAsync();

        public async Task<ICollection<AllGunViewModel>> FilterGunsByPowerAsync(GunQueryModel query)
            => await this.QueryGuns(query)
                    .ProjectTo<AllGunViewModel>(this.mapper.ConfigurationProvider)
                    .ToListAsync();

        public async Task<ICollection<AllGunViewModel>> FilterGunsByCategoryAsync(GunQueryModel query)
            => await this.QueryGuns(query)
                    .ProjectTo<AllGunViewModel>(this.mapper.ConfigurationProvider)
                    .ToListAsync();

        public async Task<ICollection<AllGunViewModel>> OrderGuns(GunSortModel model)
            => await this.QuerySortGuns(model)
                        .ProjectTo<AllGunViewModel>(this.mapper.ConfigurationProvider)
                        .ToListAsync();

        private IQueryable<Gun> QuerySortGuns(GunSortModel query)
        {
            var gunsQuery = this.data.Guns
                .Where(x => x.IsDeleted == null);

            if (string.IsNullOrWhiteSpace(query.CategoryName) == false && query.CategoryName != "null")
            {
                gunsQuery = gunsQuery.Where(x => x.SubCategory.Name == query.CategoryName);
            }

            if (string.IsNullOrWhiteSpace(query.OrderBy) == false && query.OrderBy != "null")
            {
                switch (query.OrderBy)
                {
                    case "alphabetical":
                        gunsQuery = gunsQuery.OrderBy(x => x.Name);
                        break;
                    case "priceDown":
                        gunsQuery = gunsQuery.OrderByDescending(x => x.Price);
                        break;
                    case "priceUp":
                        gunsQuery = gunsQuery.OrderBy(x => x.Price);
                        break;
                    default:
                        break;
                }
            }

            if (query.Count != null)
            {
                gunsQuery = gunsQuery.Take((int)query.Count);
            }

            return gunsQuery;
        }

        private IQueryable<Gun> QueryGuns(GunQueryModel query)
        {
            var gunsQuery = this.data.Guns
                .Where(x => x.IsDeleted == null);

            if (query.Manufacturers != null)
            {
                gunsQuery = gunsQuery
                    .Where(x => query.Manufacturers.Contains(x.Manufacturer));
            }

            if (query.Dealers != null)
            {
                gunsQuery = gunsQuery
                    .Where(x => query.Dealers.Contains(x.Dealer.Name));
            }

            if (query.Colors != null)
            {
                gunsQuery = gunsQuery.Where(x => query.Colors.Contains(x.Color));
            }

            if (query.Powers != null)
            {
                gunsQuery = gunsQuery.Where(x => query.Powers.Contains(x.Power));
            }

            if (string.IsNullOrWhiteSpace(query.CategoryName) == false && query.CategoryName != "null")
            {
                gunsQuery = gunsQuery.Where(x => x.SubCategory.Name == query.CategoryName);
            }

            return gunsQuery;
        }
    }
}
