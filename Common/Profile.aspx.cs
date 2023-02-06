using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
public partial class Common_Profile : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    QueryFunctions queryFunctions;
    CommonFunctions commonFunctions;
    DatabaseFunctions databaseFunctions;
    Messages Msgfun;
    HRBAL ObjHrBal;
    HRBLL ObjHrBll;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.MaintainScrollPositionOnPostBack = true;
        Initialize();
        if (!IsPostBack)
        {
            ViewState["ds"] = ds;
            bindData();
            step1.ActiveTabIndex = 0;
        }
    }

    void Initialize()
    {
        fillFunctions = new FillFunctions();
        queryFunctions = new QueryFunctions();
        commonFunctions = new CommonFunctions();
        databaseFunctions = new DatabaseFunctions();
        Msgfun = new Messages();
        ObjHrBal = new HRBAL();
        ObjHrBll = new HRBLL();
        ds = new DataSet();
    }

    void Clear()
    {
        lblBldGroup.Text = lblCaste.Text = lblCode.Text = lblDept.Text = lblDes.Text = lblDob.Text = lblDOJ.Text = lblEmail.Text = lblfName.Text = lblIns.Text = "";
        lblMarSts.Text = lblMob.Text = lblMthrTongue.Text = lblName.Text = lblNationality.Text = lblNxtKin.Text = lblNxtSenior.Text = lblPhn.Text = lblPrmntAdd.Text = "";
        lblPrsntAdd.Text = lblRel.Text = lblSpsName.Text = "";
        gvDocument.DataSource = gvExprience.DataSource = gvQualification.DataSource = "";
        gvDocument.DataBind();
        gvExprience.DataBind();
        gvQualification.DataBind();
    }

    void bindData()
    {
        Clear();
        ObjHrBal.EmpId = Session["LoginId"].ToString();
        ds = ObjHrBll.GetEmpProfile(ObjHrBal);
        ViewState["ds"] = ds;

        string empImage = "../images/emp_images/" + Session["LoginId"].ToString() + "_thumb.jpg";
        if (System.IO.File.Exists(Server.MapPath(empImage)))
            imgPicture.Src = empImage;
        else
            imgPicture.Src = "../images/emp_images/empImage.jpg";
        /*PERSONAL INFO*/
        DataRow dr;
        if (ds.Tables[0].Rows.Count != 0)
        {
            dr = ds.Tables[0].Rows[0];
            lblName.Text = dr["EMP_NAME"].ToString();
            lblfName.Text = dr["EMP_FTH_NAME"].ToString();
            lblMarSts.Text = dr["MAR_STS_VALUE"].ToString();
            lblSpsName.Text = dr["SPOUSE_NAME"].ToString();
            lblRel.Text = dr["REL_VALUE"].ToString();
            lblNxtKin.Text = dr["NEXT_KIN_NAME"].ToString();
            lblDob.Text = dr["DOB"].ToString();
            lblCaste.Text = dr["CAS_VALUE"].ToString();
            lblMthrTongue.Text = dr["MOT_TON_VALUE"].ToString();
            //lblBrthPlace.Text = dr[""].ToString();
            lblBldGroup.Text = dr["BLO_GRP_VALUE"].ToString();
            lblNationality.Text = dr["NAT_VALUE"].ToString();
            lblStatus.Text = dr["STS_VALUE"].ToString();
        }


        /*DEPARTMENTAL INFO*/
        if (ds.Tables[1].Rows.Count != 0)
        {
            dr = ds.Tables[1].Rows[0];
            lblCode.Text = dr["EMP_MUID"].ToString();
            lblDOJ.Text = dr["DOJ"].ToString();
            lblNxtSenior.Text = dr["NEXT_SENIOR"].ToString();
            lblDes.Text = dr["DES_VALUE"].ToString();
            lblDept.Text = dr["DEPT_VALUE"].ToString();
            lblIns.Text = dr["INS_VALUE"].ToString();
        }

        /*ADDRESS INFO*/

        if (ds.Tables[2].Rows.Count != 0)
        {
            dr = ds.Tables[2].Rows[0];
            lblPrsntAdd.Text = dr["Present_Add"].ToString();
            lblPrmntAdd.Text = dr["Permanent_Add"].ToString();
        }

        /*CONTACT INFO*/

        if (ds.Tables[3].Rows.Count != 0)
        {
            dr = ds.Tables[3].Rows[0];
            lblEmail.Text = dr["MAIL_OFFICIAL"].ToString();
            lblPerEmail.Text = dr["MAIL_PERSONAL"].ToString();
            lblMob.Text = dr["MOB"].ToString();
            //lblPhn.Text = dr[""].ToString();
        }

        /*DOCUMENT INFO*/
        fillFunctions.Fill(gvDocument, ds.Tables[4]);
        foreach (GridViewRow row in gvDocument.Rows)
        {
            if (row.Cells[2].Text == "PENDING")
            {
                row.BackColor = Color.Red;
                row.ForeColor = Color.Black;
            }
        }


        /*QUALIFICATION INFO*/
        fillFunctions.Fill(gvQualification, ds.Tables[5]);

        /*EXPERIENCE INFO*/
        fillFunctions.Fill(gvExprience, ds.Tables[6]);

    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        DropDownList ddlMonth = (DropDownList)MonthYear1.FindControl("ddlMonth");
        DropDownList ddlYear = (DropDownList)MonthYear1.FindControl("ddlYear");
        try
        {
            String url = "PrintSalarySlip.aspx?" + ddlMonth.SelectedValue + "-" + ddlYear.SelectedValue;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('"+url+"','_blank','resizable=1,width=600,height=650')", true);
        }
        catch {
 
        
        }
    }
    protected void step1_ActiveTabChanged(object sender, EventArgs e)
    {
        ds = (DataSet)ViewState["ds"];
        if (step1.ActiveTabIndex == 0)
        {
            fillFunctions.Fill(gvDocument, ds.Tables[4]);
            foreach (GridViewRow row in gvDocument.Rows)
            {
                if (row.Cells[2].Text == "PENDING")
                {
                    row.BackColor = Color.Red;
                    row.ForeColor = Color.Black;
                }
            }

        }
        else if (step1.ActiveTabIndex == 1)
        {
            fillFunctions.Fill(gvQualification, ds.Tables[5]);
        }
        else if (step1.ActiveTabIndex == 2)
        {
            fillFunctions.Fill(gvExprience, ds.Tables[6]);
        }
    }

    protected void btnModPI_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('EditProfile.aspx','_blank','width=700, scrollbars=1, left=100')", true);
    }
}