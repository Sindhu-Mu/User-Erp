using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class TrainingAndPlacement_prtTNP_Training_Letter : System.Web.UI.Page
{
    FillFunctions fillFunction;
    DatabaseFunctions databaseFunctions;
    DataTable dt;
    TPBAL ObjBal;
    TPBLL ObjBll;


    public void initialise()
    {
        fillFunction = new FillFunctions();
        databaseFunctions = new DatabaseFunctions();
        ObjBal = new TPBAL();
        ObjBll = new TPBLL();

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        initialise();
        if (Request.QueryString.Count > 0)
        {
            ObjBal.Id = Request.QueryString[0].ToString();
            dt = ObjBll.TRAINING_LETTER_SELECT(ObjBal).Tables[0];
            lblDate.Text = dt.Rows[0]["PRNT_DATE"].ToString();
            lblTrngNo.Text = dt.Rows[0]["LETTER_NO"].ToString();
            string MAIN_ID = dt.Rows[0]["ENROLLMENT_NO"].ToString();
            ObjBal.Enrollment = Request.QueryString[1].ToString();
            dt = ObjBll.TRAINING_LETTER_SEL_DETAIL(ObjBal).Tables[0];
            if (dt.Rows.Count > 0)
            {
                lblName.Text = dt.Rows[0]["STU_FULL_NAME"].ToString();
                lblFthrName.Text = dt.Rows[0]["FATHER_NAME"].ToString();

                lblEnroll.Text = MAIN_ID + ")";
                lblCrs.Text = dt.Rows[0]["PGM_SHORT_NAME"].ToString();
                lblbranch.Text = "(" + dt.Rows[0]["BRN_FULL_NAME"].ToString() +")";
                lblSem.Text = dt.Rows[0]["ACA_SEM_NO"].ToString();
                lblseme.Text = dt.Rows[0]["ACA_SEM_NO"].ToString();
                lblCrse.Text = dt.Rows[0]["PGM_SHORT_NAME"].ToString();
                lblduration.Text = dt.Rows[0]["DURATION"].ToString();

            }
        }
    }
}