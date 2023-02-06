using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;


public partial class Academic_MentorShipFormView : System.Web.UI.Page
{
    string Filter;
    int Filter_Type;
    AcaBAL ObjAcaBal;
    AcaBLL ObjAcaBll;
    FillFunctions FillFunction;
    QueryFunctions QueryFunction;
    CommonFunctions CommonFunction;
     DatabaseFunctions DataBaseFunction;
     DataSet DS;
     //DataSet ds;
     DataTable dt;
    SqlCommand cmd1 = new SqlCommand();

    void Initialize()
    {
        ObjAcaBal = new AcaBAL();
        ObjAcaBll = new AcaBLL();
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        CommonFunction = new CommonFunctions();
        DataBaseFunction = new DatabaseFunctions();
        DS=new DataSet();
        //ds = new DataSet();
        dt=new DataTable();
       
    }
    //void FillGrid()
    //{
    //    ObjAcaBal.Id = Session["UserId"].ToString();
    //    ds = ObjAcaBll.MentorDetail(ObjAcaBal);
    //    ViewState["ds"] = ds;
    //    gvStu.DataSource = ds.Tables[0];
    //    gvStu.DataBind();
    //}
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.Count > 0)
        {
            DataBaseFunction = new DatabaseFunctions();
            DS = new DataSet();
            cmd1 = new SqlCommand();
            cmd1.CommandText = "STU_MENTORING_SELECT";
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@STU_MAIN_ID", Request.QueryString[0].ToString());
            DS = DataBaseFunction.GetDataSet(cmd1);
            rdoBehaviour.SelectedValue = DS.Tables[0].Rows[0]["BEHAVE"].ToString();
            rdoParents.SelectedValue = DS.Tables[0].Rows[0]["PARENT"].ToString();
            GvAdd.DataSource = DS.Tables[1];
            GvAdd.DataBind();
            gvAttSugg.DataSource = DS.Tables[0];
            gvAttSugg.DataBind();
            gvAcaSugg.DataSource = DS.Tables[0];
            gvAcaSugg.DataBind();
            gvBehSugg.DataSource = DS.Tables[0];
            gvBehSugg.DataBind();
            gvMentee.DataSource = DS.Tables[2];
            gvMentee.DataBind();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "MENTORSHIP_PROFILE_SELECT";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@STU_MAIN_ID", Request.QueryString[0].ToString());
            DataSet ds = DataBaseFunction.GetDataSet(cmd);
            dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                lblMentee.Text = dt.Rows[0]["STU_FULL_NAME"].ToString();
                imgPicture.Src = "../images/Stuimages/" + dt.Rows[0]["ENROLLMENT_NO"].ToString() + ".jpg";
                lblEnroll.Text = dt.Rows[0]["ENROLLMENT_NO"].ToString();
                lblAddress.Text = dt.Rows[0]["ADD_1"].ToString() + ' ' + dt.Rows[0]["ADD_2"].ToString() + ' ' + dt.Rows[0]["CIT_VALUE"].ToString();
                lblMentor.Text = dt.Rows[0]["EMP_NAME"].ToString();
                lblContPart.Text = dt.Rows[0]["PARENT_CONTACT"].ToString();
                lblBranch.Text = dt.Rows[0]["BRN_SHORT_NAME"].ToString();
                lblSection.Text = dt.Rows[0]["ACA_SEC_NAME"].ToString();
                lblProgram.Text = dt.Rows[0]["PGM_SHORT_NAME"].ToString();
                lblInst.Text = dt.Rows[0]["INS_VALUE"].ToString();
                lblContStu.Text = dt.Rows[0]["PHN_NO"].ToString();
                lblSem.Text = dt.Rows[0]["ACA_SEM_ID"].ToString();
                gvPrevQuali.DataSource = ds.Tables[1];
                gvPrevQuali.DataBind();
            }
            ViewState["ds"] = ds;
        }
        
        PopulateDataOnCharts(Filter, Filter_Type);
        FillAttendance();

    }

     void FillAttendance()
    {
        DataSet ds2 = (DataSet)ViewState["ds"];
        gvAttendance.DataSource = ds2.Tables[2];
        gvAttendance.DataBind();
        gvMarks.DataSource = ds2.Tables[3];
        gvMarks.DataBind();
        gvSemResult.DataSource = ds2.Tables[4];
        gvSemResult.DataBind();
        if (ds2.Tables[5].Rows.Count > 0)
        {
            gvBack.DataSource = ds2.Tables[5];
            gvBack.DataBind();
        }
        //else
        //{
        //    gvBack.Visible = false;
        //}

    }

     private void PopulateDataOnCharts(string Filter, int Filter_Type)
     {
         Initialize();


         DataSet ds1 = (DataSet)ViewState["ds"];
         if (ds1.Tables[2] != null)
         {
             Chart1.DataSource = ds1.Tables[2];
             Chart1.DataBind();
         }
         if (ds1.Tables[3] != null)
         {
             Chart2.DataSource = ds1.Tables[3];
             Chart2.DataBind();
         }
     }

   
}