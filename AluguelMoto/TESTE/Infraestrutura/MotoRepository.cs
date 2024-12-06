using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TESTE.Model;

namespace TESTE.Infraestrutura
{
    public class MotoRepository : IMotoRepository
    {
        private readonly ConnectionContext _context;

        public MotoRepository(ConnectionContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Moto moto)
        {
            try
            {
                if (_context.Motos.Any(m => m.placa == moto.placa))
                    throw new InvalidOperationException("Já existe uma moto cadastrada com esta placa.");

                _context.Motos.Add(moto);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Erro ao adicionar moto: {ex.Message}");
            }
        }

        public Moto GetByPlaca(string placa)
        {
            try
            {
                return _context.Motos.FirstOrDefault(m => m.placa == placa)
                       ?? throw new InvalidOperationException("Moto não encontrada.");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Erro ao buscar moto por placa: {ex.Message}");
            }
        }

        public void Remove(Moto moto)
        {
            try
            {
                if (_context.Entry(moto).State == EntityState.Detached)
                    _context.Motos.Attach(moto);

                _context.Motos.Remove(moto);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Erro ao remover moto: {ex.Message}");
            }
        }

        public void Update(Moto moto)
        {
            try
            {
                var existingMoto = _context.Motos.FirstOrDefault(m => m.placa == moto.placa);
                if (existingMoto == null)
                    throw new InvalidOperationException("Moto não encontrada para atualização.");

                // Atualizar campos necessários
                existingMoto.placa = moto.placa;

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Erro ao atualizar moto: {ex.Message}");
            }
        }

        public List<Moto> GetAll()
        {
            try
            {
                return _context.Motos.ToList();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Erro ao listar motos: {ex.Message}");
            }
        }
    }
}
