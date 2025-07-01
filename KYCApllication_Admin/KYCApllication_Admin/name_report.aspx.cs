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
   
    public partial class name_report : System.Web.UI.Page
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
  FROM [kycdetail] WHERE [Name]='" + Name + "' AND YearsOfServiceBusinessHA !='' order by Create_at desc", con);
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
            search_results.Text ="( "+ pagedData.DataSourceCount + " Records found !!"+" )";
            lblfromto.Text = "KYC Application serch by Name'" + Name + "'";

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
            paginationPanel.Controls.Clear();

            // Create a link to the first page
            if (startPage > 0)
            {
                HyperLink firstLink = new HyperLink();
                firstLink.NavigateUrl = Request.Url.AbsolutePath + "?page=0";
                firstLink.Text = "First Page";
                firstLink.CssClass = "pagination-link";
                paginationPanel.Controls.Add(firstLink);
            }

            // Create a link to the previous set of pages
            if (startPage > 0)
            {
                int prevPage = startPage - 1;
                HyperLink prevLink = new HyperLink();
                prevLink.NavigateUrl = Request.Url.AbsolutePath + "?page=" + prevPage.ToString();
                prevLink.Text = "Prev";
                prevLink.CssClass = "pagination-link";
                paginationPanel.Controls.Add(prevLink);
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

            // Create a link to the next set of pages
            if (endPage < pagedData.PageCount - 1)
            {
                int nextPage = endPage + 1;
                HyperLink nextLink = new HyperLink();
                nextLink.NavigateUrl = Request.Url.AbsolutePath + "?page=" + nextPage.ToString();
                nextLink.Text = "Next";
                nextLink.CssClass = "pagination-link";
                paginationPanel.Controls.Add(nextLink);
            }

            // Create a link to the last page
            if (endPage < pagedData.PageCount - 1)
            {
                int lastPage = pagedData.PageCount - 1; // Calculate the last page index
                HyperLink lastLink = new HyperLink();
                lastLink.NavigateUrl = Request.Url.AbsolutePath + "?page=" + lastPage.ToString();
                lastLink.Text = "Last Page";
                lastLink.CssClass = "pagination-link";
                paginationPanel.Controls.Add(lastLink);
            }

        }

        protected void excelexport_Click(object sender, EventArgs e)
        {

            string Name = Convert.ToString(Session["Name"]);

            string query = @"
        SELECT kd.[id], 
                kd.[Kycid],
                kd.[Name],
                kd.[acoount_no],
                kd.[cust_no], 
                kd.[mobail_no],
                kd.[accout_type],
                kd.[pancardno_HA],
                kd.[pancardverify_HA],
                kd.[pancardno_HB], 
                kd.[pancardverify_HB],
                kd.[Aadharcardno_HA], 
                kd.[Aadharcardverify_HA], 
                kd.[Aadharcardno_HB], 
                kd.[Aadharcardverify_HB], 
                kd.[Alternativmob_HA],
                kd.[Alternativmob_HB],
                kd.[Email_HA], 
                kd.[Email_HB], 
                kd.[CurrentAdd_HA], 
                kd.[CurrentAdd_HB], 
                kd.[IncomeSource_HA], 
                kd.[IncomeSource_HB],
                kd.[empbussname_HA], 
                kd.[empbussname_HB],
                kd.[worktype_HA], 
                kd.[worktype_HB],
                kd.[Incomefrom_HA],
                kd.[Incomefrom_HB], 
                kd.[YearsOfServiceBusinessHA],
                kd.[PancardFileNm],
                kd.[AadharcardFileNm],
                kd.[YearsOfServiceBusinessHB],
                kd.[Create_at],
                kd.[status],
                kd.[create_date], 
                kd.[approved_by],
                kd.[reply_date],
                pad.[Pan_number] AS [Pan_Number_PanApi], 
                pad.[fullname] AS [Fullname_PanApi],
                pad.[fullname2] AS [Fullname2_PanApi],
                aad.[aadhar_card] AS [Aadhar_card_AadharApi], 
                aad.[fullname] AS [Fullname_AadharApi],
                aad.[fullname2] AS [Fullname2_AadharApi],
                aad.[address] AS [address_AadharApi],
                aad.[address2] AS [address2_AadharApi],
                aad.[DOB] AS [DOB_AadharApi],
                aad.[DOB2] AS [DOB2_AadharApi]
                        FROM [kycdetail] kd
                        LEFT JOIN [PanApi_data] pad ON kd.[Kycid] = pad.[kyc_id]
                        LEFT JOIN [AadharApi_data] aad ON kd.[Kycid] = aad.[kycid]
                        WHERE kd.[Name]='" + Name + "' AND kd.[YearsOfServiceBusinessHA] != '' order by Create_at desc";

            using (SqlConnection con = new SqlConnection(strcon))
            {
                SqlCommand command = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                GridView gridView = new GridView();
                gridView.DataSource = reader;
                gridView.AutoGenerateColumns = false;
                gridView.HeaderStyle.BackColor = System.Drawing.Color.LightGray; // Set header style
                gridView.HeaderStyle.Font.Bold = true;

                // Define BoundFields for each column with desired header names
                gridView.Columns.Add(new BoundField { HeaderText = "KYC ID", DataField = "Kycid" });
                gridView.Columns.Add(new BoundField { HeaderText = "Name", DataField = "Name" });
                gridView.Columns.Add(new BoundField { HeaderText = "Account Number", DataField = "acoount_no" });
                gridView.Columns.Add(new BoundField { HeaderText = "Customer Number", DataField = "cust_no" });
                gridView.Columns.Add(new BoundField { HeaderText = "Mobile Number", DataField = "mobail_no" });
                gridView.Columns.Add(new BoundField { HeaderText = "Account Type", DataField = "accout_type" });

                //gridView.Columns.Add(new BoundField { });

                //Holder A

                gridView.Columns.Add(new BoundField { HeaderText = "Name as per Pan card  Holder ", DataField = "Fullname_PanApi" });
                gridView.Columns.Add(new BoundField { HeaderText = "Pan card Number Holder ", DataField = "pancardno_HA" });
                gridView.Columns.Add(new BoundField { HeaderText = "Pan card Status Holder ", DataField = "pancardverify_HA" });
                gridView.Columns.Add(new BoundField { HeaderText = "Name as per Aadhar card Holder ", DataField = "Fullname_AadharApi" });
                gridView.Columns.Add(new BoundField { HeaderText = "Address as per Aadhar card Holder ", DataField = "address_AadharApi" });
                gridView.Columns.Add(new BoundField { HeaderText = "DOB as per Aadhar card Holder ", DataField = "DOB_AadharApi" });
                gridView.Columns.Add(new BoundField { HeaderText = "Aadhar card Number Holder ", DataField = "Aadharcardno_HA" });
                gridView.Columns.Add(new BoundField { HeaderText = "Aadhar Status Holder ", DataField = "Aadharcardverify_HA" });
                gridView.Columns.Add(new BoundField { HeaderText = "Alternative Mobile Number Holder ", DataField = "Alternativmob_HA" });
                gridView.Columns.Add(new BoundField { HeaderText = "Email Holder ", DataField = "Email_HA" });
                gridView.Columns.Add(new BoundField { HeaderText = "Current Address Holder ", DataField = "CurrentAdd_HA" });
                gridView.Columns.Add(new BoundField { HeaderText = "Income Source Holder ", DataField = "IncomeSource_HA" });
                gridView.Columns.Add(new BoundField { HeaderText = "Industry/ Business name Holder ", DataField = "empbussname_HA" });
                gridView.Columns.Add(new BoundField { HeaderText = "Work Type Holder ", DataField = "worktype_HA" });
                gridView.Columns.Add(new BoundField { HeaderText = "Income From Holder ", DataField = "Incomefrom_HA" });
                gridView.Columns.Add(new BoundField { HeaderText = "Years of service/business Holder ", DataField = "YearsOfServiceBusinessHA" });
                gridView.Columns.Add(new BoundField { HeaderText = "Pan Card Filename ", DataField = "PancardFileNm" });
                gridView.Columns.Add(new BoundField { HeaderText = "Aadhar Card Filename ", DataField = "AadharcardFileNm" });
                //gridView.Columns.Add(new BoundField { });

                //Holder B

                //gridView.Columns.Add(new BoundField { HeaderText = "Name as per Pan card  Holder B", DataField = "Fullname2_PanApi" });
                //gridView.Columns.Add(new BoundField { HeaderText = "Pan card Number Holder B", DataField = "pancardno_HB" });
                //gridView.Columns.Add(new BoundField { HeaderText = "Pan card Status Holder B", DataField = "pancardverify_HB" });
                //gridView.Columns.Add(new BoundField { HeaderText = "Name as per Aadhar card Holder B", DataField = "Fullname2_AadharApi" });
                //gridView.Columns.Add(new BoundField { HeaderText = "Address as per Aadhar card Holder B", DataField = "address2_AadharApi" });
                //gridView.Columns.Add(new BoundField { HeaderText = "DOB as per Aadhar card Holder B", DataField = "DOB2_AadharApi" });
                //gridView.Columns.Add(new BoundField { HeaderText = "Aadhar card Number Holder B", DataField = "Aadharcardno_HB" });
                //gridView.Columns.Add(new BoundField { HeaderText = "Aadhar Status Holder B", DataField = "Aadharcardverify_HB" });
                //gridView.Columns.Add(new BoundField { HeaderText = "Alternative Mobile Number Holder B", DataField = "Alternativmob_HB" });
                //gridView.Columns.Add(new BoundField { HeaderText = "Email Holder B", DataField = "Email_HB" });
                //gridView.Columns.Add(new BoundField { HeaderText = "Current Address Holder B", DataField = "CurrentAdd_HB" });
                //gridView.Columns.Add(new BoundField { HeaderText = "Income Source Holder B", DataField = "IncomeSource_HB" });
                //gridView.Columns.Add(new BoundField { HeaderText = "Industry/ Business name Holder B", DataField = "empbussname_HB" });
                //gridView.Columns.Add(new BoundField { HeaderText = "Work Type Hoalder B", DataField = "worktype_HB" });
                //gridView.Columns.Add(new BoundField { HeaderText = "Income From Holder B", DataField = "Incomefrom_HB" });
                //gridView.Columns.Add(new BoundField { HeaderText = "Years of service/business Holder B", DataField = "YearsOfServiceBusinessHB" });
                //gridView.Columns.Add(new BoundField { });

                //gridView.Columns.Add(new BoundField { HeaderText = "Create Date", DataField = "Create_at" });
                gridView.Columns.Add(new BoundField { HeaderText = "Status", DataField = "status" });
                gridView.Columns.Add(new BoundField { HeaderText = "Submitted Date", DataField = "Create_at", DataFormatString = "{0:yyyy-MM-dd}" });
                gridView.Columns.Add(new BoundField { HeaderText = "Approved By", DataField = "approved_by" });
                gridView.Columns.Add(new BoundField { HeaderText = "Reply Date", DataField = "reply_date", DataFormatString = "{0:yyyy-MM-dd}" });

                gridView.DataBind();
                StringWriter stringWriter = new StringWriter();
                HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
                gridView.RenderControl(htmlTextWriter);
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", "attachment;filename=kycdetails.xls");
                Response.Charset = "";
                Response.Write(stringWriter.ToString());
                Response.End();
            }
        }
    }
}