using System;
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;
using System.Configuration;
using System.Web.UI;
using OfficeOpenXml;

namespace KYCApllication_Admin
{
    public partial class UpdateAccountData : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["kycdetail"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["userid"])))
            {
                Response.Redirect("Login.aspx?url=" + Server.UrlEncode(Request.Url.AbsoluteUri));
            }

            SqlConnection con = new SqlConnection(strcon);

            SqlCommand cmd = new SqlCommand(@"delete from TblOmtDetailLatest",con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        protected void insert_Click(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // Check if a file is uploaded
            if (!FileUpload1.HasFile)
            {
                lblerror.Text = "<span style='color:red'>Please select a file to upload.</span>";
                return;
            }

            string path = Server.MapPath("~/ExcelFile/") + FileUpload1.FileName;
            FileUpload1.SaveAs(path);

            // Ensure the file exists
            if (!File.Exists(path))
            {
                lblerror.Text = "<span style='color:red'>File not found.</span>";
                return;
            }

            try
            {
                using (var package = new ExcelPackage(new FileInfo(path)))
                {
                    var worksheet = package.Workbook.Worksheets["Sheet1"];
                    if (worksheet == null)
                    {
                        lblerror.Text = "<span style='color:red'>Worksheet not found.</span>";
                        return;
                    }

                    using (var conn = new SqlConnection(strcon))
                    {
                        conn.Open();

                        // Iterate through each row in the worksheet
                        for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                        {
                            var accountNo = worksheet.Cells[row, 1].Value?.ToString()?.Trim();

                            // Skip rows with empty or null AccountNo
                            if (string.IsNullOrEmpty(accountNo))
                            {
                                continue; // Skip this row if AccountNo is empty
                            }

                            var name = worksheet.Cells[row, 2].Value?.ToString();
                            var mobNo = worksheet.Cells[row, 3].Value?.ToString();
                            var custNo = worksheet.Cells[row, 4].Value?.ToString();
                            var address = worksheet.Cells[row, 5].Value?.ToString();
                            var address2 = worksheet.Cells[row, 6].Value?.ToString();
                            var address3 = worksheet.Cells[row, 7].Value?.ToString();
                            var pinCode = worksheet.Cells[row, 8].Value?.ToString();
                            var pancard = worksheet.Cells[row, 9].Value?.ToString();
                            var addedOn = worksheet.Cells[row, 10].Value as DateTime?;
                            var risk = worksheet.Cells[row, 11].Value?.ToString();

                            // Insert data into TblOmtDetailLatest
                            var insertLatestQuery = @"INSERT INTO TblOmtDetailLatest 
                        ([AccountNo], [Name], [Mob_no], [cust_no], [Address], [Address2], [Address3], [pin_code], [pancard], [added_on], [Risk])
                        VALUES (@AccountNo, @Name, @Mob_no, @cust_no, @Address, @Address2, @Address3, @pin_code, @pancard, @added_on, @Risk)";

                            using (var cmd = new SqlCommand(insertLatestQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@AccountNo", accountNo);
                                cmd.Parameters.AddWithValue("@Name", name ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@Mob_no", mobNo ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@cust_no", custNo ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@Address", address ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@Address2", address2 ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@Address3", address3 ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@pin_code", pinCode ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@pancard", pancard ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@added_on", addedOn ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@Risk", risk ?? (object)DBNull.Value);
                                cmd.ExecuteNonQuery();
                            }

                            // Check if AccountNo exists in TblOmtDetail
                            var checkQuery = "SELECT COUNT(*) FROM TblOmtDetail WHERE AccountNo = @AccountNo";
                            using (var checkCmd = new SqlCommand(checkQuery, conn))
                            {
                                checkCmd.Parameters.AddWithValue("@AccountNo", accountNo);
                                int count = (int)checkCmd.ExecuteScalar();

                                if (count > 0)
                                {
                                    // Update TblOmtDetail if AccountNo exists
                                    var updateQuery = @"UPDATE TblOmtDetail
                                SET [Name] = @Name,
                                    [Mob_no] = @Mob_no,
                                    [cust_no] = @cust_no,
                                    [Address] = @Address,
                                    [Address2] = @Address2,
                                    [Address3] = @Address3,
                                    [pin_code] = @pin_code,
                                    [pancard] = @pancard,
                                    [added_on] = @added_on,
                                    [Risk] = @Risk
                                WHERE [AccountNo] = @AccountNo";

                                    using (var updateCmd = new SqlCommand(updateQuery, conn))
                                    {
                                        updateCmd.Parameters.AddWithValue("@AccountNo", accountNo);
                                        updateCmd.Parameters.AddWithValue("@Name", name ?? (object)DBNull.Value);
                                        updateCmd.Parameters.AddWithValue("@Mob_no", mobNo ?? (object)DBNull.Value);
                                        updateCmd.Parameters.AddWithValue("@cust_no", custNo ?? (object)DBNull.Value);
                                        updateCmd.Parameters.AddWithValue("@Address", address ?? (object)DBNull.Value);
                                        updateCmd.Parameters.AddWithValue("@Address2", address2 ?? (object)DBNull.Value);
                                        updateCmd.Parameters.AddWithValue("@Address3", address3 ?? (object)DBNull.Value);
                                        updateCmd.Parameters.AddWithValue("@pin_code", pinCode ?? (object)DBNull.Value);
                                        updateCmd.Parameters.AddWithValue("@pancard", pancard ?? (object)DBNull.Value);
                                        updateCmd.Parameters.AddWithValue("@added_on", addedOn ?? (object)DBNull.Value);
                                        updateCmd.Parameters.AddWithValue("@Risk", risk ?? (object)DBNull.Value);
                                        updateCmd.ExecuteNonQuery();
                                    }
                                }
                                else
                                {
                                    // Insert data into TblOmtDetail if AccountNo doesn't exist
                                    var insertQuery = @"INSERT INTO TblOmtDetail
                                ([AccountNo], [Name], [Mob_no], [cust_no], [Address], [Address2], [Address3], [pin_code], [pancard], [added_on], [Risk])
                                VALUES (@AccountNo, @Name, @Mob_no, @cust_no, @Address, @Address2, @Address3, @pin_code, @pancard, @added_on, @Risk)";

                                    using (var insertCmd = new SqlCommand(insertQuery, conn))
                                    {
                                        insertCmd.Parameters.AddWithValue("@AccountNo", accountNo);
                                        insertCmd.Parameters.AddWithValue("@Name", name ?? (object)DBNull.Value);
                                        insertCmd.Parameters.AddWithValue("@Mob_no", mobNo ?? (object)DBNull.Value);
                                        insertCmd.Parameters.AddWithValue("@cust_no", custNo ?? (object)DBNull.Value);
                                        insertCmd.Parameters.AddWithValue("@Address", address ?? (object)DBNull.Value);
                                        insertCmd.Parameters.AddWithValue("@Address2", address2 ?? (object)DBNull.Value);
                                        insertCmd.Parameters.AddWithValue("@Address3", address3 ?? (object)DBNull.Value);
                                        insertCmd.Parameters.AddWithValue("@pin_code", pinCode ?? (object)DBNull.Value);
                                        insertCmd.Parameters.AddWithValue("@pancard", pancard ?? (object)DBNull.Value);
                                        insertCmd.Parameters.AddWithValue("@added_on", addedOn ?? (object)DBNull.Value);
                                        insertCmd.Parameters.AddWithValue("@Risk", risk ?? (object)DBNull.Value);
                                        insertCmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }

                        lblerror.Text = "<span style='color:green'>Data inserted and updated successfully.</span>";
                    }
                }
            }
            catch (Exception ex)
            {
                lblerror.Text = "<span style='color:red'>Error: " + ex.Message + "</span>";
            }
        }

        protected void delete_click(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            if (FileUpload1.HasFile)
            {
                string path = Server.MapPath("~/ExcelFile/") + FileUpload1.FileName;
                FileUpload1.SaveAs(path);

                if (!File.Exists(path))
                {
                    lblerror.Text = "<span style='color:red'>File not found.</span>";
                    return;
                }

                try
                {
                    using (var package = new ExcelPackage(new FileInfo(path)))
                    {
                        var worksheet = package.Workbook.Worksheets["Sheet1"];

                        if (worksheet == null)
                        {
                            lblerror.Text = "<span style='color:red'>Worksheet not found.</span>";
                            return;
                        }

                        using (var conn = new SqlConnection(strcon))
                        {
                            conn.Open();

                            for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                            {
                                var accountNo = worksheet.Cells[row, 1].Value?.ToString();
                             

                                var query = "delete TblOmtDetail where AccountNo = '"+ accountNo + "'";
                                using (var cmd = new SqlCommand(query, conn))
                                {
                                    cmd.Parameters.AddWithValue("@AccountNo", accountNo);
                                    cmd.ExecuteNonQuery();
                                    lblerror.Text = "Data deleted successfully.";
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    //lblerror.Text = "<span style='color:red'>" + ex.Message + "</span>";
                }
            }
            else
            {
                lblerror.Text = "<span style='color:red'>Please select a file to upload.</span>";
            }
        }
    }
}