using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net;
using System.IO;

public partial class Academic_SMS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSMS_Click(object sender, EventArgs e)
    {
        string Msg = txtSMS.Text;
       
        sendMsg(Msg);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('SMS has been sent to the number provided by you.')", true);
    }

    private void sendMsg(string msg)
    {//
        string url = "http://BULK.SMS-INDIA.IN/unified.php?usr=27303&pwd=7351002587&ph= " + txtPhn.Text + " &sndr=MUUNIV&text=" + msg + "";


        // string url = "http://smsidea.co.in/sendsms.aspx?mobile=7500011199 &pass=sms2014&senderid=muuniv&to=7351002587,9845192861,9359888888,9927026648,8954999399,7351002502&msg=" + msg + "";
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Stream resStream = response.GetResponseStream();
    }
}