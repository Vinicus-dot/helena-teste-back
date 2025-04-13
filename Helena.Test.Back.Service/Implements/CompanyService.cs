using Helena.Test.Back.Model.DTOs;
using Helena.Test.Back.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helena.Test.Back.Service.Implements
{
    public class CompanyService : ICompanyService
    {
        public Task<CompanyDTO> CreateCompanyAsync(CompanyDTO companyDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCompanyAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CompanyDTO>> GetCompaniesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CompanyDTO> GetCompanyAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<CompanyDTO> UpdateCompanyAsync(string id, CompanyDTO companyDTO)
        {
            throw new NotImplementedException();
        }
    }
}
