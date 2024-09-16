using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomControlSystem.Model
{
    public class SaleModel
    {
        public int    SaleId { get; set; }

        public string ProductName { get; set; }
       public decimal Amount { get; set; }
      public DateTime SaleDate { get; set; }
        public string Status { get; set; }

        public List<CustomerModel> Customers { get; set; }
    }
}
