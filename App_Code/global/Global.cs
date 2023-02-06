using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;

/// <summary>
/// Summary description for Global
/// </summary>
public class Global
{
    public Global()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void SetCode(Label lblCaptcha)
    {
        Random aa = new Random();
        string a = System.IO.Path.GetRandomFileName();
        string b = a.Substring(0, 6);
        lblCaptcha.Text = b;
        int d = aa.Next(1, 6);
        if (d == 1)
        {
            lblCaptcha.Font.Name = "Jokerman";
            lblCaptcha.ForeColor = System.Drawing.Color.Red;
            lblCaptcha.Font.Size = 25;
        }
        else if (d == 2)
        {
            lblCaptcha.Font.Name = "Segoe Script";
            lblCaptcha.ForeColor = System.Drawing.Color.Blue;
            lblCaptcha.Font.Size = 35;
        }
        else if (d == 3)
        {
            lblCaptcha.Font.Name = "Snap ITC";
            lblCaptcha.ForeColor = System.Drawing.Color.Green;
            lblCaptcha.Font.Size = 26;
        }
        else if (d == 4)
        {
            lblCaptcha.Font.Name = "Ravie";
            lblCaptcha.ForeColor = System.Drawing.Color.Black;
            lblCaptcha.Font.Size = 30;
        }
        else if (d == 5)
        {
            lblCaptcha.Font.Name = "Bradley Hand ITC";
            lblCaptcha.ForeColor = System.Drawing.Color.HotPink;
            lblCaptcha.Font.Size = 30;
        }
        else if (d == 6)
        {
            lblCaptcha.Font.Name = "Brush Script MT";
            lblCaptcha.ForeColor = System.Drawing.Color.RosyBrown;
            lblCaptcha.Font.Size = 30;
        }
    }

    public string GetDateTime(string datetime)
    {
        if (datetime != "")
        {
            CultureInfo culture = new CultureInfo("fr-FR", true);
            DateTime checkDate = Convert.ToDateTime(datetime, culture);
            return checkDate.ToString();
        }
        return datetime;

    }
    public string GetToDate(string datetime)
    {
        CultureInfo culture = new CultureInfo("fr-FR", true);
        DateTime datetimeNew = Convert.ToDateTime(datetime, culture);
        datetimeNew = datetimeNew.AddDays(1D);
        return datetimeNew.ToString("dd/MM/yyyy");
    }
}
