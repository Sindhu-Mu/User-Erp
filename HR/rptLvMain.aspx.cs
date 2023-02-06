using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
public partial class HR_rptLvMain : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    QueryFunctions queryFunctions;
    HRBAL ObjAcaBAL;
    HRBLL ObjHrBll;
    DataSet ds;
    DataTable dt;
    DatabaseFunctions databaseFunctions;
    void Initialize()
    {
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        queryFunctions = new QueryFunctions();
        ObjAcaBAL = new HRBAL();
        ObjHrBll = new HRBLL();
        dt = new DataTable();
        databaseFunctions = new DatabaseFunctions();
        ds = new DataSet();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            for (int yy = DateTime.Today.Year; yy > DateTime.Today.Year - 4; yy--)
                ddlYear.Items.Add(yy.ToString());
            fillFunctions.Fill(ddlIns, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.All);
            fillFunctions.Fill(ddlDept, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Dept_Name), true, FillFunctions.FirstItem.All);
            fillFunctions.Fill(ddlLvType, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.LeaveType), true, FillFunctions.FirstItem.All);
            //fillFunctions.Fill(ddlStatus, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Status), true, FillFunctions.FirstItem.All);
        }
    }
    protected void ddlIns_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIns.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlDept, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Department, ddlIns.SelectedValue), true, FillFunctions.FirstItem.All);
        }
    }

    protected void ddlViewType_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (ListItem item in chkLv.Items)
        {
            if (item.Selected)
            {
                item.Selected = false;
            }
        }
        if (ddlViewType.SelectedValue == "2")
        {
            trLv.Visible = trLeave.Visible = true;
            trSL.Visible = trShort.Visible = true;
            trPen.Visible = trpending.Visible = true;
        }
        else
        {
            trLv.Visible = trLeave.Visible = false;
            trSL.Visible = trShort.Visible = false;
            trPen.Visible = trpending.Visible = false;
        }
    }
    protected void btnExecute_Click(object sender, EventArgs e)
    {
        StringBuilder query = new StringBuilder("");
        StringBuilder strGroup = new StringBuilder("");
        StringBuilder strPending = new StringBuilder(" INS_DEPT_INF RIGHT OUTER JOIN USR_ROLE_TRAN ON INS_DEPT_INF.DEPT_ID = USR_ROLE_TRAN.INS_DEPT_ID AND USR_ROLE_TRAN.REF_TYPE = 0 "+
                      " LEFT OUTER JOIN UNIV_INS_INF ON USR_ROLE_TRAN.INS_DEPT_ID = UNIV_INS_INF.INS_ID AND USR_ROLE_TRAN.REF_TYPE = 1 RIGHT OUTER JOIN ");
        query.Append("SELECT DISTINCT EV.EMP_ID, EV.EMP_NAME ");
        foreach (ListItem item in chkBox.Items)
        {
            if (item.Selected)
            {
                query.Append(", '" + item.Text + "' =" + item.Value);
                strGroup.Append(" , " + item.Value);
            }
        }
        int sl = 0;
        foreach (ListItem item in chkSL.Items)
        {
            if (item.Selected)
            {
                query.Append(", '" + item.Text + "' =" + item.Value);
                strGroup.Append(" , " + item.Value);

                sl = 1;
            }

        }
        if ((ddlViewType.SelectedValue == "1") || (ddlViewType.SelectedValue == "0"))
        {
            if (ddlViewType.SelectedValue == "1")
            {
                query.Append(" ,LV.LV_VALUE AS LeaveType");
            }
            query.Append(", COUNT(*) AS COUNT, SUM(LV.TOT_DAYS) AS NET");

        }

        foreach (ListItem item in chkLv.Items)
        {
            if (item.Selected)
            {
                query.Append(", '" + item.Text + "' =" + item.Value);
                strGroup.Append(" , " + item.Value);

            }

        }
        int pen = 0;
        foreach (ListItem item in chkPen.Items)
        {
            if (item.Selected)
            {
                query.Append(", '" + item.Text + "' =" + item.Value);
                strGroup.Append(" , " + item.Value);
                pen = 1;
            }

        }

        query.Append(" FROM ");

        if ((pen == 1) || (txtPendingWith.Text != ""))
        {
            query.Append(strPending);
        }
        query.Append(" EMP_VIEW AS EV INNER JOIN " +
                     " EMP_LV_VIEW AS LV ON EV.USR_ID = LV.USR_ID  ");
        if (sl == 1)
        {
            query.Append(" INNER JOIN PROC_TRAN ON PROC_TRAN.KEY_ID = LV.LV_APP_ID INNER JOIN " +
                     " EMP_VIEW ON PROC_TRAN.IN_BY = EMP_VIEW.USR_ID INNER JOIN " +
                     " PROC_STS_TYPE_INF ON PROC_TRAN.STS_TYPE_ID = PROC_STS_TYPE_INF.STS_ID  ");
        }

        if ((pen == 1) || (txtPendingWith.Text != ""))
        {
            query.Append("INNER JOIN ACTION_REQUEST_INF AS ACT ON ACT.KEY_ID = LV.LV_APP_ID INNER JOIN " +
                      "ROLE_INF ON LV.PENDING_WITH = ROLE_INF.ROLE_VALUE INNER JOIN " +
                      "USR_ROLE_INF ON ROLE_INF.ROLE_ID = USR_ROLE_INF.ROLE_ID INNER JOIN " +
                      "EMP_VIEW ON USR_ROLE_INF.USR_ID = EMP_VIEW.USR_ID ON USR_ROLE_TRAN.USR_ROLE_ID = USR_ROLE_INF.USR_ROLE_ID");
        }


        query.Append(" WHERE EV.EMP_ID>0");
        if (ddlIns.SelectedIndex > 0)
        {
            query.Append(" AND EV.INS_ID=" + ddlIns.SelectedValue + "");
        }

        if (ddlDept.SelectedIndex > 0)
        {
            query.Append(" AND EV.DEPT_ID=" + ddlDept.SelectedValue + "");
        }

        if (ddlStatus.SelectedIndex > 0)
        {
            query.Append(" AND (LV.STS_ID =" + ddlStatus.SelectedValue + ") ");
        }

        if (ddlLvType.SelectedIndex > 0)
        {
            query.Append(" AND LV.LV_ID=" + ddlLvType.SelectedValue + "");
        }

        if (txtEmployee.Text != "")
        {
            query.Append(" AND EV.EMP_ID=" + commonFunctions.GetKeyID(txtEmployee) + "");
        }

        if (sl == 1)
        {
            query.Append(" AND (LV.LV_ID=11) AND (PROC_TRAN.PROC_TYPE_ID IN (1)) ");
        }

        if ((pen == 1) || (txtPendingWith.Text != ""))
        {
            query.Append(" AND (LV.STS_ID IN (-2,-1,1)) AND (ACT.STS = 1) AND (((USR_ROLE_TRAN.INS_DEPT_ID=EV.DEPT_ID) AND (USR_ROLE_TRAN.REF_TYPE=1) AND (USR_ROLE_TRAN.TO_DT IS NULL)) OR((USR_ROLE_TRAN.INS_DEPT_ID=EV.INS_ID) AND (USR_ROLE_TRAN.REF_TYPE=0) AND (USR_ROLE_TRAN.TO_DT IS NULL)) OR ((USR_ROLE_TRAN.REF_TYPE IS NULL) AND (EMP_VIEW.EMP_NAME=EV.NEXT_SENIOR)) OR ((USR_ROLE_TRAN.REF_TYPE IS NULL) AND (USR_ROLE_INF.ROLE_ID NOT IN (1,2,3)) AND (USR_ROLE_INF.TO_DT IS NULL)) ) ");
        }

        if (txtPendingWith.Text != "")
        {
            ObjAcaBAL.EmpId = commonFunctions.GetKeyID(txtPendingWith);
            query.Append(" AND (USR_ROLE_INF.USR_ID=" + ObjHrBll.GetUserId(ObjAcaBAL) + ")");
        }

        if (ddlDateType.SelectedValue == "D")
        {
            query.Append(" AND ((CONVERT(VARCHAR,LV.FROM_DT,103) =  ')" + txtDate.Text + "' OR (CONVERT(VARCHAR,LV.TO_DT,103) = '" + txtDate.Text + "') )");

        }
        else if (ddlDateType.SelectedValue == "M")
        {
            DropDownList ddlMM = (DropDownList)MonthYear2.FindControl("ddlMonth");
            DropDownList ddlYY = (DropDownList)MonthYear2.FindControl("ddlYear");
            query.Append(" AND ((MONTH(LV.FROM_DT)='" + ddlMM.SelectedValue + "' AND YEAR(LV.FROM_DT)='" + ddlYY.SelectedValue + "') OR  (MONTH(LV.TO_DT)='" + ddlMM.SelectedValue + "' AND YEAR(LV.TO_DT)='" + ddlYY.SelectedValue + "'))");
        }
        else if (ddlDateType.SelectedValue == "Y")
        {
            query.Append(" AND ((YEAR(LV.FROM_DT)='" + ddlYear.SelectedValue + "') OR  (YEAR(LV.TO_DT)='" + ddlYear.SelectedValue + "'))");

        }
        else if ((ddlDateType.SelectedValue == "DR") && (txtFrom.Text != "") && (txtTo.Text != ""))
        {
            query.Append(" AND ((LV.FROM_DT BETWEEN CONVERT(VARCHAR,'" + commonFunctions.GetDateTime(txtFrom.Text) + "',101) AND CONVERT(VARCHAR,'" + commonFunctions.GetDateTime(txtTo.Text) + "',101)) OR (LV.TO_DT BETWEEN CONVERT(VARCHAR, '" + commonFunctions.GetDateTime(txtFrom.Text) + "',101) AND CONVERT(VARCHAR,'" + commonFunctions.GetDateTime(txtTo.Text) + "',101))) ");
        }
        if ((ddlViewType.SelectedValue == "1") || (ddlViewType.SelectedValue == "0"))
        {
            query.Append(" GROUP BY EV.EMP_ID, EV.EMP_NAME");
            if (ddlViewType.SelectedValue == "1")
            {
                query.Append(" ,LV.LV_VALUE");
            }
            if (sl == 1)
            {
                strGroup.Append(" ,LV.TO_DT");
            }
            query.Append(strGroup);
        }
        if (sl == 1)
        {
            query.Append(" ORDER BY LV.TO_DT ");
        }
        else
        {
            query.Append(" ORDER BY EV.EMP_ID");
        }
        ds = databaseFunctions.GetDataSetByQuery(query.ToString());
        Session["ds"] = ds.GetXml();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('rptLeave.aspx','_blank','resizable=1,width=900,height=650')", true);
    }
    protected void ddlDateType_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtTo.Text = txtFrom.Text = txtDate.Text = "";
        ddlYear.SelectedIndex = 0;
        trDaily.Visible = trYear.Visible = trMonth.Visible = trDR.Visible = false;
        if (ddlDateType.SelectedValue == "D")
            trDaily.Visible = true;
        else if (ddlDateType.SelectedValue == "M")
            trMonth.Visible = true;
        else if (ddlDateType.SelectedValue == "Y")
            trYear.Visible = true;
        else if (ddlDateType.SelectedValue == "DR")
            trDR.Visible = true;
    }


    protected void ddlLvType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlLvType.SelectedValue == "11")
        {
            trSL.Visible = trShort.Visible = true;
        }
        else
        {
            trSL.Visible = trShort.Visible = false;
        }
    }
}