using Helena.Test.Back.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helena.Test.Back.Service.Interfaces
{
    public interface ICompanyService
    {
        Task<List<CompanyDTO>> GetCompaniesAsync();
        Task<CompanyDTO> GetCompanyAsync(string id);
        Task<CompanyDTO> CreateCompanyAsync(CompanyDTO companyDTO);
        Task<CompanyDTO> UpdateCompanyAsync(string id, CompanyDTO companyDTO);
        Task<bool> DeleteCompanyAsync(string id);
    }
    
}
