using Helena.Test.Back.Model.DTOs;
using Helena.Test.Back.Model.Entitys;
using Helena.Test.Back.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helena.Test.Back.Repository.Implements
{
    public class CompanyRepository : ICompanyRepository
    {
        public Task<CompanyEntity> CreateAsync(CompanyDTO companyDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CompanyEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CompanyEntity> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<CompanyEntity> GetByRazaoSocialAsync(string razaoSocial)
        {
            throw new NotImplementedException();
        }

        public Task<CompanyEntity> UpdateAsync(long id, CompanyDTO companyDTO)
        {
            throw new NotImplementedException();
        }
    }
}
