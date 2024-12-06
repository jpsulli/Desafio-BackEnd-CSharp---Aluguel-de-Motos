using System.ComponentModel.DataAnnotations;

namespace TESTE.ViewModel
{
    public class MotoViewModel
    {
        [Key]
        public string placa { get; private set; }
        public string identificador { get; private set; }
        public string modelo { get; private set; }
        public int ano { get; private set; }
    }
}
