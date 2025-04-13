using Helena.Test.Back.Model.DTOs;
using Helena.Test.Back.Service.Interfaces;
using Helena.Test.Back.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using ServiceStack.Host;

namespace Helena.Test.Back.Service.Implements
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<CompanyDTO> CreateCompanyAsync(CompanyDTO companyDTO)
        {
            if (companyDTO == null)
                throw new HttpException(StatusCodes.Status400BadRequest, "Os dados da empresa não podem ser nulos");

            if (string.IsNullOrWhiteSpace(companyDTO.NomeFantasia))
                throw new HttpException(StatusCodes.Status400BadRequest, "Nome Fantasia é obrigatório");

            if (string.IsNullOrWhiteSpace(companyDTO.RazaoSocial))
                throw new HttpException(StatusCodes.Status400BadRequest, "Razão Social é obrigatória");

            if (companyDTO.NomeFantasia.Length > 100)
                throw new HttpException(StatusCodes.Status400BadRequest, "Nome Fantasia não pode exceder 100 caracteres");
        
            if (companyDTO.RazaoSocial.Length > 150)
                throw new HttpException(StatusCodes.Status400BadRequest, "Razão Social não pode exceder 150 caracteres");
        
            if (companyDTO.QtdeFuncionarios < 0)
                throw new HttpException(StatusCodes.Status400BadRequest, "Quantidade de Funcionários não pode ser negativa");

            var existingCompany = await _companyRepository.GetByRazaoSocialAsync(companyDTO.RazaoSocial);
            if (existingCompany != null)
                throw new HttpException(StatusCodes.Status409Conflict, "Razão Social já cadastrada");
          
            return CompanyExtensions.ToDto(await _companyRepository.CreateAsync(companyDTO));
        }

        public async Task<bool> DeleteCompanyAsync(long id)
        {
            if (id <= 0)
                throw new HttpException(StatusCodes.Status400BadRequest, "O id deve ser maior que 0");

            _ = await _companyRepository.GetByIdAsync(id) ??
                throw new HttpException(StatusCodes.Status404NotFound, "Empresa não encontrada");

            return await _companyRepository.DeleteAsync(id);
        }

        public async Task<List<CompanyDTO>> GetCompaniesAsync()
        {
            var result = await _companyRepository.GetAllAsync();
            return result.Select(CompanyExtensions.ToDto).ToList(); 
        }

        public async Task<CompanyDTO> GetCompanyAsync(long id)
        {
            if (id <= 0)
                throw new HttpException(StatusCodes.Status400BadRequest, "O id deve ser maior que 0");

            var company = await _companyRepository.GetByIdAsync(id) ??
                throw new HttpException(StatusCodes.Status404NotFound, "Empresa não encontrada");
            
            return CompanyExtensions.ToDto(company);
        }

        public async Task<CompanyDTO> UpdateCompanyAsync(long id, CompanyDTO companyDTO)
        {
            if (id <= 0)
                throw new HttpException(StatusCodes.Status400BadRequest, "O id deve ser maior que 0");
            
            if (companyDTO == null)
                throw new HttpException(StatusCodes.Status400BadRequest, "Os dados da empresa não podem ser nulos");

            if (string.IsNullOrWhiteSpace(companyDTO.NomeFantasia))
                throw new HttpException(StatusCodes.Status400BadRequest, "Nome Fantasia é obrigatório");

            if (string.IsNullOrWhiteSpace(companyDTO.RazaoSocial))
                throw new HttpException(StatusCodes.Status400BadRequest, "Razão Social é obrigatória");

            if (companyDTO.NomeFantasia.Length > 100)
                throw new HttpException(StatusCodes.Status400BadRequest, "Nome Fantasia não pode exceder 100 caracteres");
        
            if (companyDTO.RazaoSocial.Length > 150)
                throw new HttpException(StatusCodes.Status400BadRequest, "Razão Social não pode exceder 150 caracteres");
        
            if (companyDTO.QtdeFuncionarios < 0)
                throw new HttpException(StatusCodes.Status400BadRequest, "Quantidade de Funcionários não pode ser negativa");

            if (companyDTO.Id != id)
                throw new HttpException(StatusCodes.Status400BadRequest, "O ID na rota e no objeto não correspondem");

            var existingCompany = await _companyRepository.GetByIdAsync(id) ??
                throw new HttpException(StatusCodes.Status404NotFound, "Empresa não encontrada");

            if (companyDTO.RazaoSocial != existingCompany.RazaoSocial)
            {
                var companyWithSameRazaoSocial = await _companyRepository.GetByRazaoSocialAsync(companyDTO.RazaoSocial);
                if (companyWithSameRazaoSocial != null && companyWithSameRazaoSocial.Id != id)
                    throw new HttpException(StatusCodes.Status409Conflict, "Razão Social já cadastrada por outra empresa");
            }

            return CompanyExtensions.ToDto(await _companyRepository.UpdateAsync(id, companyDTO));
        }
    }
}
