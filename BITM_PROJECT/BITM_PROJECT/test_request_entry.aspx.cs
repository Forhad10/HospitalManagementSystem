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
    public partial class test_request_entry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                SqlConnection conn = new SqlConnection(connStr);

                string sql = "SELECT * FROM testsetup";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "testsetup");
                DropDownList1.DataSource = ds.Tables["testsetup"];
                DropDownList1.DataTextField = "testname";
                DropDownList1.DataValueField = "fee";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, new ListItem("-----Select----", "0"));
            }
            

            billdate.Text = DateTime.Now.ToString("M/d/yyyy");

            if (!IsPostBack)
            {
                Calendar1.Visible = false;
            }
            
            if (!IsPostBack)
            {
                totalTextBox.Text = "0";
                dueTextBox.Text = "0";
            }
            piadTextBox.Text = "0";
            

            int PostBackCount = 0;
            if (IsPostBack == true)
            {
                if (ViewState["VisitCount"] == null)
                {
                    ViewState["VisitCount"] = PostBackCount;
                    // writing Values in ViewState
                    BillTextBox.Text = randomNumber();
                }
               else
                {
                    ViewState["VisitCount"] = Convert.ToInt32(ViewState["VisitCount"]) + 1;
                    // writing values in viewstate
                }

                // lblMsg.Text = "Page Visit Count is  " + ViewState["VisitCount"].ToString(); // reading Values from viewstate
                }
             }


        protected void testDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            feeTextBox.Text = DropDownList1.SelectedValue;

           


        }

        public string randomNumber()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            int numIterations = 0;
            numIterations = rand.Next(1, 100);
            return "SL" + numIterations.ToString();

        }
        private void BindGrid(int rowcount)
        {

            DataTable dt = new DataTable();

            DataRow dr;

            dt.Columns.Add(new System.Data.DataColumn("Test", typeof(String)));

            dt.Columns.Add(new System.Data.DataColumn("Fee", typeof(String)));

            dt.Columns.Add(new System.Data.DataColumn("Bid", typeof(String)));



            if (ViewState["CurrentData"] != null)
            {

                for (int i = 0; i < rowcount + 1; i++)
                {

                    dt = (DataTable)ViewState["CurrentData"];

                    if (dt.Rows.Count > 0)
                    {

                        dr = dt.NewRow();

                        dr[0] = dt.Rows[0][0].ToString();



                    }

                }

                dr = dt.NewRow();

                dr[0] = DropDownList1.SelectedItem;

                dr[1] = feeTextBox.Text;

                dr[2] = BillTextBox.Text;

                dt.Rows.Add(dr);



            }

            else
            {

                dr = dt.NewRow();

                dr[0] = DropDownList1.SelectedItem;


                dr[1] = feeTextBox.Text;

                dr[2] = BillTextBox.Text;



                dt.Rows.Add(dr);



            }



            // If ViewState has a data then use the value as the DataSource

            if (ViewState["CurrentData"] != null)
            {

                GridView1.DataSource = (DataTable)ViewState["CurrentData"];

                GridView1.DataBind();

            }

            else
            {

                // Bind GridView with the initial data assocaited in the DataTable

                GridView1.DataSource = dt;

                GridView1.DataBind();



            }

            // Store the DataTable in ViewState to retain the values

            ViewState["CurrentData"] = dt;



        }



    protected void Button1_Click1(object sender, EventArgs e)
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                SqlConnection conn = new SqlConnection(connStr);

                string sql = "insert into   patient(bid,name,Date,mobile,billdate) values('" + BillTextBox.Text + "','" + nameTextBox.Text + "','" + dateTextBox.Text + "','" + mobileTextBox.Text + "','" + billdate.Text + "')";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "patient");
            }

            catch
            {


            }

          if (ViewState["CurrentData"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentData"];
                int count = dt.Rows.Count;
                BindGrid(count);
            }
            else
            {
                BindGrid(1);
            }
            //TextBox1.Text = string.Empty;

           // TextBox1.Focus();


          int a = Convert.ToInt32(feeTextBox.Text);
          int b = Convert.ToInt32(totalTextBox.Text);
          int c = a + b;
          totalTextBox.Text = Convert.ToString(c);
          dueTextBox.Text = Convert.ToString(c);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);

            foreach (GridViewRow gridRow in GridView1.Rows)
            {
                string sql = "insert into   bill (test, fee,bid,billdate ) values('" + gridRow.Cells[1].Text + "','" + gridRow.Cells[2].Text + "','" + gridRow.Cells[3].Text + "','" + billdate.Text + "')";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "bill");
            }

            nameTextBox.Text = " ";
            dateTextBox.Text = " ";
            mobileTextBox.Text = " ";
            feeTextBox.Text = " ";
            

            try
            {
                string connStr1 = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                SqlConnection conn1 = new SqlConnection(connStr1);

                string sql1 = "update  patient set total='" + totalTextBox.Text + "', paid='" + piadTextBox.Text + "', due='" + dueTextBox .Text+ "' where bid='" + BillTextBox.Text + "'";
                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, conn1);
                SqlCommandBuilder builder1 = new SqlCommandBuilder(adapter1);
                DataSet ds1 = new DataSet();
                adapter1.Fill(ds1, "patient");
            }

            catch
            {


            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            dateTextBox.Text = Calendar1.SelectedDate.ToString();
            Calendar1.Visible = false;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar1.Visible)
            {
                Calendar1.Visible = false;

            }
            else
            {
                Calendar1.Visible = true;
            
            }
           
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // feeTextBox.Text = testDropDownList.SelectedValue;
        }

        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            feeTextBox.Text = DropDownList1.SelectedValue;
        }

        

       
    }
}