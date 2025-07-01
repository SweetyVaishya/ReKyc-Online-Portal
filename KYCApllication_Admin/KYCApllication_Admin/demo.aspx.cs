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
    public partial class demo : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["kycdetail"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
           


            SqlConnection con = new SqlConnection(strcon);

            string Kycid = Convert.ToString(Session["Kycid"]);

            SqlDataAdapter sda = new SqlDataAdapter(@"SELECT [id]
                  ,[Kycid]
                  ,[Name]
                  ,[acoount_no]
                  ,[mobail_no]
                  ,[accout_type]
                  ,[pancardno_HA]
                  ,[pancardverify_HA]
                  ,[pancardno_HB]
                  ,[pancardverify_HB]
                  ,[Aadharcardno_HA]
                  ,[Aadharcardverify_HA]
                  ,[Aadharcardno_HB]
                  ,[Aadharcardverify_HB]
                  ,[Alternativmob_HA]
                  ,[Alternativmob_HB]
                  ,[Email_HA]
                  ,[Email_HB]
                  ,[CurrentAdd_HA]
                  ,[CurrentAdd_HB]
                  ,[IncomeSource_HA]
                  ,[IncomeSource_HB]
                  ,[empbussname_HA]
                  ,[empbussname_HB]
                  ,[worktype_HA]
                  ,[worktype_HB]
                  ,[Incomefrom_HA]
                  ,[Incometo_HA]
                  ,[Incomefrom_HB]
                  ,[Incometo_HB]
                  ,[Create_at]
                  ,[status]
                  ,[create_date]
                  ,[reply_date]
              FROM [kycdetail]", con);
            con.Open();
            DataTable dt = new DataTable();
            sda.Fill(dt);

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
            lblfromto.Text = " KYC Application recieved all record '" + Kycid + "'";

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