using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ServiceContracts
{
    public interface IStocksService
    {
        Task<List<Stock>> GetAllStockProducts();

        Task<Stock> GetProductByCtIdProdId(string categoryID,string productID);
    }
}
