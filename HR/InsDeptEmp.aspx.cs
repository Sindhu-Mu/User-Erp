using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
public partial class HR_InsDeptEmp : System.Web.UI.Page
{
    FillFunctions fillfunctions;
    QueryFunctions queryfunctions;
    CommonFunctions common;
    DataTable dt;
    HRBLL ObjHrBll;
    HRBAL ObjHrBAL;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            fillfunctions.Fill(ddlIns, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
            fillfunctions.Fill(ddlDept, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.DeptType), true, FillFunctions.FirstItem.Select);
            fillfunctions.Fill(ddlGen, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Gender), true, FillFunctions.FirstItem.Select);
        }
    }

    private void Initialize()
    {
        fillfunctions = new FillFunctions();
        queryfunctions = new QueryFunctions();
        common = new CommonFunctions();
        dt = new DataTable();
        ObjHrBll = new HRBLL();
        ObjHrBAL = new HRBAL();
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        ObjHrBAL.InsId = ddlIns.SelectedValue;
        ObjHrBAL.DeptId = ddlDept.SelectedValue;
        ObjHrBAL.KeyID = ddlGen.SelectedValue;
        DataTable dt = ObjHrBll.GetEmpList(ObjHrBAL).Tables[0];
        ArrayList alName = new ArrayList();
        ArrayList alCode = new ArrayList();
        Random rnd = new Random();
        for (int i = 0; i < dt.Rows.Count;++i )
        {
            alName.Add(dt.Rows[i][1]);
            alCode.Add(dt.Rows[i][0]);
        }
        int randomIndex = rnd.Next(0, dt.Rows.Count);
       lblName.Text=Convert.ToString(alName[randomIndex]);
       lblCode.Text = Convert.ToString(alCode[randomIndex]);

        
        //gvEmpList.DataSource = ObjHrBll.GetEmpList(ObjHrBAL).Tables[0];
        //gvEmpList.DataBind();
    }
    protected void ddlIns_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIns.SelectedIndex > 0)
        {
            fillfunctions.Fill(ddlDept, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Department, ddlIns.SelectedValue), true, FillFunctions.FirstItem.Select);
        }
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        ObjHrBAL.InsId = ddlIns.SelectedValue;
        ObjHrBAL.DeptId = ddlDept.SelectedValue;
        ObjHrBAL.KeyID = ddlGen.SelectedValue;
        DataTable dt = ObjHrBll.GetEmpList(ObjHrBAL).Tables[1];
        ArrayList alName = new ArrayList();
        ArrayList alCode = new ArrayList();
        Random rnd = new Random();
        for (int i = 0; i < dt.Rows.Count; ++i)
        {
            alName.Add(dt.Rows[i][1]);
            alCode.Add(dt.Rows[i][0]);
        }
        int randomIndex = rnd.Next(0, dt.Rows.Count);
        lblName.Text = Convert.ToString(alName[randomIndex]);
        lblCode.Text = Convert.ToString(alCode[randomIndex]);
    }
}