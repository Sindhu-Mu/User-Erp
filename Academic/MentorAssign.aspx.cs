using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.IO;


public partial class Academic_MentorAssign : System.Web.UI.Page
{
    AcaBAL ObjAcaBal;
    AcaBLL ObjAcaBll;
    FillFunctions FillFunction;
    QueryFunctions QueryFunction;
    CommonFunctions CommonFunction;
    DatabaseFunctions DataBaseFunction;
    string Msg;
    DataTable Dt;
    DataTable dt;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnAssign.Attributes.Add("OnClick", "return Pagevalidation()");
        if (!IsPostBack)
        {
            FillFunction.Fill(ddlIns, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
            FillFunction.Fill(ddlSem, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.Select);
            FillFunction.Fill(ddlPgm, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Program), true, FillFunctions.FirstItem.Select);
            FillFunction.Fill(ddlBranch, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.branch), true, FillFunctions.FirstItem.Select);
            FillFunction.Fill(ddlSec, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Section), true, FillFunctions.FirstItem.Select);
        }
      
    }
    void Initialize()
    {
        ObjAcaBal = new AcaBAL();
        ObjAcaBll = new AcaBLL();
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        CommonFunction = new CommonFunctions();
        DataBaseFunction = new DatabaseFunctions();
        Dt = new DataTable();
    }
    protected void ddlIns_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillFunction.Fill(ddlPgm, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlIns.SelectedValue), true, FillFunctions.FirstItem.Select);
    }
    protected void ddlPgm_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillFunction.Fill(ddlBranch, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Branch, ddlPgm.SelectedValue), true, FillFunctions.FirstItem.Select);
    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        ObjAcaBal.InsId = ddlIns.SelectedValue;
        ObjAcaBal.Pgm_Id = ddlPgm.SelectedValue;
        ObjAcaBal.Brn_Id = ddlBranch.SelectedValue;
        ObjAcaBal.Semid = ddlSem.SelectedValue;
        ObjAcaBal.Sec_Id = ddlSec.SelectedValue;
        Dt = ObjAcaBll.AssignMentor(ObjAcaBal).Tables[0];
        gvMentor.DataSource = Dt;
        gvMentor.DataBind();
        if (Dt.Rows.Count < 1)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('There is No Student in this Class')", true);
        }
        
    }
    void Add()
    {
        XmlDocument xmlData = new XmlDocument();
        XmlElement ROOT;
        if (txtXML.Text != "")
        {
            xmlData.LoadXml(txtXML.Text);
            ROOT = xmlData.DocumentElement;
        }
        else
        {
            ROOT = xmlData.CreateElement("MENTOR");
            xmlData.AppendChild(ROOT);
        }
        foreach (GridViewRow itm in gvMentor.Rows)
        {
            CheckBox chkSelect = (CheckBox)gvMentor.Rows[itm.RowIndex].FindControl("chk");
            if (chkSelect.Checked)
            {
                XmlElement dataElement = xmlData.CreateElement("STU_ID");
                ROOT.AppendChild(dataElement);
                XmlElement element = xmlData.CreateElement("STU_MAIN_ID");
                element.InnerText = gvMentor.DataKeys[itm.RowIndex].Values[0].ToString();
                dataElement.AppendChild(element);
            }
        }
        txtXML.Text = xmlData.OuterXml;
    }
    void FillGrid()
    {
        ObjAcaBal.EmpId = CommonFunction.GetKeyID(txtEmpShow);
        ViewState["Id"] = ObjAcaBll.GetEmployeeUsrId(ObjAcaBal);
        ObjAcaBal.Id = ViewState["Id"].ToString();
        dt = ObjAcaBll.MentorDetail(ObjAcaBal).Tables[0];
        gvDetail.DataSource = dt;
        gvDetail.DataBind();
    }

        protected void btnAssign_Click(object sender, EventArgs e)
    {
        int cnt = 0;
            foreach (GridViewRow obj in gvMentor.Rows)
            {
                CheckBox chkbox = (CheckBox)obj.FindControl("chk");
                if (chkbox.Checked)
                {
                    cnt = 1;
                    break;
                }
            }
            if (cnt == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Please Select the Students')", true);
            }
            else
            {
                Add();
                ObjAcaBal.EmpId = CommonFunction.GetKeyID(txtEmp);
                ObjAcaBal.SessionUserID = Session["UserId"].ToString();
                ObjAcaBal.XmlValue = txtXML.Text;
                Msg = ObjAcaBll.AssignStuInsert(ObjAcaBal);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('" + Msg + "')", true);
                clear();
                txtXML.Text = "";
                gvMentor.DataSource = "";
                gvMentor.DataBind();
            }


    }
    void clear()
    {
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlIns);
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlPgm);
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlBranch);
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlSem);
        txtEmp.Text = "";
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        ObjAcaBal.EmpId = CommonFunction.GetKeyID(txtEmpShow);
        ViewState["Emp_Id"] = ObjAcaBll.GetEmployeeUsrId(ObjAcaBal);
        ObjAcaBal.Id = ViewState["Emp_Id"].ToString();
        dt = ObjAcaBll.MentorDetail(ObjAcaBal).Tables[0];
        gvDetail.DataSource = dt;
        gvDetail.DataBind();
        if (dt.Rows.Count > 0)
        {
            trAdd.Visible = true;
        }
    }
    protected void gvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ObjAcaBal.Stu_AdmNo = gvDetail.DataKeys[e.RowIndex].Value.ToString();
        ObjAcaBal.EmpId = ViewState["Emp_Id"].ToString();
        Msg = ObjAcaBll.DeleteStuMentor(ObjAcaBal);
        FillGrid();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('" + Msg + "')", true);
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ObjAcaBal.EmpId = ViewState["Emp_Id"].ToString();
        ObjAcaBal.Stu_AdmNo = CommonFunction.GetKeyID(txtStu);
        ViewState["Stu"] = ObjAcaBll.GetStudentMainId(ObjAcaBal);
        ObjAcaBal.Id = ViewState["Stu"].ToString();
        ObjAcaBal.SessionUserID = Session["UserId"].ToString();
        ObjAcaBll.AddStuMentor(ObjAcaBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('" + Msg + "')", true);
        FillGrid();
        txtStu.Text = "";
    }
}