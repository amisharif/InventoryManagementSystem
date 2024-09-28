using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ServiceContracts
{
    public interface  ISalesService
    {
        Task<Sale> AddSale(Sale sale);
        Task<List<Sale>> GetAllSales();
    }
}
