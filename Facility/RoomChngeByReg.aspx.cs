
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


public partial class Facility_HostelRoomAllotment : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions QueryFunction;
    CommonFunctions CommonFunction;
    DatabaseFunctions DatabaseFunction;
    FacBAL ObjFacBal;
    FacBLL ObjFacBll;
    string Msg;
    DataSet ds;
    

    protected void Page_Load(object sender, EventArgs e)
    {
        Initailize();
        btnChange.Attributes.Add("OnClick", "return ChangeValidate()");
        if (!IsPostBack)
        {
       
            FillFunction.Fill(ddlCFloor, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.HstlFloor, Session["HostelId"].ToString()), false, FillFunctions.FirstItem.Select);
            FillFunction.Fill(ddlNewRoom, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.HstlRoom, Session["HostelId"].ToString()), true, FillFunctions.FirstItem.Select);
            ViewState["ID"] = "";
            ViewState["dt"] = "";
        }
    }
    void Initailize()
    {
        FillFunction=new FillFunctions();
        QueryFunction=new QueryFunctions();
        CommonFunction=new CommonFunctions();
        DatabaseFunction = new DatabaseFunctions();
        ObjFacBal = new FacBAL();
        ObjFacBll = new FacBLL();
        ds=new DataSet();
    }
    protected void ddlCFloor_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCFloor.SelectedIndex > 0)
            FillFunction.Fill(ddlCRoomNo, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.RoomNO, Session["HostelId"].ToString(), ddlCFloor.SelectedValue), true, FillFunctions.FirstItem.Select);
        else
            CommonFunction.Clear(ddlCRoomNo);
    }
    void FillgvRoomCng()
    {
        ObjFacBal.RoomId = ddlCRoomNo.SelectedValue;
        ds = ObjFacBll.HstlRumAlmtSelect(ObjFacBal);
        FillFunction.Fill(ddlCstudent, ds.Tables[0], true, FillFunctions.FirstItem.Select);
        ViewState["dt"] = ds.Tables[0];
        gvRoomCng.DataSource = ds.Tables[0];
        gvRoomCng.DataBind();
        lblBed.Text = ds.Tables[1].Rows[0][0].ToString();
    }
    protected void ddlCRoomNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillgvRoomCng();
    }
    protected void btnChange_Click(object sender, EventArgs e)
    {
        ObjFacBal.Id = ddlCFloor.SelectedValue;
        ObjFacBal.RoomId = ddlNewRoom.SelectedValue;
        ObjFacBal.StuAdmNo = ddlCstudent.SelectedValue;
        ObjFacBal.OccDt = CommonFunction.GetDateTime(txtChangeDate.Text);
        ObjFacBal.Remark = txtChRemark.Text;
        ObjFacBal.SessionUserID = Session["UserId"].ToString();
        ObjFacBal.OccId = "2";
        Msg = ObjFacBll.HstlRoomChngeInsertByReg(ObjFacBal);
        FillgvRoomCng();
        CommonFunction.Clear(this);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
   
    }

}