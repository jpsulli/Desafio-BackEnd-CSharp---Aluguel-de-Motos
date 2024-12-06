namespace TESTE.Model
{
    public interface IEntregadorRepository
    {
        void Add(Entregador entregador);
        void Remove(Entregador entregador);
        void Update(Entregador entregador);
        void UpdatImg(Entregador entregador, string imagem_cnh);
        Entregador Get(string id);

    }
}
