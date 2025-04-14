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
        Task<CompanySingleDTO> GetCompanyAsync(long id);
        Task<CompanyDTO> CreateCompanyAsync(CompanySingleDTO companyDTO);
        Task<CompanyDTO> UpdateCompanyAsync(long id, CompanyPutRquestDTO companyDTO);
        Task<bool> DeleteCompanyAsync(long id);
    }
    
}
