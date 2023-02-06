using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Facility_rptIssueDetail : System.Web.UI.Page
{
    FacBAL ObjFacBal;
    FacBLL ObjFacBll;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            ObjFacBal.Id = Request.QueryString[0].ToString();
            ds = ObjFacBll.IssueDetailSelect(ObjFacBal);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblHead.Text = "Token No :#" + ds.Tables[0].Rows[0]["ISSUE_TOKEN_NO"].ToString();
                lblEmpName.Text = ds.Tables[0].Rows[0]["EMP_NAME"].ToString();
                lblDeptName.Text = ds.Tables[0].Rows[0]["DEPT_VALUE"].ToString();
                lblLocation.Text = ds.Tables[0].Rows[0]["ISSUE_LOCATION"].ToString();
                lblBuilding.Text = ds.Tables[0].Rows[0]["FAC_CMPLX_NAME"].ToString();
                lblComplainAbout.Text = ds.Tables[0].Rows[0]["SUB_HEAD_VALUE"].ToString();
                lblComplainDt.Text = ds.Tables[0].Rows[0]["ISSUE_DT"].ToString();
                lblCompDetail.Text = ds.Tables[0].Rows[0]["ISSUE_DETAIL"].ToString();
                lblPhn.Text = ds.Tables[0].Rows[0]["Mobile_Off"].ToString();
                gvDetail.DataSource = ds.Tables[2];
                gvDetail.DataBind();
                gvAssign.DataSource = ds.Tables[1];
                gvAssign.DataBind();
            }
        }
    }
    void Initialize()
    {
        ObjFacBal = new FacBAL();
        ObjFacBll = new FacBLL();
        ds = new DataSet();
    }
}