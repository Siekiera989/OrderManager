using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OrderManager.DomainModel;
using OrderManager.DomainModel.Repositories;
using OrderManager.Infrastructure.Config;
using OrderManager.Infrastructure.DTO;
using OrderManager.Infrastructure.Interfaces;

namespace OrderManager.Infrastructure.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
            _mapper = MapperConfig.Initialize();
        }
        public async Task<IEnumerable<CompanyDto>> GetAllCompanies()
        {
            var companies = await _companyRepository.GetAllCompanies();
            return _mapper.Map<IEnumerable<CompanyDto>>(companies);
        }

        public async Task<CompanyDto> GetByIdAsync(int companyId)
        {
            var company = await _companyRepository.GetByIdAsync(companyId);
            return _mapper.Map<CompanyDto>(company);
        }

        public async Task CreateNewCompany(Company newCompany)
        {
            var company = await _companyRepository.GetByName(newCompany.Name);
            if (company != null) throw new Exception($"Company named: '{newCompany.Name}' already exists");

            company = new Company(newCompany.Name,
                newCompany.Country,
                newCompany.City,
                newCompany.Street,
                newCompany.ZipCode);

            await _companyRepository.CreateNewCompany(company);
        }

        public async Task UpadteCompany(Company company)
        {
            var comp = await _companyRepository.GetByIdAsync(company.ID);

            if (comp.Name != company.Name) comp.SetName(company.Name);
            if (comp.City != company.City || comp.Country != company.Country || comp.Street != company.Street || comp.ZipCode != company.ZipCode)
                comp.SetAdress(company.Country,company.City,company.Street,company.ZipCode);

            await _companyRepository.UpadteCompany(comp);
        }
    }
}
