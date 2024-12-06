namespace TESTE.Model
{
    public interface IMotoRepository
    {
        void Add(Moto moto);
        void Remove(Moto moto);
        //void Update(Moto moto);
        Moto GetByPlaca(string placa);
    }
}
