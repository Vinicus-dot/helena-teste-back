using Helena.Test.Back.Model.Entitys;
using System.Text.Json.Serialization;

namespace Helena.Test.Back.Model.DTOs
{
    public class CompanyDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("avatarUrl")]
        public string AvatarUrl { get; set; }

        [JsonPropertyName("nomeFantasia")]
        public string NomeFantasia { get; set; }

        [JsonPropertyName("razaoSocial")]
        public string RazaoSocial { get; set; }

        [JsonPropertyName("qtdeFuncionarios")]
        public int QtdeFuncionarios { get; set; }

        [JsonPropertyName("active")]
        public bool Active { get; set; }

    }

    public static class CompanyExtensions
    {
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