using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BITM_PROJECT
{
    public partial class payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);

            string sql = "SELECT * FROM bill where bid= '" + TextBox1.Text + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "bill");
            // ds.Tables["bill"].PrimaryKey = new DataColumn[] { ds.Tables["bill"].Columns["si"] };
            //Cache["DATASET"] = ds;
            //Cache["ADAPTER"] = adapter;

            GridView1.DataSource = ds.Tables["bill"];
            GridView1.DataBind();


            conn.Open();
            string sql1 = "SELECT * FROM patient where bid= '" + TextBox1.Text + "'";
            SqlCommand command=new SqlCommand(sql1,conn);
            SqlDataReader rdr = command.ExecuteReader();
            if (rdr.Read())
            {
                int total = Convert.ToInt32((rdr["total"]));
                int paid = Convert.ToInt32((rdr["paid"]));
                int due = Convert.ToInt32((rdr["due"]));


                Label1.Text = total.ToString();
                paidLabel2.Text = paid.ToString();
                dueLabel3.Text = due.ToString();

                rdr.Close();
                conn.Close();

            }

            else
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('PLEASE ENTER A VALID SERIAL NUMBER')</script>");

            }
           }

        protected void Button2_Click(object sender, EventArgs e)
        {
          


            try
            {
                
                int ammount = Convert.ToInt32(ammountTextBox.Text);
                int due = Convert.ToInt32(dueLabel3.Text);
                int paid = Convert.ToInt32(paidLabel2.Text);

                if (ammount <= due && ammount>0)
                {
                    due = due - ammount;
                    paid = paid + ammount;
                    dueLabel3.Text = due.ToString();

                    paidLabel2.Text = paid.ToString();

                    string connStr1 = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                    SqlConnection conn1 = new SqlConnection(connStr1);

                    string sql1 = "update  patient set  paid='" + paidLabel2.Text + "', due='" + dueLabel3.Text + "' where bid='" + TextBox1.Text + "'";
                    SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, conn1);
                    SqlCommandBuilder builder1 = new SqlCommandBuilder(adapter1);
                    DataSet ds1 = new DataSet();
                    adapter1.Fill(ds1, "patient");
                }
                else
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('AMMOUNT CAN NOT MORE THAN DUE AND AMMOUNT CAN NOT BE NEGETIVE')</script>");
                }

                
            }

            catch
            {

                Response.Write("<script LANGUAGE='JavaScript' >alert('PLEASE PAY SOME AMMOUNT')</script>");
            }

        }

        }

      
    }
