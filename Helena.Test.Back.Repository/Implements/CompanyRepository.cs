using Helena.Test.Back.Model.DTOs;
using Helena.Test.Back.Model.Entitys;
using Helena.Test.Back.Repository.Interfaces;
using Helena.Test.Back.Repository.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using Dapper;
using Helena.Test.Back.Model;

namespace Helena.Test.Back.Repository.Implements
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IConnectionString _connectionString;
        public CompanyRepository(IConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<CompanyEntity> CreateAsync(CompanyDTO companyDTO)
        {
            using var connection = new MySqlConnection(_connectionString.HelenaDbConnectionString);
            await connection.OpenAsync();
            var id = await connection.ExecuteScalarAsync<long>(CompanyQuerys.CreateQuery, companyDTO);
            
            return new CompanyEntity
            {
                Id = id,
                AvatarUrl = companyDTO.AvatarUrl,
                NomeFantasia = companyDTO.NomeFantasia,
                RazaoSocial = companyDTO.RazaoSocial,
                QtdeFuncionarios = companyDTO.QtdeFuncionarios,
                Active = companyDTO.Active
            };
        }

        public async Task<bool> DeleteAsync(long id)
        {
            using var connection = new MySqlConnection(_connectionString.HelenaDbConnectionString);
            var affectedRows = await connection.ExecuteAsync(CompanyQuerys.DeleteQuery, new { Id = id });
            
            return affectedRows > 0;
        }

        public async Task<List<CompanyEntity>> GetAllAsync()
        {
            using var connection = new MySqlConnection(_connectionString.HelenaDbConnectionString);
            var companies = await connection.QueryAsync<CompanyEntity>(CompanyQuerys.GetAllQuery);
            
            return companies.ToList();
        }

        public async Task<CompanyEntity?> GetByIdAsync(long id)
        {
            using var connection = new MySqlConnection(_connectionString.HelenaDbConnectionString);
            return await connection.QueryFirstOrDefaultAsync<CompanyEntity>(CompanyQuerys.GetByIdQuery, new { Id = id });
        }

        public async Task<CompanyEntity?> GetByRazaoSocialAsync(string razaoSocial)
        {
            using var connection = new MySqlConnection(_connectionString.HelenaDbConnectionString);
            return await connection.QueryFirstOrDefaultAsync<CompanyEntity>(CompanyQuerys.GetByRazaoSocialQuery, new { RazaoSocial = razaoSocial });
        }

        public async Task<CompanyEntity> UpdateAsync(long id, CompanyDTO companyDTO)
        {
            using var connection = new MySqlConnection(_connectionString.HelenaDbConnectionString);
            await connection.ExecuteAsync(CompanyQuerys.UpdateQuery, new { 
                Id = id,
                companyDTO.AvatarUrl,
                companyDTO.NomeFantasia,
                companyDTO.RazaoSocial,
                companyDTO.QtdeFuncionarios,
                companyDTO.Active
            });
            
            return new CompanyEntity
            {
                Id = id,
                AvatarUrl = companyDTO.AvatarUrl,
                NomeFantasia = companyDTO.NomeFantasia,
                RazaoSocial = companyDTO.RazaoSocial,
                QtdeFuncionarios = companyDTO.QtdeFuncionarios,
                Active = companyDTO.Active
            };
        }
    }
}
