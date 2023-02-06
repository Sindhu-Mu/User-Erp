using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Appraisal_PA03 : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions queryFunctions;
    APPBLL ObjBll;
    APPBAL ObjBal;
    CommonFunctions commonFunctions;
    DataSet ds;
    string PA03_FAC_ID;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialise();
        if (!IsPostBack)
        {
            gvStudentFead.DataSource = "";
            gvStudentFead.DataBind();
            if (Request.QueryString.HasKeys())
            {

                PA03_FAC_ID = Request.QueryString["id"];
                string status = Request.QueryString["sts"];
                ObjBal.Id = PA03_FAC_ID;
                if (Session["UserId"].ToString() == ObjBll.getId(ObjBal).Tables[0].Rows[0][0].ToString())
                {
                    tblhODComments.Visible = tblHOIComments.Visible = tblLvSmry.Visible = false;
                }
                else
                {
                    tblhODComments.Visible = tblHOIComments.Visible =  true;
                    BindLeave(PA03_FAC_ID);
                    BindExam(PA03_FAC_ID);
                }
                SetLabels(PA03_FAC_ID);
                //SetHeader();
               
               
                SetComments(PA03_FAC_ID);
                PushData(PA03_FAC_ID);


            }
        }
    }
    void Initialise()
    {
        FillFunction = new FillFunctions();
        queryFunctions = new QueryFunctions();
        commonFunctions = new CommonFunctions();
        ObjBll = new APPBLL();
        ObjBal = new APPBAL();
        ds = new DataSet();
    }
    void SetLabels(string id)
    {
        ObjBal.Id = id;
        ds = ObjBll.getFacultyDetails(ObjBal);
        DataRow dr = ds.Tables[0].Rows[0];
        lblEmpCode.Text = dr["EMP_ID"].ToString();
        lblDoj.Text = dr["DOJ"].ToString();
        lblFaculty.Text = dr["EMP_NAME"].ToString();
        lblDesignation.Text = dr["DES_VALUE"].ToString();
        lblDepartment.Text = dr["DEPT_VALUE"].ToString();
        lblInstitution.Text = dr["INS_DESC"].ToString();
        lblRFrom.Text = dr["FROM_DT"].ToString();
        lblRTo.Text = dr["TO_DT"].ToString();
        lblInstitution.Visible = true;
    }

    void PushData(string id)
    {
        ObjBal.Id = id;

        #region 1A
        ObjBll.BuildGrid(gridData1A, APPBLL.GridBuildMode.Report);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_1A, lblHeader1A, lblDescription1A);
        FillFunction.Fill(gridData1A, ObjBll.PA03_1A_GetData(ObjBal));
        #endregion

        #region 1B
        ObjBll.BuildGrid(gridData1B, APPBLL.GridBuildMode.Report);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_1B, lblHeader1B, lblDescription1B);
        FillFunction.Fill(gridData1B, ObjBll.PA03_1B_GetData(ObjBal));
        #endregion


        #region 2A
        ObjBll.BuildGrid(gridData2A, APPBLL.GridBuildMode.Report);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_2A, lblHeader2A, lblDescription2A);
        FillFunction.Fill(gridData2A, ObjBll.PA03_2A_GetData(ObjBal));
        #endregion

        #region 2B
        ObjBll.BuildGrid(gridData2B, APPBLL.GridBuildMode.Report);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_2B, lblHeader2B, lblDescription2B);
        FillFunction.Fill(gridData2B, ObjBll.PA03_2B_GetData(ObjBal));
        #endregion

        #region 2C
        ObjBll.BuildGrid(gridData2C, APPBLL.GridBuildMode.Report);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_2C, lblHeader2C, lblDescription2C);
        FillFunction.Fill(gridData2C, ObjBll.PA03_2C_GetData(ObjBal));
        #endregion

        #region 2D
        ObjBll.BuildGrid(gridData2D, APPBLL.GridBuildMode.Report);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_2D, lblHeader2D, lblDescription2D);
        FillFunction.Fill(gridData2D, ObjBll.PA03_2D_GetData(ObjBal));
        #endregion

        #region 2E
        ObjBll.BuildGrid(gridData2E, APPBLL.GridBuildMode.Report);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_2E, lblHeader2E, lblDescription2E);
        FillFunction.Fill(gridData2E, ObjBll.PA03_2E_GetData(ObjBal));
        #endregion
        #region 2F
        ObjBll.BuildGrid(gridData2F, APPBLL.GridBuildMode.Report);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_2F, lblHeader2F, lblDescription2F);
        ds = ObjBll.PA03_2F_GetData(ObjBal);
        if (ds.Tables[0].Rows.Count > 0)
        {

            txtCounselling.Text = ds.Tables[0].Rows[0][2].ToString();
            txtTotalTime.Text = ds.Tables[0].Rows[0][3].ToString();
            txtContact.Text = ds.Tables[0].Rows[0][4].ToString();
             txtAny1.Text = ds.Tables[0].Rows[0][5].ToString();
            txtAny2.Text = ds.Tables[0].Rows[0][6].ToString();
            txtAny3.Text = ds.Tables[0].Rows[0][7].ToString();
             txtAny4.Text = ds.Tables[0].Rows[0][8].ToString();
             txtAny5.Text = ds.Tables[0].Rows[0][9].ToString();
           
            gridData2F.DataSource = ds.Tables[1];
            gridData2F.DataBind();
        }
        #endregion


        #region 3A
        ObjBll.BuildGrid(gridData3A, APPBLL.GridBuildMode.Report);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_3A, lblHeader3A, lblDescription3A);
        FillFunction.Fill(gridData3A, ObjBll.PA03_3A_GetData(ObjBal));
        #endregion

        #region 3B
        ObjBll.BuildGrid(gridData3B, APPBLL.GridBuildMode.Report);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_3B, lblHeader3B, lblDescription3B);
        FillFunction.Fill(gridData3B, ObjBll.PA03_3B_GetData(ObjBal));
        #endregion

        #region 3C
        ObjBll.BuildGrid(gridData3C, APPBLL.GridBuildMode.Report);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_3C, lblHeader3C, lblDescription3C);
        FillFunction.Fill(gridData3C, ObjBll.PA03_3C_GetData(ObjBal));
        #endregion

        #region 3D
        ObjBll.BuildGrid(gridData3D, APPBLL.GridBuildMode.Report);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_3D, lblHeader3D, lblDescription3D);
        FillFunction.Fill(gridData3D, ObjBll.PA03_3D_GetData(ObjBal));
        #endregion

        #region 3E
        ObjBll.BuildGrid(gridData3E, APPBLL.GridBuildMode.Report);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_3E, lblHeader3E, lblDescription3E);
        FillFunction.Fill(gridData3E, ObjBll.PA03_3E_GetData(ObjBal));
        #endregion

        #region 4A
        ObjBll.BuildGrid(gridData4A, APPBLL.GridBuildMode.Report);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_4A, lblHeader4A, lblDescription4A);
        FillFunction.Fill(gridData4A, ObjBll.PA03_4_GetData(ObjBal));
        #endregion

        #region 5A
        ObjBll.BuildGrid(gridData5A, APPBLL.GridBuildMode.Report);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_5A, lblHeader5A, lblDescription5A);
        FillFunction.Fill(gridData5A, ObjBll.PA03_5A_GetData(ObjBal));
        #endregion

        #region 5B
        ObjBll.BuildGrid(gridData5B, APPBLL.GridBuildMode.Report);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_5B, lblHeader5B, lblDescription5B);
        FillFunction.Fill(gridData5B, ObjBll.PA03_5B_GetData(ObjBal));
        #endregion

        #region 5C
        ObjBll.BuildGrid(gridData5C, APPBLL.GridBuildMode.Report);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_5C, lblHeader5C, lblDescription5C);
        FillFunction.Fill(gridData5C, ObjBll.PA03_5C_GetData(ObjBal));
        #endregion

        #region 5D
        ObjBll.BuildGrid(gridData5D, APPBLL.GridBuildMode.Report);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_5D, lblHeader5D, lblDescription5D);
        FillFunction.Fill(gridData5D, ObjBll.PA03_5D_GetData(ObjBal));
        #endregion

        #region 5E
        ObjBll.BuildGrid(gridData5E, APPBLL.GridBuildMode.Report);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_5E, lblHeader5E, lblDescription5E);
        FillFunction.Fill(gridData5E, ObjBll.PA03_5E_GetData(ObjBal));
        #endregion

        #region 6A
        ObjBll.BuildGrid(gridData6A, APPBLL.GridBuildMode.Report);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_6A, lblHeader6A, lblDescription6A);
        FillFunction.Fill(gridData6A, ObjBll.PA03_6A_GetData(ObjBal));
        #endregion

        #region 6B
        ObjBll.BuildGrid(gridData6B, APPBLL.GridBuildMode.Report);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_6B, lblHeader6B, lblDescription6B);
        FillFunction.Fill(gridData6B, ObjBll.PA03_6B_GetData(ObjBal));
        #endregion

        #region 6C
        ObjBll.BuildGrid(gridData6C, APPBLL.GridBuildMode.Report);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_6C, lblHeader6C, lblDescription6C);
        FillFunction.Fill(gridData6C, ObjBll.PA03_6C_GetData(ObjBal));
        #endregion

        #region 6D
        ObjBll.BuildGrid(gridData6D, APPBLL.GridBuildMode.Report);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_6D, lblHeader6D, lblDescription6D);
        FillFunction.Fill(gridData6D, ObjBll.PA03_6D_GetData(ObjBal));
        #endregion

        #region 7A
        ObjBll.BuildGrid(gridData7A, APPBLL.GridBuildMode.Report);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_7A, lblHeader7A, lblDescription7A);
        FillFunction.Fill(gridData7A, ObjBll.PA03_7_GetData(ObjBal));
        #endregion

        #region 8A
        ObjBll.BuildGrid(gridData8A, APPBLL.GridBuildMode.Report);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_8A, lblHeader8A, lblDescription8A);
        FillFunction.Fill(gridData8A, ObjBll.PA03_8_GetData(ObjBal));
        #endregion

        if (lblDescription1A.Text != "")
            lblDescription1A.Text = "(" + lblDescription1A.Text + ")";
        if (lblDescription1B.Text != "")
            lblDescription1B.Text = "(" + lblDescription1B.Text + ")";
        if (lblDescription2A.Text != "")
            lblDescription2A.Text = "(" + lblDescription2A.Text + ")";
        if (lblDescription2B.Text != "")
            lblDescription2B.Text = "(" + lblDescription2B.Text + ")";
        if (lblDescription2C.Text != "")
            lblDescription2C.Text = "(" + lblDescription2C.Text + ")";
        if (lblDescription2D.Text != "")
            lblDescription2D.Text = "(" + lblDescription2D.Text + ")";
        if (lblDescription2E.Text != "")
            lblDescription2E.Text = "(" + lblDescription2E.Text + ")";
        if (lblDescription3A.Text != "")
            lblDescription3A.Text = "(" + lblDescription3A.Text + ")";
        if (lblDescription3B.Text != "")
            lblDescription3B.Text = "(" + lblDescription3B.Text + ")";
        if (lblDescription3C.Text != "")
            lblDescription3C.Text = "(" + lblDescription3C.Text + ")";
        if (lblDescription3D.Text != "")
            lblDescription3D.Text = "(" + lblDescription3D.Text + ")";
        if (lblDescription3E.Text != "")
            lblDescription3E.Text = "(" + lblDescription3E.Text + ")";
        if (lblDescription4A.Text != "")
            lblDescription4A.Text = "(" + lblDescription4A.Text + ")";
        if (lblDescription5A.Text != "")
            lblDescription5A.Text = "(" + lblDescription5A.Text + ")";
        if (lblDescription5B.Text != "")
            lblDescription5B.Text = "(" + lblDescription5B.Text + ")";
        if (lblDescription5C.Text != "")
            lblDescription5C.Text = "(" + lblDescription5C.Text + ")";
        if (lblDescription5D.Text != "")
            lblDescription5D.Text = "(" + lblDescription5D.Text + ")";
        if (lblDescription5E.Text != "")
            lblDescription5E.Text = "(" + lblDescription5E.Text + ")";
        if (lblDescription6A.Text != "")
            lblDescription6A.Text = "(" + lblDescription6A.Text + ")";
        if (lblDescription6B.Text != "")
            lblDescription6B.Text = "(" + lblDescription6B.Text + ")";
        if (lblDescription6C.Text != "")
            lblDescription6C.Text = "(" + lblDescription6C.Text + ")";
        if (lblDescription7A.Text != "")
            lblDescription7A.Text = "(" + lblDescription7A.Text + ")";
        if (lblDescription8A.Text != "")
            lblDescription8A.Text = "(" + lblDescription8A.Text + ")";
    }

    void SetComments(string id)
    {
        ObjBal.Id = id;
        ds = ObjBll.getComment(ObjBal);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblHODCOMMENT.Text = ds.Tables[0].Rows[0][0].ToString();
            lblHOIComments.Text = ds.Tables[0].Rows[0][1].ToString();
        }
    }
    void BindLeave(string id)
    {
        ObjBal.Id = id;
        ds = ObjBll.getFacultyLeaveDetail(ObjBal);
        if (ds.Tables.Count > 0)
        {
            tblLvSmry.Visible = true;
            lblAvg.Text = ds.Tables[0].Rows[0][0].ToString();
            gvLeave.DataSource=ds.Tables[1];
            gvLeave.DataBind();
        }
        ds = ObjBll.GetStudentFeedback(ObjBal);
        if (ds.Tables.Count > 0)
        {
            gvStudentFead.DataSource = ds.Tables[0];
            gvStudentFead.DataBind();
        }
    }
    void BindExam(string id)
    {
        ObjBal.KeyId="2014-15";
        ObjBal.Id = id;
        ds = ObjBll.AppraisalExamPer(ObjBal);
        if (ds.Tables.Count > 0)
        {
            gvExam.DataSource = ds;
            gvExam.DataBind();
        }
    
    }
  
}