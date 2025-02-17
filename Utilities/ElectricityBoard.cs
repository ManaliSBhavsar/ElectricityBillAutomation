using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillAutomation      //DO NOT change the namespace name
{
    public class ElectricityBoard  //DO NOT change the class name
    {
        //Implement the property as per the description
        DBHandler dbh=new DBHandler();
        private SqlConnection sqlCon;
        public SqlConnection SqlCon
        {
            get{return this.sqlCon;}
            set{this.sqlCon=value;}
        }
        public List<ElectricityBill> eblist;
       //Implement the methods as per the description   
       public ElectricityBoard(){
           eblist=new List<ElectricityBill>();
       }
       public void AddBill(ElectricityBill ebill)
        {
            //string CS=ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
            //using(SqlConnection con=new SqlConnection(CS))
            //{
                DBHandler db=new DBHandler();
                this.SqlCon=db.GetConnection();
                SqlCommand cmd= new SqlCommand("insert into ElectricityBill values('"+ebill.ConsumerNumber+"','"+ebill.ConsumerName+"',"+ebill.UnitsConsumed+","+ebill.BillAmount+")",this.SqlCon);
                this.SqlCon.Open();
                cmd.Connection=this.SqlCon;
                cmd.ExecuteNonQuery();
                this.SqlCon.Close();
            //}
        }
        public void CalculateBill(ElectricityBill ebill)
        {
            int units=ebill.UnitsConsumed;
               if(units<=100)
               {
                   ebill.BillAmount= units*0;
               }
               else if(units<=300)
               {
                   ebill.BillAmount= (100*0)+(units-100)*1.5;
               }
               else if(units<=600)
               {
                   ebill.BillAmount= (100*0)+(200*1.5)+(units-300)*3.5;
               }
               else if(units<=1000)
               {
                   ebill.BillAmount= (100*0)+(200*1.5)+(300*3.5)+(units-600)*5.5;
               }
               else 
               {
                   ebill.BillAmount= (100*0)+(200*1.5)+(300*3.5)+(400*5.5)+(units-1000)*7.5;
               }
        }
        
        public List<ElectricityBill> Generate_N_BillDetails(int num)
        {
            //string CS=ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
            //using(SqlConnection con=new SqlConnection(CS))
            //{
                DBHandler db=new DBHandler();
                this.SqlCon=db.GetConnection();
                SqlCommand cmd= new SqlCommand("Select TOP "+num+" * from ElectricityBill ORDER BY consumer_number desc",this.SqlCon);
                this.SqlCon.Open();
                cmd.Connection=this.SqlCon;
                SqlDataReader sqldr=cmd.ExecuteReader();
                while(sqldr.Read())
                {
                    ElectricityBill eb=new ElectricityBill();
                    eb.ConsumerNumber=sqldr["consumer_number"].ToString();
                    eb.ConsumerName=sqldr["consumer_name"].ToString();
                    eb.UnitsConsumed=int.Parse(sqldr["units_consumed"].ToString());
                    eb.BillAmount=double.Parse(sqldr["bill_amount"].ToString());
                    eblist.Add(eb);
                }
                sqldr.Close();
                this.SqlCon.Close();
            //}
            return eblist;
        }
    }
}
