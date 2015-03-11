using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices
{
    public partial interface IProduct
    {
        //IList<ProductLine> GetProductLines();
        //IList<Product> GetProductsByName(string productLineName);
        //IList<Product> GetProductsById(int id);

        //Dictionary<int, string> GetProductLines();
        //Dictionary<int, string> GetProductsById(int productLineId);
        //Dictionary<int, string> GetProductsByName(int productLineId);

        string[] GetProductLines();
        int GetProductLineIdByName(string prodLineName);

        string[] GetProductsById(int prodLineId);
    }
}
