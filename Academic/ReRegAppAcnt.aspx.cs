using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Drawing;


public partial class Academic_ReRegAppAcnt : System.Web.UI.Page
{
    FillFunctions fillFunction;
    QueryFunctions QueryFuntion;
    DatabaseFunctions DataBasefunction;
    CommonFunctions CommonFunction;
    AcaBAL ObjAcaBal;
    AcaBLL ObjAcaBll;
    DataTable Dt;
    string Msg;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            trApp.Visible = false;
            //trMsg.Visible = false;
            td1.Visible = false;
            fillFunction.Fill(ddlRegFor, QueryFuntion.GetCommand(QueryFunctions.QueryBaseType.Reg_Sem), true, FillFunctions.FirstItem.All);
            fillFunction.Fill(ddlIns, QueryFuntion.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.All);
            fillFunction.Fill(ddlSem, QueryFuntion.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.All);
            fillFunction.Fill(ddlPgm, QueryFuntion.GetCommand(QueryFunctions.QueryBaseType.Program), true, FillFunctions.FirstItem.All);
            ddlRegFor.SelectedIndex = 1;
            
        }
    }
    void Initialize()
    {
        fillFunction = new FillFunctions();
        CommonFunction = new CommonFunctions();
        DataBasefunction = new DatabaseFunctions();
        QueryFuntion = new QueryFunctions();
        ObjAcaBal = new AcaBAL();
        ObjAcaBll = new AcaBLL();
        Dt = new DataTable();
    }
    protected void ddlIns_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillFunction.Fill(ddlPgm, QueryFuntion.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlIns.SelectedValue), true, FillFunctions.FirstItem.Select);
    }
    protected void ddlPgm_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillFunction.Fill(ddlBrn, QueryFuntion.GetCommand(QueryFunctions.QueryBaseType.Branch, ddlPgm.SelectedValue), true, FillFunctions.FirstItem.All);
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        if (txtEnroll.Text.Contains(":"))
        {
            ObjAcaBal.Stu_AdmNo = CommonFunction.GetKeyID(txtEnroll);
            ObjAcaBal.Id = ObjAcaBll.GetStudentMainId(ObjAcaBal);
        }
        else
        {
            ObjAcaBal.Id = null;
        }
        detail();
      //  foreach (GridViewRow row in gvApp.Rows)
      //  {
      //      if (ObjAcaBll.ReRegAcntApp(ObjAcaBal).Tables[0].Rows[].!="Submitted")
      //          row.BackColor = System.Drawing.Color.Red;
      //}
    }

    void detail()
    {
       
        ObjAcaBal.KeyValue = ddlRegFor.SelectedValue;
        ObjAcaBal.InsId = ddlIns.SelectedValue;
        ObjAcaBal.Pgm_Id = ddlPgm.SelectedValue;
        ObjAcaBal.Brn_Id = ddlBrn.SelectedValue;
        ObjAcaBal.Semid = ddlSem.SelectedValue;
        ObjAcaBal.ChangeStatus = ddlSts.SelectedValue;
        ObjAcaBal.SessionUserID = Session["UserId"].ToString();
        DataSet ds = ObjAcaBll.ReRegAcntApp(ObjAcaBal);
        gvApp.DataSource = ds.Tables[0];
        gvApp.DataBind();
        trApp.Visible = ds.Tables[0].Rows.Count > 0;
    }
    protected void btnApprove_Click(object sender, EventArgs e)
    {
        StringBuilder data = new StringBuilder();
        CheckBox chk;
        data.AppendFormat("<REGISTRATION>");

        foreach (GridViewRow itm in gvApp.Rows)
        {
           
             chk = (CheckBox)itm.FindControl("ChkBox");
            if (chk.Checked)
            {
                data.AppendFormat("<STS SEM_REG_DTL_ID=\"" + gvApp.DataKeys[itm.RowIndex].Values[1].ToString() + "\"/>");
            }
        }
        data.AppendFormat("</REGISTRATION>");
        ObjAcaBal.XmlValue = data.ToString();
        ObjAcaBal.SessionUserID = Session["UserId"].ToString();
        ObjAcaBal.Value = txtRemark.Text;
        Msg = ObjAcaBll.UpdateReReg(ObjAcaBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
       // gvApp.SelectedRowStyle.BackColor = System.Drawing.Color.White;
        gvApp.DataSource = "";
        gvApp.DataBind();
        txtRemark.Text = "";
        gvAcnt.DataSource = "";
        gvAcnt.DataBind();
        td1.Visible = false;
        detail();
    }
    protected void gvApp_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       
        td1.Visible = true;
        //if (e.CommandName == "imgsend1")
        //{
        //    ViewState["Id"] = gvApp.DataKeys[Convert.ToInt32(e.CommandArgument)].Values[1].ToString();
        //   trMsg.Visible = true;
            //trApp.Visible = false;
        //foreach (GridViewRow itm in gvAcnt.Rows)
        //{
        //    if (!(gvAcnt.Rows[itm.RowIndex].BackColor == Color.FromArgb(206, 206, 255)))
        //        gvAcnt.Rows[itm.RowIndex].BackColor = Color.Empty;
        //}
        //gvApp.Rows[Convert.ToInt32(e.CommandArgument)].BackColor = Color.LightGreen;
        ObjAcaBal.Enroll_No = gvApp.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["ENROLLMENT_NO"].ToString();
            ObjAcaBal.Brn_Id = gvApp.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["PGM_BRN_ID"].ToString();
            ObjAcaBal.Semid = gvApp.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["ACA_SEM_ID"].ToString();

            DataSet ds = ObjAcaBll.FeeDemRcvSelect(ObjAcaBal);
            gvAcnt.DataSource = ds.Tables[1];
            gvAcnt.DataBind();
            lblCredit.Text = ds.Tables[2].Rows[0]["MONEY_CR_BAL_AMT"].ToString();


           double TotalFee = 0;
           double TotalRcv = 0;
           double TotalBal = 0;
           double TotalAdj = 0;
           double TotalWave = 0;

           foreach (GridViewRow row in gvAcnt.Rows)
           {
               TotalFee += Convert.ToDouble(row.Cells[2].Text);
               TotalRcv += Convert.ToDouble(row.Cells[3].Text);
               TotalAdj += Convert.ToDouble(row.Cells[5].Text);
               TotalWave += Convert.ToDouble(row.Cells[4].Text);
               TotalBal += Convert.ToDouble(row.Cells[6].Text);
           }
           if (gvAcnt.Rows.Count > 0)
           {
               gvAcnt.FooterRow.Cells[2].Text = TotalFee.ToString("N2");
               gvAcnt.FooterRow.Cells[3].Text=TotalRcv.ToString("N2");
               gvAcnt.FooterRow.Cells[6].Text = TotalBal.ToString("N2");
               gvAcnt.FooterRow.Cells[4].Text = TotalWave.ToString("N2");
               gvAcnt.FooterRow.Cells[5].Text = TotalAdj.ToString("N2");
               
           }
        //}
    }
    //protected void btnSend_Click(object sender, EventArgs e)
    //{
    //    ObjAcaBal.KeyID = ViewState["Id"].ToString();
    //    ObjAcaBal.Value = txtMsg.Text;
    //    ObjAcaBal.SessionUserID = Session["UserId"].ToString();
    //    Msg = ObjAcaBll.SendMessage(ObjAcaBal);
    //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
    //    trMsg.Visible = false;
    //    gvApp.DataSource = ObjAcaBll.ReRegAcntApp(ObjAcaBal).Tables[0];
    //    gvApp.DataBind();
    //}
}