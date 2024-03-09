using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAccounting.Models
{
    public class Sales
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string? Date { get; set; }
        public string? Statement { get; set; }
        public int Quantity { get; set; }
        public double Sales_price { get; set; }
        public double Total_Value{ get;set;} 
        
        
    }
}
