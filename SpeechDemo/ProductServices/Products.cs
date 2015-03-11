using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices
{
    public class Products: IProduct
    {

        public Dictionary<int, string> GetDicProductLines()
        {
            Dictionary<int,string> dicProductLines = new Dictionary<int, string>();
            dicProductLines.Add(1, "Best Buy");
            dicProductLines.Add(2, "Safeway");
            dicProductLines.Add(3, "Amazon");
            dicProductLines.Add(4, "Starbucks");
            dicProductLines.Add(5, "Visa");
            dicProductLines.Add(6, "subway");
            return dicProductLines;
        }

        public Dictionary<int, Dictionary<int, string>> GetDicProductInfo()
        {
            Dictionary<int,Dictionary<int,string>> dicAllProductInfo = new Dictionary<int, Dictionary<int, string>>();

            Dictionary<int, string> dicProductList;

            dicProductList = new Dictionary<int, string>();

            dicProductList.Add(1, "Best Buy Blue $25 Gift Card");
            dicProductList.Add(2, "Best Buy Blue $50 Gift Card");
            dicProductList.Add(3, "Best Buy Blue $100 Gift Card");
            dicProductList.Add(4, "Best Buy eGift Card");
            dicProductList.Add(5, "Best Buy Variable eGift Card");

            dicAllProductInfo.Add(1,dicProductList);

            //dicProductList.Clear();
            dicProductList = new Dictionary<int, string>();

            dicProductList.Add(6, "Safeway Customizable Gift Card");
            dicProductList.Add(7, "Safeway Wedding Gift Card");
            dicProductList.Add(8, "Safeway Thank You Gift Card");
            dicProductList.Add(9, "Safeway Graduation Gift Card");
            dicProductList.Add(10, "Safeway Happy Birthday Gift Card");
            dicProductList.Add(11, "Safeway Congratulations Gift Card");

            dicAllProductInfo.Add(2,dicProductList);

            dicProductList = new Dictionary<int, string>();

            dicProductList.Add(12, "Amazon.com $25");
            dicProductList.Add(13, "Amazon.com eGift Card");
            dicProductList.Add(14, "Amazon POR");
            dicProductList.Add(15, "Amazon.com $50.00");
            dicProductList.Add(16, "AMAZON.com  Orange eGift Card");

            dicAllProductInfo.Add(3,dicProductList);

            dicProductList = new Dictionary<int, string>();

            dicProductList.Add(17, "Starbucks $25 Shots Gift Card");
            dicProductList.Add(18, "Starbucks $50 Shots Gift Card");
            dicProductList.Add(19, "Starbucks Mobile Gift Card");

             dicAllProductInfo.Add(4,dicProductList);

             dicProductList = new Dictionary<int, string>();
            dicProductList.Add(20, "Visa Golf Gift Card");
            dicProductList.Add(21, "Visa Birthday Gift Card");
            dicProductList.Add(22, "BLISS BHN Visa Gift $25");
            dicProductList.Add(23, "Visa Reloadable card");
            dicProductList.Add(24, "BLISS BHN Visa Gift Thank You");
            dicProductList.Add(25, "BLISS BHN Visa Gift Baby");

             dicAllProductInfo.Add(5,dicProductList);

             dicProductList = new Dictionary<int, string>();

            dicProductList.Add(26, "Subway Gift Card $15");
            dicProductList.Add(27, "Subway Gift Card $25");


            return dicAllProductInfo;
        }
        public string[] GetProductLines()
        {
            var dicPL = new Dictionary<int, string>();
            dicPL = GetDicProductLines();
            return dicPL.Values.ToArray();
        }

        public int GetProductLineIdByName(string prodLineName)
        {
            var dicPL = new Dictionary<int, string>();
            dicPL = GetDicProductLines();
            foreach (KeyValuePair< int,string> pair in dicPL)
            {
                if (pair.Value.ToLower() == prodLineName.ToLower())
                {
                    return pair.Key;
                    break;
                }
                    
            }
            return 0;
        }

        public string[] GetProductsById(int prodLineId)
        {
            var dicProductInfo = new Dictionary<int, Dictionary<int, string>>();
            dicProductInfo = GetDicProductInfo();
            foreach (KeyValuePair<int,Dictionary<int,string>> dicPair in dicProductInfo )
            {
                if (dicPair.Key == prodLineId)
                {
                    return ((Dictionary<int, string>) dicPair.Value).Values.ToArray();
                    break;
                }
            }
            return null;
        }
    }
}
