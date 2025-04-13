using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace Helena.Test.Back.API.Controllers
{
    public class CompanyController : GenericController
    {
        /// <summary>
        /// Obter todas as empresas
        /// </summary>
        /// <remarks>
        /// Recupera uma lista de todas as empresas
        /// </remarks>
        /// <returns>
        /// Retorna uma lista de empresas
        /// </returns>
        /// <response code="200">Ok</response>
        /// <response code="204">Ok, Sem Conteúdo</response>
        /// <response code="400">Requisição Inválida</response>
        /// <response code="403">Proibido</response>
        /// <response code="500">Erro Interno do Servidor</response>
        [SwaggerResponse(200, "Indica que o processamento foi realizado corretamente e o retorno será conforme esperado.", typeof(List<CompanyDTO>))]
        [SwaggerResponse(204, "A solicitação foi bem-sucedida e não há conteúdo para mostrar.")]
        [SwaggerResponse(400, "Requisição mal formada.")]
        [SwaggerResponse(403, "Requisição negada.")]
        [SwaggerResponse(500, "Erro interno do servidor")]
        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {

        }

        /// <summary>
        /// Obter uma empresa específica
        /// </summary>
        /// <remarks>
        /// Recupera uma empresa pelo seu ID
        /// </remarks>
        /// <returns>
        /// Retorna uma empresa
        /// </returns>
        /// <param name="id">ID da Empresa</param>
        /// <response code="200">Ok</response>
        /// <response code="204">Ok, Sem Conteúdo</response>
        /// <response code="400">Requisição Inválida</response>
        /// <response code="403">Proibido</response>
        /// <response code="404">Não Encontrado</response>
        /// <response code="500">Erro Interno do Servidor</response>
        [SwaggerResponse(200, "Indica que o processamento foi realizado corretamente e o retorno será conforme esperado.", typeof(CompanyDTO))]
        [SwaggerResponse(204, "A solicitação foi bem-sucedida e não há conteúdo para mostrar.")]
        [SwaggerResponse(400, "Requisição mal formada.")]
        [SwaggerResponse(403, "Requisição negada.")]
        [SwaggerResponse(404, "Recurso não encontrado.")]
        [SwaggerResponse(500, "Erro interno do servidor")]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCompany([Required][FromRoute] string id)
        {
        }

        /// <summary>
        /// Criar uma nova empresa
        /// </summary>
        /// <remarks>
        /// Cria uma nova empresa com as informações fornecidas
        /// </remarks>
        /// <returns>
        /// Retorna a empresa criada
        /// </returns>
        /// <param name="companyDTO">Dados da empresa</param>
        /// <response code="201">Criado</response>
        /// <response code="400">Requisição Inválida</response>
        /// <response code="403">Proibido</response>
        /// <response code="500">Erro Interno do Servidor</response>
        [SwaggerResponse(201, "Empresa criada com sucesso.", typeof(CompanyDTO))]
        [SwaggerResponse(400, "Requisição mal formada.")]
        [SwaggerResponse(403, "Requisição negada.")]
        [SwaggerResponse(500, "Erro interno do servidor")]
        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyDTO companyDTO)
        {
        }

        /// <summary>
        /// Atualiza uma empresa
        /// </summary>
        /// <remarks>
        /// Atualiza uma empresa existente com as informações fornecidas
        /// </remarks>
        /// <returns>
        /// Retorna a empresa atualizada
        /// </returns>
        /// <param name="id">ID da Empresa</param>
        /// <param name="companyDTO">Dados atualizados da empresa</param>
        /// <response code="200">Ok</response>
        /// <response code="400">Requisição Inválida</response>
        /// <response code="403">Proibido</response>
        /// <response code="404">Não Encontrado</response>
        /// <response code="500">Erro Interno do Servidor</response>
        [SwaggerResponse(200, "Empresa atualizada com sucesso.", typeof(CompanyDTO))]
        [SwaggerResponse(400, "Requisição mal formada.")]
        [SwaggerResponse(403, "Requisição negada.")]
        [SwaggerResponse(404, "Recurso não encontrado.")]
        [SwaggerResponse(500, "Erro interno do servidor")]
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCompany([Required][FromRoute] string id, [FromBody] CompanyDTO companyDTO)
        {

        }

        /// <summary>
        /// Deleta uma empresa
        /// </summary>
        /// <remarks>
        /// Deleta uma empresa com o ID informado
        /// </remarks>
        /// <param name="id">ID da Empresa</param>
        /// <response code="204">Sem Conteúdo</response>
        /// <response code="400">Requisição Inválida</response>
        /// <response code="403">Proibido</response>
        /// <response code="404">Não Encontrado</response>
        /// <response code="500">Erro Interno do Servidor</response>
        [SwaggerResponse(204, "Empresa deletada com sucesso.")]
        [SwaggerResponse(400, "Requisição mal formada.")]
        [SwaggerResponse(403, "Requisição negada.")]
        [SwaggerResponse(404, "Recurso não encontrado.")]
        [SwaggerResponse(500, "Erro interno do servidor")]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCompany([Required][FromRoute] string id)
        {
        }
    }
}