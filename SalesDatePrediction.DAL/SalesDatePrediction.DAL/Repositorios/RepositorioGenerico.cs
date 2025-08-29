using SalesDatePrediction.DAL.Repositorios.Contratos;
using SalesDatePrediction.Model.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatePrediction.DAL.Repositorios
{
    public class RepositorioGenerico<TModel> : IGenericRepository<TModel> where TModel : class
    {
        private readonly StoreSampleContext _dbFechaVentasContext;

        public RepositorioGenerico(StoreSampleContext dbFechaVentasContext)
        {
            _dbFechaVentasContext = dbFechaVentasContext;
        }

        public Task<IQueryable<TModel>> Consultar(Expression<Func<TModel, bool>> filtro = null)
        {
            throw new NotImplementedException();
        }

        public Task<TModel> Crear(TModel modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Editar(TModel modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(TModel modelo)
        {
            throw new NotImplementedException();
        }

        public Task<TModel> Obtener(Expression<Func<TModel, bool>> filtro)
        {
            throw new NotImplementedException();
        }
    }
}
