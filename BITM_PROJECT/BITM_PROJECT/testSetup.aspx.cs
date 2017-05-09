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
    public partial class testSetup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            this.LoadDataFromDatabase();

            if (!IsPostBack)
            {
                DropDownList1.Items.Add(new ListItem("Select", "0", true));
               

                string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                SqlConnection conn = new SqlConnection(connStr);

                string sql = "SELECT * FROM testTypeSetup";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "testTypeSetup");
                DropDownList1.DataSource = ds.Tables["testTypeSetup"];
              
                DropDownList1.DataTextField = "typename";
                DropDownList1.DataValueField = "typename";

                 DropDownList1.DataBind();
                 DropDownList1.Items.Insert(0, new ListItem("-----Select----", "0"));
            }

            
            
            
        }

        private void LoadDataFromDatabase()
        {


            string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);

            string sql = "SELECT testname,fee,testtype FROM testsetup ";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "testsetup");
            ds.Tables["testsetup"].PrimaryKey = new DataColumn[] { ds.Tables["testsetup"].Columns["id"] };
            Cache["DATASET"] = ds;
            Cache["ADAPTER"] = adapter;

            GridView1.DataSource = ds.Tables["testsetup"];
            GridView1.DataBind();


        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Write(DropDownList1.SelectedItem.ToString());
                string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                SqlConnection conn = new SqlConnection(connStr);

                string sql = "insert into   testsetup values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + DropDownList1.SelectedItem.ToString() + "')";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "testsetup");
               
                Response.Redirect("~/testSetup.aspx");

            }
            catch
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('PLEASE ENTER AN UNIQUE TEST NAME')</script>");


            }
        }
    }
}