using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KycApplication
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblmsg.Text ="sweety";
        }

        protected void submit_Click(object sender, EventArgs e)
        {
           
            string bank = "ABH" ;
            string name = Name.Text;
            string accountno = account_no.Text;


            //Random generator = new Random();
            //String r = generator.Next(0, 1000000).ToString("D6");

            string id = bank.Substring(0, 3)+ name.Substring(0, 3) + accountno.Substring(accountno.Length - 4);
            lblmsg.Text = id;
            
        }
    }
}