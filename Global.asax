<%@ Application Language="C#" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Net" %>

<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup                 
    }
    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown
        Session.Clear();
    }

    void Application_Error(object sender, EventArgs e)
    { 
       Exception err = (Exception)Server.GetLastError().InnerException;
        //Create a text file containing error details    
       string strFileName = "User" + Session["LoginId"].ToString() + "_Err_dt" + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day
        + "_" + DateTime.Now.Year + "_Time_" + DateTime.Now.Hour + "_" +
        DateTime.Now.Minute + "_" + DateTime.Now.Second + "_"
        + DateTime.Now.Millisecond + ".txt";
        strFileName = Server.MapPath("~") + "\\MyError\\" + strFileName;
        FileStream fsOut = File.Create(strFileName);
        StreamWriter sw = new StreamWriter(fsOut);
        //Log the error details
        string errorText = "Error Message: " + err.Message + sw.NewLine;
        errorText = errorText + "Stack Trace: " + err.StackTrace + sw.NewLine;
        sw.WriteLine(errorText);
        sw.Flush();
        sw.Close();
        fsOut.Close();
       /*
                //Send an Email to Web Master
                //Create Mail Message Object with content that you want to send with mail.
                MailMessage MyMailMessage = new MailMessage("zareef.ahmad@gmail.com", "zareef2u@yahoo.com",
                "Exception:" + err.Message, errorText);

                MyMailMessage.IsBodyHtml = false;

                //Proper Authentication Details need to be passed when sending email from gmail
                NetworkCredential mailAuthentication = new
                NetworkCredential("dotnetguts@gmail.com", "password");

                //Smtp Mail server of Gmail is "smpt.gmail.com" and it uses port no. 587
                //For different server like yahoo this details changes and you can
                //get it from respective server.
                SmtpClient mailClient = new SmtpClient("smtp.gmail.com", 587);

                //Enable SSL
                mailClient.EnableSsl = true;
                mailClient.UseDefaultCredentials = false;
                mailClient.Credentials = mailAuthentication;
                mailClient.Send(MyMailMessage);
         * */

    }

    void Session_Start(object sender, EventArgs e)
    {

        Session.Timeout = 360;
        //User
        Session["UserId"] = "";
        Session["LoginId"] = "";
        Session["UserName"] = "";
        Session["UserType"] = "";
        //Store
        Session["Id"] = "";
        Session["StoreId"] = "";
        Session["HostelId"] = "";
        Session["Date"] = "";
        //Page Check
        Session["PageId"] = "";
        Session["PageName"] = "";
        Session["path"] = "";
        //Other
        Session["ds"] = "";
        Session["MENU"] = "";
        Session["InsID"] = "";
        Session["QUICKLINK"] = "";
    }

    void Session_End(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("../Common/Default.aspx");
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.            
    }
       
</script>
