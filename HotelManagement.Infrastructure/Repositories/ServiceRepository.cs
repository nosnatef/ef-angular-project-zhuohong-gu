using HotelManagement.Core.Entities;
using HotelManagement.Core.RepositoryInterfaces;
using HotelManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Infrastructure.Repositories
{
    public class ServiceRepository : EfRepository<Service>, IServiceRepository
    {

        public ServiceRepository(HotelManagementDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Service>> GetServices()
        {
            var services = await _dbContext.Services.ToListAsync();
            return services;
        }

        public override async Task<Service> GetByIdAsync(int id)
        {
            var service = await _dbContext.Services.FirstOrDefaultAsync(c => c.Id == id);
            if (service == null) return null;
            return service;
        }
    }
}
