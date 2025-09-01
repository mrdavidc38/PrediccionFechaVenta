using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatePrediction.Model.Modelos
{
    public class CustomerOrdenPrediccionResultado
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public DateTime LastOrderDate { get; set; }
        public DateTime NextPredictedOrder { get; set; }
        public int TotalOrders { get; set; }
    }
}
