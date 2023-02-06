using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Configuration;
using System.Drawing;
using System.Net;
using System.IO;

public partial class Facility_VehicleRequestTransport : System.Web.UI.Page
{
    FillFunctions FillFunction;
    CommonFunctions CommonFunction;
    QueryFunctions QueryFunction;
    FacBAL ObjFacBal;
    FacBLL ObjFacBll;
    DatabaseFunctions DataBaseFunction;
    DataTable dt;
    string Msg, smsMsg;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        this.MaintainScrollPositionOnPostBack = true;
        if (!IsPostBack)
        {
            ViewState["ID"] = "";
            ViewState["dt"] = dt;
            ViewState["req"] = dt;
            FillgvVehReqDetail();
        }
    }
    void Initialize()
    {
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        CommonFunction = new CommonFunctions();
        DataBaseFunction = new DatabaseFunctions();
        ObjFacBal = new FacBAL();
        ObjFacBll = new FacBLL();
        dt = new DataTable();
    }
    void FillgvVehReqDetail()
    {
        ObjFacBal.SessionUserID = Session["UserId"].ToString();
        dt = ObjFacBll.VehReqApproved(ObjFacBal).Tables[0];
        ViewState["req"] = dt;
        gvVehReqDetail.DataSource = dt;
        gvVehReqDetail.DataBind();
        if (dt.Rows.Count > 0)
        {
            FillgvVehicle();
            FillGvDriver();
        }
    }
    void FillgvRetJourney()
    {
        ObjFacBal.Id = ViewState["ID"].ToString();
        ObjFacBal.SessionUserID = Session["UserId"].ToString();
        DataSet ds = ObjFacBll.VehRetApproved(ObjFacBal);
        ViewState["dt"] = ds.Tables[0];
        gvRetJourney.DataSource = ds;
        gvRetJourney.DataBind();
    }
    void FillgvVehicle()
    {
        dt = ObjFacBll.VehicleMainSelect().Tables[0];
        gvVehicle.DataSource = dt;
        gvVehicle.DataBind();
    }
    void FillGvDriver()
    {
        dt = ObjFacBll.DriverMainSelect().Tables[0];
        gvDriver.DataSource = dt;
        gvDriver.DataBind();
    }
    protected void gvVehReqDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        foreach (GridViewRow row in gvVehReqDetail.Rows)
        {
            if (row.RowIndex != Convert.ToInt32(e.CommandArgument))
            {
                gvVehReqDetail.Rows[row.RowIndex].BackColor = System.Drawing.Color.White;
            }
        }

        gvVehReqDetail.Rows[Convert.ToInt32(e.CommandArgument)].BackColor = System.Drawing.Color.YellowGreen;

        ViewState["ID"] = gvVehReqDetail.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
        dt = (DataTable)ViewState["req"];
        DataRow[] dr = dt.Select("VR_REQ_ID=" + ViewState["ID"].ToString() + "");
        if (dr[0]["VRD_JRNY_TYPE"].ToString() != "ONE-WAY")
        {
            trReturn.Visible = true;
            FillgvRetJourney();
        }
        else
        {
            trReturn.Visible = false;
        }
        gvVehicle.Focus();
        //gvVehReqDetail.Rows[Convert.ToInt32(e.CommandArgument)].Focus();

    }
    protected void btnAssign_Click(object sender, EventArgs e)
    {
        string DriverNo = "";
        ObjFacBal.Id = ViewState["ID"].ToString();
        ObjFacBal.SessionUserID = Session["UserId"].ToString();
        ObjFacBal.Remark = txtRemark.Text;
        CheckBox Chk, ChkBox;
        foreach (GridViewRow itm in gvVehicle.Rows)
        {
            ChkBox = (CheckBox)itm.FindControl("chkVehAssign");
            if (ChkBox.Checked)
            {
                ObjFacBal.VehCat = gvVehicle.DataKeys[itm.RowIndex].Value.ToString();
            }
        }
        foreach (GridViewRow itm1 in gvDriver.Rows)
        {
            Chk = (CheckBox)itm1.FindControl("chkDriverAssign");
            if (Chk.Checked)
            {

                ObjFacBal.EmpId = gvDriver.DataKeys[itm1.RowIndex].Value.ToString();
                DriverNo = itm1.Cells[2].Text;
            }
        }
        Msg = ObjFacBll.VehDriverAssigned(ObjFacBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('"+ Msg +"')", true);

        dt = (DataTable)ViewState["req"];
        DataRow[] dr = dt.Select("VR_REQ_ID=" + ViewState["ID"].ToString() + "");
        smsMsg = " Persone Name:" + dr[0]["EMP_NAME"].ToString();
        smsMsg = " M.No.:" + dr[0]["VR_CONTACT_NO"].ToString();
        smsMsg += " Date:" + dr[0]["VRD_JRNY_DT"].ToString();
        smsMsg += " From:" + dr[0]["VR_PICK_UP_LOC"].ToString();
        smsMsg += " To:" + dr[0]["VR_DESTI_ADD"].ToString();
        smsMsg += " Time:" + dr[0]["VRD_JRNY_TIME"].ToString();
        smsMsg += " NOP:" + dr[0]["VR_NOP"].ToString();
        sendMsg(smsMsg, DriverNo);
        FillgvVehReqDetail();
    }
    private void sendMsg(string msg, string no)
    {
        string url = "http://smsidea.co.in/sendsms.aspx?mobile=7500011199 &pass=sms2014&senderid=muuniv&to=" + no + "&msg=" + msg + "";
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Stream resStream = response.GetResponseStream();
    }
}