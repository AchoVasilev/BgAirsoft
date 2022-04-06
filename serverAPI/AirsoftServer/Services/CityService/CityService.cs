namespace Services.CityService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Data;

    using Microsoft.EntityFrameworkCore;

    using ViewModels.City;

    public class CityService : ICityService
    {
        private readonly ApplicationDbContext data;
        private readonly IMapper mapper;

        public CityService(ApplicationDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public async Task<ICollection<CityViewModel>> GetAllCitiesAsync() 
            => await this.data.Cities
                .Where(x => x.IsDeleted == null)
                .ProjectTo<CityViewModel>(this.mapper.ConfigurationProvider)
                .ToListAsync();
    }
}
