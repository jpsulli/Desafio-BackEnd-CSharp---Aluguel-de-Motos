using Microsoft.AspNetCore.Mvc;
using TESTE.Model;
using TESTE.ViewModel;

namespace TESTE.Controller
{
    [ApiController]
    [Route("openapi/v1/moto")]
    public class MotoController : ControllerBase
    {
        private readonly IMotoRepository _motoRepository;

        public MotoController(IMotoRepository motoRepository)
        {
            _motoRepository = motoRepository ?? throw new ArgumentNullException();
        }

        [HttpPost]
        public IActionResult Add(MotoViewModel motoView)
        {
            var moto = new Moto(motoView.identificador, motoView.modelo, motoView.ano, motoView.placa);
            _motoRepository.Add(moto);
            return Ok();
        }

        [HttpGet("{placa}")]
        public IActionResult GetByPlaca(string placa)
        {
            // Validações
            if (string.IsNullOrEmpty(placa))
                return BadRequest("A placa é obrigatória para consulta.");

            try
            {
                var moto = _motoRepository.GetByPlaca(placa);

                if (moto == null)
                    return NotFound("Moto não encontrada para a placa informada.");

                return Ok(moto);
            }
            catch (Exception ex)
            {
                // Tratamento de erro
                return StatusCode(500, $"Erro ao consultar a moto: {ex.Message}");
            }
        }
    }
}
