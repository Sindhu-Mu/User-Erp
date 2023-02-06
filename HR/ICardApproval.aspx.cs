using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;


public partial class HR_ICardApproval : System.Web.UI.Page
{
    FillFunctions fillfunction;
    QueryFunctions queryfunction;
    CommonFunctions common;
    DataTable dt;
    DataSet ds;
    HRBLL ObjHrBll;
    HRBAL ObjAcaBAL;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
       
        if (!IsPostBack)
        {
            show();
            Table1.Visible = false;
        }
    }
    private void Initialize()
    {
        fillfunction = new FillFunctions();
        queryfunction = new QueryFunctions();
        common = new CommonFunctions();
        dt = new DataTable();
        ds = new DataSet();
        ObjHrBll = new HRBLL();
        ObjAcaBAL = new HRBAL();
    }
    public void show()
    {

        ds = ObjHrBll.GetICardAppr(ObjAcaBAL);
        gvShow.DataSource = ds.Tables[0];
        gvShow.DataBind();
        ViewState["EMP_ID"] = "";
    }
    protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        ViewState["index"] = index.ToString();

        ViewState["EMP_ID"]=ObjAcaBAL.EmpId = gvShow.DataKeys[index].Values[0].ToString();
        DataSet ds = ObjHrBll.EmpCardPrint(ObjAcaBAL.EmpId);
        Table1.Visible = true;
        string empImage = "../images/emp_images/" + ViewState["EMP_ID"] + "_thumb.jpg";
        if (System.IO.File.Exists(Server.MapPath(empImage)))
            imgEmp.Src = empImage;
        else
        {
            imgEmp.Src = "../images/emp_images/empImage.jpg";
            
        }
        DataRow dr;
        if (ds.Tables[0].Rows.Count != 0)
        {
            dr = ds.Tables[0].Rows[0];
            lblAddress.Text = dr["PRESENT_ADD"].ToString();
            lblname.Text = dr["EMP_NAME"].ToString();
            lblfather.Text = dr["FATHER_NAME"].ToString();
            lbldesig.Text = dr["DESIG_NAME"].ToString();
            lbldepart.Text = dr["DEPT_VALUE"].ToString();
            lblDOB.Text = dr["DOB"].ToString();
            lblContact.Text = dr["PHONE"].ToString();
            lblDOJ.Text = dr["DOJ"].ToString();
            lblCode.Text = dr["EMP_ID"].ToString();
            lblBlood.Text = dr["Blood_Group"].ToString();
            string a = dr["STATUS"].ToString();
            if (a == "0")
            {
                BtnApprove.Visible = false;
                btnReject.Visible = false;
            }

        }
        lblApplyTime.Text = ds.Tables[1].Rows[0]["COUT"].ToString();
    }
    protected void Approve_Click(object sender, EventArgs e)
    {
        ObjAcaBAL.EmpId = ViewState["EMP_ID"].ToString();
        ds = ObjHrBll.ApprovICard(ObjAcaBAL.EmpId);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Approved Successfully')", true);
         show();
         Table1.Visible = false;
        //BtnApprove.Visible = false;
    }

    protected void gvShow_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = e.Row.DataItem as DataRowView;
            if (drv["STATUS"].ToString().Equals("Rejected"))
            {
                e.Row.BackColor = System.Drawing.Color.Red;
            }
            
        }
    }
    protected void btnReject_Click(object sender, EventArgs e)
    {
        ObjAcaBAL.EmpId = ViewState["EMP_ID"].ToString();
        ds = ObjHrBll.RejctICard(ObjAcaBAL.EmpId);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Rejected Successfully')", true);
        show();
        Table1.Visible = false;
    }
}