
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAccounting.Models
{
   
    public class ExpenseTotal
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string? Date { get; set; }
        public string? Statement { get; set; }
        public string? StatementDa { get; set; }
     
        public double Total_Value{ get;set; }
        
        
    } 
 public class Expense
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string? Date { get; set; }
        public string? Statement { get; set; }
        public string? StatementDa { get; set; }
     
        public double Total_Value{ get;set; }
        
        
    }
}
