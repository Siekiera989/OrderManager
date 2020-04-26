using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderManager.DomainModel;
using OrderManager.DomainModel.Repositories;
using OrderManager.Infrastructure.Config;

namespace OrderManager.Infrastructure.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CompanyRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Company>> GetAllCompanies()
            => await _dbContext.Companies.ToListAsync();

        public async Task<Company> GetByIdAsync(int companyId)
            => await Task.FromResult(_dbContext.Companies.SingleOrDefault(x => x.ID == companyId));

        public async Task<Company> GetByName(string name)
            => await Task.FromResult(_dbContext.Companies.SingleOrDefault(x => x.Name == name));

        public async Task CreateNewCompany(Company newCompany)
        {
            await _dbContext.Companies.AddAsync(newCompany);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpadteCompany(Company company)
        {
            _dbContext.Companies.Update(company);
            await _dbContext.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}
