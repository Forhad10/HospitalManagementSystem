using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

namespace BITM_PROJECT
{
    public partial class unpaid_bill_report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Calendar1.Visible = false;
                Calendar2.Visible = false;
            }

        }

        private void LoadDataFromDatabase()
        {


            string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);

            string sql = "select bid,name,mobile,due from patient where due>0 and billdate between '" + TextBox1.Text + "' and '" + TextBox2.Text + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "patient");
            ds.Tables["patient"].PrimaryKey = new DataColumn[] { ds.Tables["patient"].Columns["bid"] };
            Cache["DATASET"] = ds;
            Cache["ADAPTER"] = adapter;

            GridView1.DataSource = ds.Tables["patient"];
            GridView1.DataBind();


        }
        private void LoadDataFromDatabase1()
        {


            string connStr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);

            string sql = "select sum(due) 'sum' from patient  where billdate between '" + TextBox1.Text + "' and '" + TextBox2.Text + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

            DataTable dt = new DataTable();

            adapter.Fill(dt);


            foreach (DataRow dr in dt.Rows)
            {
                TextBox3.Text = dr["sum"].ToString();
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            this.LoadDataFromDatabase();
            this.LoadDataFromDatabase1();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            PdfPTable pdfTable = new PdfPTable(GridView1.HeaderRow.Cells.Count);

            foreach (TableCell headercell in GridView1.HeaderRow.Cells)
            {

                PdfPCell pdfcell = new PdfPCell(new Phrase(headercell.Text));
                pdfTable.AddCell(pdfcell);

            }

            foreach (GridViewRow gridviewrow in GridView1.Rows)
            {
                foreach (TableCell tablecell in gridviewrow.Cells)
                {

                    PdfPCell pdfcell = new PdfPCell(new Phrase(tablecell.Text));
                    pdfTable.AddCell(pdfcell);

                }

            }

            Document pdfdocument = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            PdfWriter.GetInstance(pdfdocument, Response.OutputStream);
            pdfdocument.Open();
            pdfdocument.Add(pdfTable);
            pdfdocument.Close();

            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition", "attachment;filename=UnpaidBillReport.Pdf");
            Response.Write(pdfdocument);
            Response.Flush();
            Response.End();
            
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

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar2.Visible)
            {
                Calendar2.Visible = false;

            }
            else
            {
                Calendar2.Visible = true;

            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBox1.Text = Calendar1.SelectedDate.ToString();
            Calendar1.Visible = false;
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            TextBox2.Text = Calendar2.SelectedDate.ToString();
            Calendar2.Visible = false;
        }
    }
}