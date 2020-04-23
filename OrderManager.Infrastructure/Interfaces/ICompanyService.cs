using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManager.DomainModel;
using OrderManager.Infrastructure.DTO;

namespace OrderManager.Infrastructure.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDto>> GetAllCompanies();
        Task<CompanyDto> GetByIdAsync(int companyId);
        Task CreateNewCompany(Company newCompany);
        Task UpadteCompany(Company company);
    }
}
