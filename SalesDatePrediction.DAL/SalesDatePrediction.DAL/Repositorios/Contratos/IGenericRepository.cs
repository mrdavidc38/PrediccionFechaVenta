using SalesDatePrediction.Model.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatePrediction.DAL.Repositorios.Contratos
{
    public interface IGenericRepository<TModel> where TModel : class
    {
        Task<TModel> Obtener(Expression<Func<TModel, bool>> filtro);
        Task<TModel> Crear(TModel modelo);
        Task<bool> Editar(TModel modelo);
        Task<bool> Eliminar(TModel modelo);
        Task<int> Consultar(Expression<Func<TModel, bool>> filtro = null);

        //Task<IQueryable<TModel>> Consultar(int pageNumber, int pageSize, Expression<Func<TModel, bool>> filtro = null);
        Task<IQueryable<TModel>> Consultar(int pageNumber, int pageSize, Expression<Func<TModel, bool>> filtro = null);
    }
}
