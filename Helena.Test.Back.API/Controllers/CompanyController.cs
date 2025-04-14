using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;
using Helena.Test.Back.Model.DTOs;
using Helena.Test.Back.Service.Interfaces;

namespace Helena.Test.Back.API.Controllers
{
    public class CompanyController : GenericController
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

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
            return Ok(await _companyService.GetCompaniesAsync());
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
        [SwaggerResponse(200, "Indica que o processamento foi realizado corretamente e o retorno será conforme esperado.", typeof(CompanySingleDTO))]
        [SwaggerResponse(204, "A solicitação foi bem-sucedida e não há conteúdo para mostrar.")]
        [SwaggerResponse(400, "Requisição mal formada.")]
        [SwaggerResponse(403, "Requisição negada.")]
        [SwaggerResponse(404, "Recurso não encontrado.")]
        [SwaggerResponse(500, "Erro interno do servidor")]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCompany([Required][FromRoute] long id)
        {
            return Ok(await _companyService.GetCompanyAsync(id));
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
        /// <param name="companySingleDTO">Dados da empresa</param>
        /// <response code="201">Criado</response>
        /// <response code="400">Requisição Inválida</response>
        /// <response code="403">Proibido</response>
        /// <response code="500">Erro Interno do Servidor</response>
        [SwaggerResponse(201, "Empresa criada com sucesso.", typeof(CompanySingleDTO))]
        [SwaggerResponse(400, "Requisição mal formada.")]
        [SwaggerResponse(403, "Requisição negada.")]
        [SwaggerResponse(500, "Erro interno do servidor")]
        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] CompanySingleDTO companySingleDTO)
        {
            return Created("Empresa Criada com Sucesso!",await _companyService.CreateCompanyAsync(companySingleDTO));
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
        [SwaggerResponse(200, "Empresa atualizada com sucesso.")]
        [SwaggerResponse(400, "Requisição mal formada.")]
        [SwaggerResponse(403, "Requisição negada.")]
        [SwaggerResponse(404, "Recurso não encontrado.")]
        [SwaggerResponse(500, "Erro interno do servidor")]
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCompany([Required][FromRoute] long id, [FromBody] CompanyPutRquestDTO companyDTO)
        {
            await _companyService.UpdateCompanyAsync(id, companyDTO);
            return NoContent();
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
        public async Task<IActionResult> DeleteCompany([Required][FromRoute] long id)
        {
            await _companyService.DeleteCompanyAsync(id);
            return NoContent();
        }
    }
}