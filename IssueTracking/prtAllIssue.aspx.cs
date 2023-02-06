using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class IssueTracking_prtAllIssue : System.Web.UI.Page
{
    FacBAL ObjFacBal;
    FacBLL ObjFacBll;
    DataSet ds;
    DataTable dt;
    GridView gvDetail;
    GridView gvAssign;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            ObjFacBal.Id = "2018";
            ds = ObjFacBll.IssueDetailSelectII(ObjFacBal);
            Repeater1.DataSource=ds;
            Repeater1.DataBind();
            dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ObjFacBal.Id = dt.Rows[i]["ISSUE_ID"].ToString();
                ds = ObjFacBll.IssueDetailSelectIII(ObjFacBal);
                gvDetail = (GridView)Repeater1.Items[i].FindControl("gvDetail");
                gvAssign = (GridView)Repeater1.Items[i].FindControl("gvAssign");
                gvDetail.DataSource = ds.Tables[1];
                gvDetail.DataBind();
                gvAssign.DataSource = ds.Tables[0];
                gvAssign.DataBind();
            }
        }
       
    }
    void Initialize()
    {
        ObjFacBal = new FacBAL();
        ObjFacBll = new FacBLL();
        ds = new DataSet();
        dt = new DataTable();
    }
}