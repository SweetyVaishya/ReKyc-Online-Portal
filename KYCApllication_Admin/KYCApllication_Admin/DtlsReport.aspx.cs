using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KYCApllication_Admin
{
    public partial class DtlsReport : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["kycdetail"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {


            SqlConnection con = new SqlConnection(strcon);

            if (string.IsNullOrEmpty(Convert.ToString(Session["userid"])))
            {
                Response.Redirect("Login.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
            }

            string From = Convert.ToString(Session["from"]);
                string To = Convert.ToString(Session["to"]);

            SqlDataAdapter sda = new SqlDataAdapter(@"SELECT [id]
      ,[AccountNo]
      ,[Name]
      ,[Mob_no]
      ,[cust_no]
      ,[Address]
      ,[Address2]
      ,[Address3]
      ,[pin_code]
      ,[pancard]
      ,[Risk]
     ,[added_on]
  FROM  [TblOmtDetail] where added_on between '" + From+ "' AND '" + To + "' ", con);

            con.Open();
            DataTable dt = new DataTable();
            sda.Fill(dt);

            // Add a new column for serial number
            dt.Columns.Add("SrNo", typeof(int));

            // Calculate serial number for each row
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["SrNo"] = (i + 1);
            }

            int pageSize = 10;
            //int currentPage = YourGridView.PageIndex;


            // Get the current page index from the QueryString
            int currentPage = 0;


            // int currentSerialNumber = (currentPage * pageSize) + Container.DataItemIndex + 1;
            if (Request.QueryString["page"] != null)
            {
                currentPage = Int32.Parse(Request.QueryString["page"]);
            }

            // Create a new PagedDataSource object and set its properties
            PagedDataSource pagedData = new PagedDataSource();
            pagedData.DataSource = dt.DefaultView;
            pagedData.AllowPaging = true;
            pagedData.PageSize = pageSize;
            pagedData.CurrentPageIndex = currentPage;


            // Bind the PagedDataSource to the Repeater control
            Repeater2.DataSource = pagedData;
            Repeater2.DataBind();
            search_results.Text = "(" + pagedData.DataSourceCount + " Records found !!" + ")";
            lblfromto.Text = "Details search by from '" + From + "'  to '" + To + "'";

            // Create pagination links
            int maxVisiblePages = 3; // Number of pages to display at a time
            int startPage = Math.Max(0, currentPage - (maxVisiblePages / 2));
            int endPage = Math.Min(startPage + maxVisiblePages - 1, pagedData.PageCount - 1);

            if (endPage - startPage < maxVisiblePages - 1)
            {
                startPage = Math.Max(0, endPage - maxVisiblePages + 1);
            }

            // Create page number links
            for (int i = startPage; i <= endPage; i++)
            {
                HyperLink link = new HyperLink();
                link.NavigateUrl = Request.Url.AbsolutePath + "?page=" + i.ToString();
                link.Text = (i + 1).ToString();
                if (i == currentPage)
                {
                    link.CssClass = "active";
                }
                link.CssClass += " pagination-link";
                paginationPanel.Controls.Add(link);
            }

            // Create a link to the previous set of pages
            if (startPage > 0)
            {
                HyperLink prevLink = new HyperLink();
                prevLink.NavigateUrl = Request.Url.AbsolutePath + "?page=" + (startPage - 1).ToString();
                prevLink.Text = "First Page";
                prevLink.CssClass = "pagination-link";
                paginationPanel.Controls.AddAt(0, prevLink);
            }

            // Create a link to the next set of pages
            if (endPage < pagedData.PageCount - 1)
            {
                HyperLink nextLink = new HyperLink();
                nextLink.NavigateUrl = Request.Url.AbsolutePath + "?page=" + (endPage + 1).ToString();
                nextLink.Text = "Last Page";
                nextLink.CssClass = "pagination-link";
                paginationPanel.Controls.Add(nextLink);
            }
        }


        protected void excelexport_Click(object sender, EventArgs e)
        {
            string Name = Convert.ToString(Session["Name"]);
            string acoount_no = Convert.ToString(Session["acoount_no"]);
            string From = Convert.ToString(Session["From"]);
            string To = Convert.ToString(Session["To"]);

            string query = @"SELECT [id]
      ,[AccountNo]
      ,[Name]
      ,[Mob_no]
      ,[cust_no]
      ,[Address]
      ,[Address2]
      ,[Address3]
      ,[pin_code]
      ,[pancard]
      ,[Risk]
     ,[added_on]
  FROM  [TblOmtDetail] where added_on between '" + From + "' AND '" + To + "' ";


            using (SqlConnection con = new SqlConnection(strcon))
            {
                SqlCommand command = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                GridView gridView = new GridView();
                gridView.DataSource = reader;
                gridView.AutoGenerateColumns = false; // Disable auto-generation of columns
                gridView.HeaderStyle.BackColor = System.Drawing.Color.LightGray; // Set header style
                gridView.HeaderStyle.Font.Bold = true;

                //Define BoundFields for each column with desired header names
                gridView.Columns.Add(new BoundField { HeaderText = "ID", DataField = "id" });
                gridView.Columns.Add(new BoundField { HeaderText = "Account Number", DataField = "AccountNo" });
                gridView.Columns.Add(new BoundField { HeaderText = "Name", DataField = "Name" });
                gridView.Columns.Add(new BoundField { HeaderText = "Mobile Number", DataField = "Mob_no" });
                gridView.Columns.Add(new BoundField { HeaderText = "Customer Number", DataField = "cust_no" });
                gridView.Columns.Add(new BoundField { HeaderText = "Address", DataField = "Address" });
                gridView.Columns.Add(new BoundField { HeaderText = "Address2", DataField = "Address2" });
                gridView.Columns.Add(new BoundField { HeaderText = "Address3", DataField = "Address3" });
                gridView.Columns.Add(new BoundField { HeaderText = "Pin Code", DataField = "pin_code" });
                gridView.Columns.Add(new BoundField { HeaderText = "Pancard Number", DataField = "pancard" });
                gridView.Columns.Add(new BoundField { HeaderText = "Add on", DataField = "added_on", DataFormatString = "{0:yyyy-MM-dd}" });
                gridView.Columns.Add(new BoundField { HeaderText = "Risk", DataField = "Risk" });

                gridView.DataBind();
               StringWriter stringWriter = new StringWriter();
                HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
                gridView.RenderControl(htmlTextWriter);
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", "attachment;filename=kycdetail.xls");
                Response.Charset = "";
                Response.Write(stringWriter.ToString());
                Response.End();
            }
        }

    }
}
