using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Academic_BatchChange : System.Web.UI.Page
{
   
    FillFunctions FillFunction;
    QueryFunctions queryFunctions;
    AcaBLL ObjBll;
    AcaBAL ObjBal;
    CommonFunctions commonFunctions;
    DataSet ds;
    void Initialise()
    {
        FillFunction = new FillFunctions();
        queryFunctions = new QueryFunctions();
        commonFunctions = new CommonFunctions();
        ObjBll = new AcaBLL();
        ObjBal = new AcaBAL();
        ds = new DataSet();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
          btnShow.Attributes.Add("OnClick", "return validateShow()");
        btnChange.Attributes.Add("OnClick", "return validateChange()");
        Initialise();
        if (!IsPostBack)
        {
        }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        ObjBal.Stu_AdmNo = commonFunctions.GetKeyID(txtStudent);
        Student.ShowStudent(ObjBal.Stu_AdmNo);
            FillFunction.Fill(ddlBatch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Batch), true, FillFunctions.FirstItem.Select);
    
    }
    protected void btnChange_Click(object sender, EventArgs e)
    {
        ObjBal.SessionUserID = Session["UserId"].ToString();
        ObjBal.Stu_AdmNo = commonFunctions.GetKeyID(txtStudent);
        ObjBal.KeyID = ddlBatch.SelectedValue;
        ObjBal.Remark = txtRemark.Text;
        ds = ObjBll.ChangeBatch(ObjBal);
        string batch = ds.Tables[0].Rows[0]["ACA_BATCH_NAME"].ToString();

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('New Batch is " + batch + "')", true);
        txtRemark.Text = "";
        txtStudent.Text = "";
        ddlBatch.Items.Clear();
    }
}