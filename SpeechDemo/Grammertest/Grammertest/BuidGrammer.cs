using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductServices;
using System.Speech.Recognition;
using ProductServices;


namespace Grammertest
{

    public class BuildGrammar
    {
        public BuildGrammar()
        {
        }
        public Grammar GetProductlineGrammer(){

            Choices productLines = new Choices();

            Products products = new Products();
            productLines.Add( products.GetProductLines());
           
            GrammarBuilder grammarbuilder = new GrammarBuilder();
            grammarbuilder.Append(productLines);

            Grammar grammar = new Grammar(grammarbuilder);

            return grammar;
        }
         public List<string> GetProductLineds (){
             List<string> productlineIds= new List<string>();
             return productlineIds;

    }


         public int GetProductLineId(string productLineName)
         {
             Products products = new Products();
             int productLineId= products.GetProductLineIdByName(productLineName);

             return productLineId;
         }


    }
}
