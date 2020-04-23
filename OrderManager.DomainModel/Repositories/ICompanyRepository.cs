using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.DomainModel.Repositories
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetAllCompanies();
        Task<Company> GetByIdAsync(int companyId);
        Task<Company> GetByName(string name);
        Task CreateNewCompany(Company newCompany);
        Task UpadteCompany(Company company);
    }
}
