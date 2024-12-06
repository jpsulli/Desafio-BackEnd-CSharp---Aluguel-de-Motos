using Microsoft.AspNetCore.Mvc;
using TESTE.Model;
using TESTE.ViewModel;

namespace TESTE.Controller
{
    [ApiController]
    [Route("openapi/v1/entregador")]
    public class EntregadorController : ControllerBase
    {
        private readonly IEntregadorRepository _entregadorRepository;

        public EntregadorController(IEntregadorRepository entregadorRepository)
        {
            _entregadorRepository = entregadorRepository ?? throw new ArgumentNullException();
        }

        [HttpPost]
        public IActionResult Add(EntregadorViewModel entregadorView)
        {
            var entregador = new Entregador(entregadorView.identificador, entregadorView.cnpj, entregadorView.nome,
                entregadorView.data_nascimento, entregadorView.numero_cnh, entregadorView.tipo_cnh, entregadorView.imagem_cnh);

            _entregadorRepository.Add(entregador); 

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetEntregador(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest("O ID é obrigatório.");

            var entregador = _entregadorRepository.Get(id);

            if (entregador == null)
                return NotFound("Entregador não encontrado.");

            return Ok(entregador);
        }


    }
}
