using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;
public partial class prtDemandLetter : System.Web.UI.Page
{
    DatabaseFunctions Objgenfun = new DatabaseFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {

        GridView gvOpening;
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        Label lblTotalAmt;
        string xmlData = (string)Session["ds"];
        StringReader reader = new StringReader(xmlData);
        ds.ReadXml(reader);
        reader.Close();
        dt = ds.Tables[0];
        double Total = 0;
        Repeater1.DataSource = dt;
        Repeater1.DataBind();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ds.Tables.Clear();
            gvOpening = (GridView)Repeater1.Items[i].FindControl("gvOpening");
            SqlCommand com = new SqlCommand("GET_DEMAND_AMOUNT");
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@STU_ADM_NO", dt.Rows[i]["ENROLLMENT_NO"].ToString());
            com.Parameters.AddWithValue("@SEM", dt.Rows[i]["SEM"].ToString());
            com.Parameters.AddWithValue("@PRNT_STS", dt.Rows[i][0].ToString());
            com.Parameters.AddWithValue("@PRNT_BY", Session["UserId"].ToString());
            ds = Objgenfun.GetDataSet(com);
            gvOpening.DataSource = ds.Tables[0];
            gvOpening.DataBind();
            Total = 0;
            foreach (GridViewRow itm in gvOpening.Rows)
            {
                Total += Convert.ToDouble(ds.Tables[0].Rows[itm.RowIndex][2]);

            }
            if (gvOpening.Rows.Count > 0)
            {
                gvOpening.FooterRow.Cells[2].Text = Total.ToString("N2");
                lblTotalAmt = (Label)Repeater1.Items[i].FindControl("lblTotalAmt");
                lblTotalAmt.Text = Objgenfun.ConvertNumberToWord(Total);
            }

        }
    }

}
