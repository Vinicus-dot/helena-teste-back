using Helena.Test.Back.Model.Entitys;
using System.Text.Json.Serialization;

namespace Helena.Test.Back.Model.DTOs
{
    public class CompanyDTO
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("avatarUrl")]
        public string AvatarUrl { get; set; }

        [JsonPropertyName("nomeFantasia")]
        public string NomeFantasia { get; set; }

        [JsonPropertyName("razaoSocial")]
        public string RazaoSocial { get; set; }

        [JsonPropertyName("qtdeFuncionarios")]
        public long QtdeFuncionarios { get; set; }

        [JsonPropertyName("active")]
        public bool Active { get; set; }

    }

    public class CompanySingleDTO
    {
        [JsonPropertyName("avatarUrl")]
        public string? AvatarUrl { get; set; }

        [JsonPropertyName("nomeFantasia")]
        public string NomeFantasia { get; set; }

        [JsonPropertyName("razaoSocial")]
        public string RazaoSocial { get; set; }

        [JsonPropertyName("qtdeFuncionarios")]
        public long QtdeFuncionarios { get; set; }

        [JsonPropertyName("active")]
        public bool Active { get; set; }

    }

    public static class CompanyExtensions
    {
        public static CompanySingleDTO ToDtoSingle(this CompanyEntity entity)
        {
            if (entity == null)
                return new CompanySingleDTO();

            return new CompanySingleDTO
            {
                AvatarUrl = entity.AvatarUrl,
                NomeFantasia = entity.NomeFantasia,
                RazaoSocial = entity.RazaoSocial,
                QtdeFuncionarios = entity.QtdeFuncionarios,
                Active = entity.Active
            };
        }

        public static CompanyDTO ToDto(this CompanyEntity entity)
        {
            if (entity == null)
                return new CompanyDTO();

            return new CompanyDTO
            {
                Id = entity.Id,
                AvatarUrl = entity.AvatarUrl,
                NomeFantasia = entity.NomeFantasia,
                RazaoSocial = entity.RazaoSocial,
                QtdeFuncionarios = entity.QtdeFuncionarios,
                Active = entity.Active
            };
        }
    }
}