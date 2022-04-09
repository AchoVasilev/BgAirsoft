﻿namespace Services.ProductService
{
    using System.Threading.Tasks;

    using ViewModels.Item.Guns;

    public interface IProductService
    {
         Task<int> CreateGunAsync(GunInputModel model, string dealerId, string imageId);
    }
}
