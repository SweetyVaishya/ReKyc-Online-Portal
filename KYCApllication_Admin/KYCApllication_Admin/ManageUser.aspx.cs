using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KYCApllication_Admin
{
    public partial class ManageUser : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["kycdetail"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strcon);




            if (string.IsNullOrEmpty(Convert.ToString(Session["userid"])))
            {
                Response.Redirect("Login.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
            }

            string Name = Convert.ToString(Session["Name"]);

            SqlDataAdapter sda = new SqlDataAdapter(@"SELECT  [id]
                  ,[username]
                  ,[password]
                  ,[craete_at]
                  ,[status]
                  ,[name]
              FROM [kyclogin] ", con);
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
            search_results.Text = "( " + pagedData.DataSourceCount + " Records found !!" + " )";
            // lblfromto.Text = "KYC Application serch by Name'" + Name + "'";

            // Create pagination links
            int pagesCount = pagedData.PageCount;
            for (int i = 0; i < pagesCount; i++)
            {
                HyperLink link = new HyperLink();
                link.NavigateUrl = Request.Url.AbsolutePath + "?page=" + i.ToString();
                link.Text = (i + 1).ToString();
                if (i == currentPage)
                {
                    link.CssClass = "active";
                }

                paginationPanel.Controls.Add(link);
            }

            // Show or hide the pagination panel based on whether there is more than one page
            paginationPanel.Visible = pagesCount > 1;
        }
    }
}