using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;


public partial class Academic_prtFeeDemand : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DatabaseFunctions ObjGenFun;
        DataSet ds;
        SqlCommand com;
        if (Request.QueryString.Count > 0)
        {
            ObjGenFun = new DatabaseFunctions();
            ds = new DataSet();
            string[] st = new string[2];
            st = Request.QueryString[0].ToString().Split(';');
            com = new SqlCommand("STU_FEE_CHALAN_SELECT");
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@STU_ADM_NO", st[0]);
            com.Parameters.AddWithValue("@SEM", st[1]);
            com.Parameters.AddWithValue("@PRINT_BY", Session["UserId"].ToString());
            ds = ObjGenFun.GetDataSet(com);
            DataTable dt = ds.Tables[0];
            lblRef.Text = dt.Rows[0]["REF"].ToString();
            lblEnroll.Text = dt.Rows[0]["ENROLLMENT"].ToString();
            lblName.Text = dt.Rows[0]["STU_NAME"].ToString();
            lblNo.Text = dt.Rows[0]["PHN_NO"].ToString();
            lblAdd.Text = dt.Rows[0]["PADD"].ToString();
            lblCourse.Text = dt.Rows[0]["COURSE"].ToString();
            lblParent.Text = dt.Rows[0]["FATHERS_NAME"].ToString();
            lblParent1.Text = dt.Rows[0]["FATHERS_NAME"].ToString();
            lblSec.Text = dt.Rows[0]["SEC"].ToString();
            lblSem.Text=dt.Rows[0]["SEM"].ToString();
            lblDate.Text = dt.Rows[0]["Date"].ToString();
            lblcity.Text = dt.Rows[0]["City"].ToString();
            lblState.Text = dt.Rows[0]["State"].ToString();

            double Total = 0;
            //Repeater1.DataSource = dt;
            //Repeater1.DataBind();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
               // ds.Tables.Clear();
               
                SqlCommand command = new SqlCommand("GET_DEMAND_AMOUNT");
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@STU_ADM_NO", dt.Rows[i]["ENROLLMENT"].ToString());
                command.Parameters.AddWithValue("@SEM", dt.Rows[i]["SEM"].ToString());
                command.Parameters.AddWithValue("@PRNT_STS", dt.Rows[i][0].ToString());
                command.Parameters.AddWithValue("@PRNT_BY", Session["UserId"].ToString());
                ds = ObjGenFun.GetDataSet(command);
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
                    lblTotalAmt.Text = ObjGenFun.ConvertNumberToWord(Total);
                }
            }
        }
    }
}