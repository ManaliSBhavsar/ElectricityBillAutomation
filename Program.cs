using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using System.Configuration;

namespace BillAutomation         //DO NOT change the namespace name
{
    public class Program        //DO NOT change the class name
    {
        
        static void Main(string[] args)  //DO NOT change the 'Main' method signature
        {
            //Implement the code here
            int no_of_bills;string str="";int billsgen;string name,no="";int u;
            Console.WriteLine("Enter Number of Bills To Be Added : ");
            no_of_bills=Convert.ToInt32(Console.ReadLine());
            
            ElectricityBoard eb=new ElectricityBoard();
            ElectricityBill ebill=new ElectricityBill();
            DBHandler db=new DBHandler();
            for(int i=0;i<no_of_bills;i++)
            {
                Console.WriteLine("Enter Consumer Number:");
                no=Console.ReadLine();
                if(!checkNum(no))
                {
                    throw new FormatException("Invalid Consumer Number");
                }
                str=str+no+"\n";
                Console.WriteLine("Enter Consumer Name:");
                name=Console.ReadLine();
                str=str+name+"\n";
                Console.WriteLine("Enter Units Consumed:");
                u=Convert.ToInt32(Console.ReadLine());
                str=str+u+"\n";
                BillValidator bv=new BillValidator();
                while(bv.ValidateUnitsConsumed(u).Equals("Given units is invalid"))
                {
                    Console.WriteLine("Enter Units Consumed:");
                    u=Convert.ToInt32(Console.ReadLine());
                }
                ebill.ConsumerNumber=no;ebill.ConsumerName=name;ebill.UnitsConsumed=u;
                eb.CalculateBill(ebill);
                eb.AddBill(ebill);
                str=str+"Bill Amount : "+ebill.BillAmount+"\n";
            }
            Console.WriteLine("Enter Last 'N' Number of Bills To Generate:");
            billsgen=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(str);
            ElectricityBoard eb1=new ElectricityBoard();
            List<ElectricityBill> l=eb1.Generate_N_BillDetails(billsgen);
            foreach(ElectricityBill ebi in l)
            {
                Console.WriteLine("EB Bill for "+ebi.ConsumerName+" is "+ebi.BillAmount);
            }
            
            
            /*retrive data from database and display*/
            //
            
        }
        public static bool checkNum(string name)
        {
            int f=0,g=0;
            string str=name.Substring(0,2);
            if(str.Equals("EB"))
            {
                f=1;
            }
            bool a=int.Parse(name[2].ToString())>=0 && int.Parse(name[2].ToString())<=9;
            bool b=int.Parse(name[3].ToString())>=0 && int.Parse(name[3].ToString())<=9;
            bool c=int.Parse(name[4].ToString())>=0 && int.Parse(name[4].ToString())<=9;
            bool d=int.Parse(name[5].ToString())>=0 && int.Parse(name[5].ToString())<=9;
            bool e=int.Parse(name[6].ToString())>=0 && int.Parse(name[6].ToString())<=9;
            if(a==true && b==true && c==true && d==true && e==true)
            {
                g=1;
            }
            if(f==1 && g==1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    
    public class BillValidator{      //DO NOT change the class name
    
        public String ValidateUnitsConsumed(int UnitsConsumed)      //DO NOT change the method signature
        {
            //Implement code here
            if(UnitsConsumed<0)
            {
                return "Given units is invalid";
            }
            else
            {
                return "Given units is valid";
            }
        }
    }
}
