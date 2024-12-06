using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TESTE.Model
{
    public class Entregador
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

        public Entregador(string identificador, string cnpj, string nome, DateOnly data_nascimento, string numero_cnh, string tipo_cnh, string imagem_cnh)
        {
            this.identificador = identificador;
            this.cnpj = cnpj;
            this.nome = nome;
            this.data_nascimento = data_nascimento;
            this.numero_cnh = numero_cnh;
            this.tipo_cnh = tipo_cnh;
            this.imagem_cnh = imagem_cnh;
        }


    }
}
