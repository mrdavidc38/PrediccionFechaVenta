using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.DAL.Repositorios.Contratos;
using SalesDatePrediction.Model.Contexto;
using SalesDatePrediction.Model.Modelos;
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

        //public async Task<IQueryable<TModel>> Consultar(Expression<Func<TModel, bool>> filtro = null)
        //{
        //    try
        //    {
        //        IQueryable<TModel> queryModelo = filtro == null ? _dbFechaVentasContext.Set<TModel>() : _dbFechaVentasContext.Set<TModel>().Where(filtro);

        //        return  queryModelo;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}
        public async Task<int> Consultar(Expression<Func<TModel, bool>> filtro = null)
        {
            try
            {

                IQueryable<TModel> queryModelo = filtro == null ? _dbFechaVentasContext.Set<TModel>() : _dbFechaVentasContext.Set<TModel>().Where(filtro);
                var total = await queryModelo.CountAsync();
                //var data = await  queryModelo
                //.Skip((pageNumber - 1) * pageSize)
                //.Take(pageSize).ToListAsync();

                //IQueryable<TModel> data = queryModelo
                //.Skip((pageNumber - 1) * pageSize)
                //.Take(pageSize);


                //return new paginacion<TModel>
                //{
                //    TotalRecords = total
                //    //Records = data,
                //    //data = total
                //};
                return total;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<IQueryable<TModel>> Consultar(int pageNumber, int pageSize, Expression<Func<TModel, bool>> filtro = null)
        {
            try
            {
              
                IQueryable<TModel> queryModelo = filtro == null ? _dbFechaVentasContext.Set<TModel>() : _dbFechaVentasContext.Set<TModel>().Where(filtro);
                var total = await queryModelo.CountAsync();
                //var data = await  queryModelo
                //.Skip((pageNumber - 1) * pageSize)
                //.Take(pageSize).ToListAsync();

                IQueryable<TModel> data = queryModelo
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);


                //return new paginacion<TModel>
                //{
                //    TotalRecords = total
                //    //Records = data,
                //    //data = total
                //};
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<TModel> Crear(TModel modelo)
        {
            try
            {
                _dbFechaVentasContext.Set<TModel>().Add(modelo);
                await _dbFechaVentasContext.SaveChangesAsync();
                return modelo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<bool> Editar(TModel modelo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(TModel modelo)
        {
            throw new NotImplementedException();
        }

        public async Task<TModel> Obtener(Expression<Func<TModel, bool>> filtro)
        {
            try
            {
                TModel modelo = await _dbFechaVentasContext.Set<TModel>().FirstOrDefaultAsync(filtro);
                return modelo;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
