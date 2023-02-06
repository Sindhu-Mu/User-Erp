using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

public partial class Facility_TransportRouteApproval : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions QueryFunction;
    CommonFunctions CommonFunction;
    FacBAL objFacBal;
    FacBLL objFacBll;
    DataTable dt;
    String msg;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnCtn.Attributes.Add("OnClick", "return validateApproval()");
        if (!IsPostBack)
        {
            PushData();
            tblApp.Visible = false;
            FillGrid();
        }

    }
    private void FillGrid()
    {
        objFacBal.CityId = ddlCity.SelectedValue;
        objFacBal.SlotId = ddlSlot.SelectedValue;
        objFacBal.RegstId = txtReg.Text;
        DataTable dt = objFacBll.RouteApprovalSelect(objFacBal).Tables[0];
        ViewState["dt"] = dt;
        GridRouteApproval.DataSource = dt;
        GridRouteApproval.DataBind();
        tblApp.Visible = (dt.Rows.Count > 0);
    }
    void Initialize()
    {
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        CommonFunction = new CommonFunctions();
        objFacBal = new FacBAL();
        objFacBll = new FacBLL();
        dt = new DataTable();
    }
    private void PushData()
    {
        FillFunction.Fill(ddlCity, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.TptCity), true, FillFunctions.FirstItem.Select);        
        FillFunction.Fill(ddlSlot, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.SlotPrd), true, FillFunctions.FirstItem.Select);
        FillFunction.Fill(ddlAction, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.AprValue), true, FillFunctions.FirstItem.Select);
        FillFunction.Fill(ddlRoute, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.RouteName), true, FillFunctions.FirstItem.Select);
        FillFunction.Fill(ddlBus, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.BusNo), false, FillFunctions.FirstItem.Select);
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        FillGrid();
    }
    void clear()
    {
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlCity);
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlSlot);
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlAction);
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlRoute);
        txtRemark.Text = "";
        txtStop.Text = "";
        txtReg.Text ="";
        //GridRouteApproval.DataSource = "";
        //GridRouteApproval.DataBind();
        FillGrid();
    }
    protected void btnCtn_Click(object sender, EventArgs e)
    {
        CheckBox chkApproval; 
        XmlDocument XmlData = new XmlDocument();
        XmlElement Root;
        if (txtData.Text != "")
        {
            XmlData.LoadXml(txtData.Text);
            Root = XmlData.DocumentElement;
        }
        else
        {
            Root = XmlData.CreateElement("RTEAPP");
                XmlData.AppendChild(Root);
        }
        foreach (GridViewRow row in GridRouteApproval.Rows)
        {
            chkApproval = (CheckBox)row.FindControl("chkApproval");
            if (chkApproval.Checked)
            {
                XmlElement dataElement = XmlData.CreateElement("DATA");
                Root.AppendChild(dataElement);
                XmlElement element = XmlData.CreateElement("REG_ROUTE_ID");
                element.InnerText = GridRouteApproval.DataKeys[row.RowIndex].Value.ToString();            
                dataElement.AppendChild(element);
                txtData.Text = XmlData.OuterXml;

            }
        }

        objFacBal.RegRteIdXml = txtData.Text;
        objFacBal.RteId = ddlRoute.SelectedValue;
        objFacBal.SessionUserID = Session["UserID"].ToString();
        objFacBal.Stoppage = txtStop.Text;
        objFacBal.Info = txtRemark.Text;
        objFacBal.BusId = ddlBus.SelectedValue;
        objFacBal.AprId = ddlAction.Text;
        msg = objFacBll.RouteApprovalInsert(objFacBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
        clear();
        txtData.Text = "";
    }
}