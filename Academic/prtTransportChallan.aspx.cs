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

public partial class Academic_prtTransportChallan : System.Web.UI.Page
{
    AcaBAL Objbal;
    AcaBLL ObjBll;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (Request.QueryString.HasKeys())
        {
            string REG_RTE_ID = Request.QueryString["REG_ROUTE_ID"].ToString();
            Objbal.Id = REG_RTE_ID;
            Objbal.SessionUserID = Session["UserId"].ToString();
            Objbal.CommonId = Session["Id"].ToString();
            ds = ObjBll.GetChlData(Objbal);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblChNo2.Text = lblChNo3.Text = lblCno.Text = ds.Tables[0].Rows[0]["CHALLAN_NO"].ToString();
                lblEnrollment1.Text = lblEnrollment2.Text = lblEnrollment3.Text = ds.Tables[0].Rows[0]["ENROLLMENT_NO"].ToString() + "(" + ds.Tables[0].Rows[0]["SEM_ROLL_NO"].ToString() + ")";
                lblFather1.Text = lblFather2.Text = lblFather3.Text = ds.Tables[0].Rows[0]["FATHER_NAME"].ToString();
                lblStuName1.Text = lblStuName2.Text = lblStuName3.Text = ds.Tables[0].Rows[0]["STU_FULL_NAME"].ToString();
                lblINs.Text = lblIns2.Text = lblIns3.Text = ds.Tables[0].Rows[0]["INS_VALUE"].ToString();
                lblTFee1.Text = lblTFee2.Text = lblTfee3.Text = Convert.ToDouble(ds.Tables[0].Rows[0]["RATE_SEM"]).ToString("N2");
                lblTFine3.Text = lblFine1.Text = lblTFine2.Text = "0.00";
                lblTotal1.Text = lblTotal2.Text = lblTotal3.Text = Convert.ToDouble(ds.Tables[0].Rows[0]["RATE_SEM"]).ToString("N2");
                lblSem.Text = lblSem2.Text = lblSem3.Text = ds.Tables[0].Rows[0]["ACA_SEM_ID"].ToString();
                //(Convert.ToInt32(Dt.Rows[0]["ACA_SEM_ID"]) % 2 == 1) ? Dt.Rows[0]["ACA_SEM_ID"].ToString() : (Convert.ToInt32(Dt.Rows[0]["ACA_SEM_ID"]) + 1).ToString();
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                lblBank1.Text = lblBank2.Text = lblBank3.Text = ds.Tables[1].Rows[0]["BANK_VALUE"].ToString();
                lblBranch1.Text = lblBranch2.Text = lblBranch3.Text = ds.Tables[1].Rows[0]["BANK_AC_BRANCH"].ToString();
                lblAccountName1.Text = lblAccountName2.Text = lblAccountName3.Text = ds.Tables[1].Rows[0]["BANK_AC_REMARK"].ToString();
                lblAccountNo1.Text = lblAccountNo2.Text = lblAccountNo3.Text = ds.Tables[1].Rows[0]["BANK_AC_NO"].ToString();
            }
        }
    }
    void Initialize()
    {
        Objbal = new AcaBAL();
        ObjBll = new AcaBLL();
        ds = new DataSet();
    }
}