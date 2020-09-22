using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;


namespace Smart__Body.Models
{
    public class DataPoint
    {
        public string name;
        public int price;
        public string id;

        public DataPoint(string name, int price, string id)
        {
            this.name = name;
            this.price = price;
            this.id = id;
        }
    }



}