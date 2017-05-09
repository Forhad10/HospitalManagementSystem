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
    public partial class Test_type_setup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadDataFromDatabase();
        }
     

        private void LoadDataFromDatabase()
        {


            string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);

            string sql = "SELECT * FROM testTypeSetup order by typename";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "testTypeSetup");
//ds.Tables["testTypeSetup"].PrimaryKey = new DataColumn[] { ds.Tables["testTypeSetup"].Columns["id"] };
            Cache["DATASET"] = ds;
            Cache["ADAPTER"] = adapter;

            GridView1.DataSource = ds.Tables["testTypeSetup"];
            GridView1.DataBind();


        }






        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                SqlConnection conn = new SqlConnection(connStr);

                string sql = "insert into   testTypeSetup values('" + TextBox1.Text + "')";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "testTypeSetup");
                TextBox1.Text = "";
                Response.Redirect("~/Test_type_setup.aspx");
            }
            catch
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('PLEASE ENTER AN UNIQUE NAME')</script>");
            
            
            }
          
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/testSetup.aspx");
        }
    }
}