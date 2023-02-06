using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Common_EditProfile : System.Web.UI.Page
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
        Initialize();
        pushData();

        if (!IsPostBack)
        {
            bindData();
            ViewState["ds"] = ds;
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

    void pushData()
    {
        fillFunctions.Fill(ddlNationality, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Nationality), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlCaste, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Caste), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlInitial, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Initial), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlBlood, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.BloodGroup), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlReligion, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Religion), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlDesignation, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Designation), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlDept, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Department), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlInstitution, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
    }

    void bindData()
    {
        ObjHrBal.EmpId = Session["LoginId"].ToString();
        ds = ObjHrBll.GetEmpProfile(ObjHrBal);
        ViewState["ds"] = ds;
        /*PERSONAL INFO*/
        DataRow dr;
        if (ds.Tables[0].Rows.Count != 0)
        {
            dr = ds.Tables[0].Rows[0];
            txtFname.Text = dr["F_NAME"].ToString();
            txtMname.Text = dr["M_NAME"].ToString();
            txtLname.Text = dr["L_NAME"].ToString();
            txtFathersName.Text = dr["EMP_FTH_NAME"].ToString();
            ddlMeritalStatus.SelectedValue = dr["MAR_ID"].ToString();
            txtSpouseName.Text = dr["SPOUSE_NAME"].ToString();
            ddlReligion.SelectedValue = dr["REL_ID"].ToString();
            txtNextKin.Text = dr["NEXT_KIN_NAME"].ToString();
            txtDOB.Text = dr["DOB"].ToString();
            ddlCaste.SelectedValue = dr["CAS_ID"].ToString();
            txtMotherTongue.Text = dr["MOT_TON_VALUE"].ToString();
            //lblBrthPlace.Text = dr[""].ToString();
            ddlBlood.SelectedValue = dr["BLO_GRP_ID"].ToString();
            ddlNationality.SelectedValue = dr["NAT_ID"].ToString();
            optLstSex.SelectedValue = dr["GEN_ID"].ToString();
        }


        /*DEPARTMENTAL INFO*/
        if (ds.Tables[1].Rows.Count != 0)
        {
            dr = ds.Tables[1].Rows[0];
            lblCode.Text = dr["EMP_MUID"].ToString();
            ddlNextSenior.Text = dr["NEXT_SENIOR"].ToString();
            ddlDesignation.Text = dr["DES_ID"].ToString();
            ddlDept.SelectedValue = dr["DEPT_ID"].ToString();
            ddlInstitution.SelectedValue = dr["INS_ID"].ToString();
            txtDOJ.Text = dr["DOJ"].ToString();
        }

        /*ADDRESS INFO*/

        if (ds.Tables[2].Rows.Count != 0)
        {
            dr = ds.Tables[2].Rows[0];
            txtPresentAddres.Text = dr["Present_Add"].ToString();
            txtPermanentAddress.Text = dr["Permanent_Add"].ToString();
        }

        /*CONTACT INFO*/

        if (ds.Tables[3].Rows.Count != 0)
        {
            dr = ds.Tables[3].Rows[0];
            txtEmailID.Text = dr["MAIL"].ToString();
            txtMobileNo.Text = dr["MOB"].ToString();
            //lblPhn.Text = dr[""].ToString();
        }

        if (ds.Tables[7].Rows.Count != 0)
        {
            dr = ds.Tables[7].Rows[0];
            txtAcNo.Text = dr["ACC_NO"].ToString();
            txtBank.Text = dr["BANK_VALUE"].ToString();
            txtPan.Text = dr["PAN_NO"].ToString();
        }


    }

}