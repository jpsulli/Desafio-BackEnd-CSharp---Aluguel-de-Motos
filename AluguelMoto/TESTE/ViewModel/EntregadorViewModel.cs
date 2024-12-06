using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TESTE.ViewModel
{
    public class EntregadorViewModel
    {
        [Key]
        public string cnpj { get; private set; }

        [Required]
        public string identificador { get; private set; }
        [Required]
        public string nome { get; private set; }
        [Required]
        public DateOnly data_nascimento { get; private set; }
        [Required]  
        [Index(IsUnique = true)] 
        public string numero_cnh { get; private set; }
        [Required]
        public string tipo_cnh { get; private set; }
        [Required]
        public string imagem_cnh { get; private set; }
    }
}
