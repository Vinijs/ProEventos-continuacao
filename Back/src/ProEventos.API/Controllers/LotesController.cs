using Microsoft.AspNetCore.Mvc;
using ProEventos.Application.Contratos;
using ProEventos.Application.Dtos;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
public class LotesController : ControllerBase
{ 
        private readonly ILoteService _loteService;
    
    public LotesController(ILoteService loteService)
    {      
            _loteService = loteService;
    }

    [HttpGet("{eventoId}")]
    public async Task<IActionResult> Get(int eventoId)
    {        
        try
        {
            var lotes = await _loteService.GetLotesByEventoIdAsync(eventoId);
            if(lotes == null) return NotFound("Nenhum evento encontrado.");

            return Ok(lotes);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar recuperar lotes. Erro: {ex.Message}");
        }
    }

    [HttpPut("{eventoId}")]
    public async Task<IActionResult> SaveLotes(int eventoId, LoteDto[] models)
    {
         try
        {
            var lotes = await _loteService.SaveLote(eventoId, models);
            if(lotes == null) return BadRequest("Erro ao tentar editar o evento.");

            return Ok(lotes);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar salvar lotes. Erro: {ex.Message}");
        }
    }

    [HttpDelete("{eventoId}/{loteId}")]
    public async Task<IActionResult> Delete(int eventoId, int loteId)
    {
         try
        {
            var lote = await _loteService.GetLoteByIdsAsync(eventoId, loteId);
            if(lote == null) return NotFound("Nenhum evento encontrado.");
            
            return await _loteService.DeleteLote(lote.EventoId, lote.Id)?
                   Ok("Lote Deletado") :
                   BadRequest("Lote não deletado");
           
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar deletar lotes. Erro: {ex.Message}");
        }
    }
}

}


