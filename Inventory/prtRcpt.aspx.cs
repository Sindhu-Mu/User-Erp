using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Inventory_prtRcpt : System.Web.UI.Page
{
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    INVBAL objBal;
    INVBLL objBll;
    DatabaseFunctions databaseFunctions;
    DataTable dt;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            if (Request.QueryString.Count > 0)
            {
                objBal.KeyId = Request.QueryString[0];
                dt = objBll.getIssuedDetail(objBal).Tables[0];
                DataRow dr = dt.Rows[0];

                lblBillNo.Text = dr["INV_ISSUE_ID"].ToString();
              
                lbldate.Text = dr["DATE"].ToString();
                //lblDate2.Text = dr["DATE"].ToString();  //lblBillNo2.Text = dr["INV_ISSUE_ID"].ToString(); //lblRegNo2.Text = dr["ENROLLMENT_NO"].ToString();
                //lblFomNo2.Text = dr["FORM_NO"].ToString(); //lblName2.Text = dr["STU_FULL_NAME"].ToString();//lblCourse2.Text = dr["PGM_SHORT_NAME"].ToString();
                //lblBranch2.Text = dr["BRN_SHORT_NAME"].ToString();  //lblItem2.Text = dr["ITEM"].ToString();//lblContact2.Text = dr["PHN_NO"].ToString();
                //lblAdd2.Text = dr["ADDRESS"].ToString();//lblemp2.Text = dr["ISSUED_BY"].ToString();
                lblReg_No.Text = dr["ENROLLMENT_NO"].ToString();
               
                lblFormNo.Text = dr["FORM_NO"].ToString();
               
                lblStu_Name.Text = dr["STU_FULL_NAME"].ToString();
               
                lblCourse.Text = dr["PGM_SHORT_NAME"].ToString();
              
                lblBranch.Text = dr["BRN_SHORT_NAME"].ToString();
                
                lblItem.Text = dr["ITEM"].ToString();
              
                lblContact.Text = dr["PHN_NO"].ToString();
           
                lbladdress.Text = dr["ADDRESS"].ToString();
               
                lblemp_name.Text = dr["ISSUED_BY"].ToString();
                
            }
        }
    }

    public void Initialize()
    {
        queryFunctions = new QueryFunctions();
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        objBal = new INVBAL();
        objBll = new INVBLL();
        databaseFunctions = new DatabaseFunctions();
        dt = new DataTable();
    }
}