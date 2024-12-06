using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TESTE.Model
{
    [Table("moto")]

    public class Moto
    {
        [Key]
        public string placa { get; private set; }
        [Required]
        public string identificador { get; private set; }
        [Required]
        public string modelo { get  ; private set; }
        [Required]
        public int ano { get; private set; }
        
       
        public Moto(string identificador, string modelo, int ano, string placa)
        {
            this.identificador = identificador;
            this.modelo = modelo;
            this.ano = ano;
            this.placa = placa;
        }
    }
}
