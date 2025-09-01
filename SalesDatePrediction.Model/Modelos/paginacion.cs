using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatePrediction.Model.Modelos
{
    public class paginacion<T>

    {
        public int TotalRecords { get; set; } // total de registros en BD
        public List<T> Records { get; set; } // registros de la página actual

        //public IQueryable<T> data { get; set; }   
    }
}
