using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillAutomation    //DO NOT change the namespace name
{
    public class ElectricityBill         //DO NOT change the class name
    {
       //Implement the fields and properties as per description
       private string consumerNumber;
       private string consumerName;
       private int unitsConsumed;
       private double billAmount;
       public ElectricityBill(){}
       public ElectricityBill(string consumerNumber,string consumerName,int unitsConsumed,double billAmount)
       {
           this.consumerNumber=consumerNumber;
           this.consumerName=consumerName;
           this.unitsConsumed=unitsConsumed;
           this.billAmount=billAmount;
       }
       public string ConsumerNumber
       {
           get{return this.consumerNumber;}
           set{
if (value.Substring(0, 2).Equals("EB"))
                {
                    this.consumerNumber = value;
                }
else
throw new FormatException(Msg);
}
       }
       public string ConsumerName
       {
           get{return this.consumerName;}
           set{this.consumerName=value;}
       }
       public int UnitsConsumed
       {
           get{return this.unitsConsumed;}
           set{this.unitsConsumed=value;}
       }
       public double BillAmount
       {
           get{return this.billAmount;}
           set{this.billAmount=value;}
       }
       
    }
}
