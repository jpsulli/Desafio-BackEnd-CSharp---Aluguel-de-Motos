using TESTE.Model;

namespace TESTE.Infraestrutura

{
    public class EntregadorRepository : IEntregadorRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        void IEntregadorRepository.Add(Entregador entregador)
        {
            _context.Add(entregador);
            _context.SaveChanges();
        }

        //public void Add(Moto moto)
        //{
        //    _context.Add(moto);
        //    _context.SaveChanges();
        //    throw new NotImplementedException();
        //}


        Entregador IEntregadorRepository.Get(string id)
        {
            throw new NotImplementedException();
        }

        void IEntregadorRepository.Remove(Entregador entregador)
        {
            throw new NotImplementedException();
        }

        void IEntregadorRepository.Update(Entregador entregador)
        {
            throw new NotImplementedException();
        }

        void IEntregadorRepository.UpdatImg(Entregador entregador, string imagem_cnh)
        {
            throw new NotImplementedException();
        }
    }
}
