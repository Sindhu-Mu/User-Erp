using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Academic_StuFeeChalan : System.Web.UI.Page
{
    AcaBAL ObjAcaBal;
    AcaBLL ObjAcaBll;
    FillFunctions FillFunction;
    QueryFunctions Queryfunction;
    CommonFunctions CommonFuntion;
    DatabaseFunctions DataBaseFunction;
    DataTable Dt;
    

    protected void Page_Load(object sender, EventArgs e)
    {
        btnShow.Attributes.Add("onClick", "return Validate()");
        btnPrint.Attributes.Add("onClick", "return validation()");
        Initialize();
        if (!IsPostBack)
        {
            FillFunction.Fill(ddlSem, Queryfunction.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.Select);
        }
    }
    void Initialize()
    {
        ObjAcaBal = new AcaBAL();
        ObjAcaBll = new AcaBLL();
        FillFunction = new FillFunctions();
        Queryfunction = new QueryFunctions();
        DataBaseFunction = new DatabaseFunctions();
        Dt = new DataTable();
        CommonFuntion = new CommonFunctions();
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        ddlFeeAccount.SelectedIndex = ddlType.SelectedIndex = ddlSem.SelectedIndex = 0;
        if (txtEnroll.Text != "")
        {
            string[] st = new string[2];
            st = txtEnroll.Text.Split(':');
            if (st.Length > 1)
            {
                Student.ShowStudent(st[1]);
                ViewState["Id"] = st[1];
            }
        }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    { Session["Id"] = ddlFeeAccount.SelectedValue;
        if (ddlType.SelectedValue == "1")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prtFeeChallan.aspx?" + ViewState["Id"].ToString() + ";" + ddlSem.SelectedValue + "','_blank','alwaysRaised')", true);
        }
        if (ddlType.SelectedValue == "2")
        {
            ObjAcaBal.Stu_AdmNo = ViewState["Id"].ToString();
            ObjAcaBal.Id = ObjAcaBll.GetStudentMainId(ObjAcaBal);
             string id = ObjAcaBll.GetTptcln(ObjAcaBal);
             if (id == "0")
             {
                 ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Transport Request Is Not Approved Yet.')", true);
                 ddlType.SelectedIndex = ddlSem.SelectedIndex = 0;
                 txtEnroll.Text = "";
             }
             else
             {
                 ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prtTransportChallan.aspx?REG_ROUTE_ID=" + id + "','_blank','alwaysRaised')", true);
             }
        }
        if (ddlType.SelectedValue == "3")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prtFeeDemand.aspx?" + ViewState["Id"].ToString() + ";" + ddlSem.SelectedValue + "','_blank','alwaysRaised')", true);
        }
    }
}