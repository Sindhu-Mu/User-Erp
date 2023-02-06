using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Common_prtFeeChallan : System.Web.UI.Page
{
    DatabaseFunctions databasefuncation;
    SqlCommand cmd;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.Count > 0)
        {
            databasefuncation = new DatabaseFunctions();
            ds = new DataSet();
            string[] st = new string[2];
            st = Request.QueryString[0].ToString().Split(';');
            cmd = new SqlCommand("STU_FEE_CHALAN_SELECT");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@STU_ADM_NO", st[0]);
            cmd.Parameters.AddWithValue("@SEM", st[1]);
            cmd.Parameters.AddWithValue("@PRINT_BY", Session["UserId"].ToString());
            cmd.Parameters.AddWithValue("@BANK_ID", Session["Id"].ToString());
            ds = databasefuncation.GetDataSet(cmd);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblReg1.Text = lblReg2.Text = lblReg3.Text = ds.Tables[0].Rows[0]["ADM_REG_NO"].ToString();
                lblChNo2.Text = lblChNo3.Text = lblCno.Text = ds.Tables[0].Rows[0]["ID"].ToString();
                lblEnrollment1.Text = lblEnrollment2.Text = lblEnrollment3.Text = ds.Tables[0].Rows[0]["ENROLLMENT"].ToString();
                lblCourse.Text = lblCourse2.Text = lblCourse3.Text = ds.Tables[0].Rows[0]["COURSE"].ToString();
                lblFather1.Text = lblFather2.Text = lblFather3.Text = ds.Tables[0].Rows[0]["FATHERS_NAME"].ToString();
                lblStuName1.Text = lblStuName2.Text = lblStuName3.Text = ds.Tables[0].Rows[0]["STU_NAME"].ToString();
                lblINs.Text = lblIns2.Text = lblIns3.Text = ds.Tables[0].Rows[0]["INS_DESC"].ToString();
                lblSem.Text = lblSem2.Text = lblSem3.Text = ds.Tables[0].Rows[0]["SEM"].ToString().ToString();
                if (ds.Tables[1].Rows.Count > 0)
                {
                    BindGrid(gvFee1, ds.Tables[1]);
                    BindGrid(gvFee2, ds.Tables[1]);
                    BindGrid(gvFee3, ds.Tables[1]);
                }
               if (ds.Tables[2].Rows.Count > 0)              
                {
                    BindGrid1(gvFee1, ds.Tables[2]);
                    BindGrid1(gvFee2, ds.Tables[2]);
                    BindGrid1(gvFee3, ds.Tables[2]);
                }
               if (ds.Tables[3].Rows.Count > 0)
               {
                   lblBank1.Text = lblBank2.Text = lblBank3.Text = ds.Tables[3].Rows[0]["BANK_VALUE"].ToString();
                   lblBranch1.Text = lblBranch2.Text = lblBranch3.Text = ds.Tables[3].Rows[0]["BANK_AC_BRANCH"].ToString();
                   lblAccountName1.Text = lblAccountName2.Text = lblAccountName3.Text = ds.Tables[3].Rows[0]["BANK_AC_REMARK"].ToString();
                   lblAccountNo1.Text = lblAccountNo2.Text = lblAccountNo3.Text = ds.Tables[3].Rows[0]["BANK_AC_NO"].ToString();
              
               
               
               }

            }
        }

    }
    void BindGrid(GridView gv, DataTable dt)
    {
        double Total = 0;
        gv.DataSource = dt;
        gv.DataBind();

        foreach (GridViewRow itm in gv.Rows)
        {
            Total = Total + Convert.ToDouble(itm.Cells[1].Text);
        }
        gv.FooterRow.Cells[1].Text = Total.ToString("N2");
    }
    void BindGrid1(GridView gv, DataTable dt)
    {
        gv.DataSource = dt;
        gv.DataBind();
    }
}