using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.Text;

public partial class Academic_OpenElecStuAttendance : System.Web.UI.Page
{

    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    AcaBAL objBal;
    AcaBLL objBll;
    DataSet ds;
    string Msg;
    void Initialize()
    {
        queryFunctions = new QueryFunctions();
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        objBal = new AcaBAL();
        objBll = new AcaBLL();
        ds = new DataSet();
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        Initialize();
        btnView.Attributes.Add("OnClick", "return validate()");
        txtSubmit.Attributes.Add("OnClick", "return validate2()");
        if (!IsPostBack)
        {
            LoadData();
            rowHide.Visible = false;
        }
    }
    void LoadData()
    {
        fillFunctions.Fill(ddlPaper, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.OpnElecPap), true, FillFunctions.FirstItem.Select);
        
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        objBal.Pap_Code = ddlPaper.SelectedValue;
        objBal.SessionUserID = Session["UserId"].ToString();
        ds = objBll.OpenElectiveAttendance(objBal);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvStudent.Visible = true;
            gvStudent.DataSource = ds.Tables[0];
            gvStudent.DataBind();
            rowHide.Visible = true;
        }
        else
        {
            gvStudent.Visible = false;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Another faculty is assigned for this paper')", true);
        }
    }
    protected void txtSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            StringBuilder data = new StringBuilder();
            data.AppendFormat("<Attendance>");
            foreach (GridViewRow row in gvStudent.Rows)
            {
                CheckBox chkAttendance = (CheckBox)row.FindControl("chkStudent");
                if (chkAttendance.Checked)
                    data.AppendFormat("<StuData STU_MAIN_ID=\"" + gvStudent.DataKeys[row.RowIndex].Values[0].ToString() + "\" STU_ELEC_ID= \"" + gvStudent.DataKeys[row.RowIndex].Values[1].ToString() +
                        "\" ATT_STS= \"" + 0 + "\" />");
                else
                    data.AppendFormat("<StuData STU_MAIN_ID=\"" + gvStudent.DataKeys[row.RowIndex].Values[0].ToString() + "\" STU_ELEC_ID= \"" + gvStudent.DataKeys[row.RowIndex].Values[1].ToString() +
                     "\" ATT_STS= \"" + 1 + "\" />");
            }
            data.AppendFormat("</Attendance>");
            objBal.XmlValue = data.ToString();
            ////objBal.Pap_Code = ddlPaper.SelectedValue;
            objBal.Date = commonFunctions.GetDateTime(txtClsDate.Text);
            objBal.SessionUserID = Session["UserId"].ToString();
            objBll.saveOpenElecAtt(objBal);
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Attendance for this date is already marked')", true);
            Clear(false);
            return;
        }
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Attendance is successfully marked. Please switch to the Report page for more details.')", true);
        Clear(false);
    }

    private void Clear(bool value)
    {
        commonFunctions.Clear(gvStudent);
        rowHide.Visible = false;
       
    }
}