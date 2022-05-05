using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Product
    {
        //[JsonProperty("$id")]
        //public string Id { get; set; }
        public string productCode { get; set; }
        public string briefDescription { get; set; }
        public string description { get; set; }
        public string sizeCode { get; set; }
        public string supplierCode { get; set; }
        public string colorCode { get; set; }
        public string colorDescription { get; set; }
        public string levelCode1 { get; set; }
        public string levelDescription1 { get; set; }
        public string levelCode2 { get; set; }
        public string levelDescription2 { get; set; }
        public string levelCode3 { get; set; }
        public string levelDescription3 { get; set; }
        public string levelCode4 { get; set; }
        public string levelDescription4 { get; set; }
        public string levelCode5 { get; set; }
        public string levelDescription5 { get; set; }
        public string levelCode6 { get; set; }
        public string levelDescription6 { get; set; }
        public string levelCode7 { get; set; }
        public string levelDescription7 { get; set; }
        public string levelCode8 { get; set; }
        public string levelDescription8 { get; set; }
        public string levelCode9 { get; set; }
        public string levelDescription9 { get; set; }
        public string supplierProductReference { get; set; }
        public string attributeCode1 { get; set; }
        public string attributeDesc1 { get; set; }
        public string attributeCode2 { get; set; }
        public string attributeDesc2 { get; set; }
        public string attributeCode3 { get; set; }
        public string attributeDesc3 { get; set; }
        public string attributeCode4 { get; set; }
        public string attributeDesc4 { get; set; }
        public string attributeCode5 { get; set; }
        public string attributeDesc5 { get; set; }
        public string attributeCode6 { get; set; }
        public string attributeDesc6 { get; set; }
        public string attributeCode7 { get; set; }
        public string attributeDesc7 { get; set; }
        public string attributeCode8 { get; set; }
        public string attributeDesc8 { get; set; }
        public string attributeCode9 { get; set; }
        public string attributeDesc9 { get; set; }
        public string attributeCode10 { get; set; }
        public string attributeDesc10 { get; set; }
        public string attributeCode11 { get; set; }
        public string attributeDesc11 { get; set; }
        public string attributeCode12 { get; set; }
        public string attributeDesc12 { get; set; }
        public string attributeCode13 { get; set; }
        public string attributeDesc13 { get; set; }
        public string attributeCode14 { get; set; }
        public string attributeDesc14 { get; set; }
        public string attributeCode15 { get; set; }
        public string attributeDesc15 { get; set; }
        public int otbLevel { get; set; }
        public int clusterLevel { get; set; }
        public int allocLevel { get; set; }
        public int distLevel { get; set; }
        public int storeLevel { get; set; }
        public int allocationModelLevel { get; set; }
        public int replenishmentLevel { get; set; }
        public int demandLevel { get; set; }
    }
}
