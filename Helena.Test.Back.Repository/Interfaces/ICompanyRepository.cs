using Helena.Test.Back.Model.DTOs;
using Helena.Test.Back.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helena.Test.Back.Repository.Interfaces
{
    public interface ICompanyRepository
    {
        Task<CompanyEntity> CreateAsync(CompanyDTO companyDTO);
        Task<bool> DeleteAsync(long id);
        Task<List<CompanyEntity>> GetAllAsync();
        Task<CompanyEntity?> GetByIdAsync(long id);
        Task<CompanyEntity?> GetByRazaoSocialAsync(string razaoSocial);
        Task<CompanyEntity> UpdateAsync(long id, CompanyDTO companyDTO);
    }
}
