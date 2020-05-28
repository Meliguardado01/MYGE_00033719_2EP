using System;

namespace SourceCode.Modelo
{
    public class AppOrder
    {
        
        public string idorder {get; set;}
        public DateTime createdate { get; set; }
        public string idproduct { get; set; }
        public string idadress { get; set; }

        public AppOrder()
        {

            idorder = "";
            createdate = DateTime.Now;
            idproduct = "";
            idadress = "";
        }
    }
}