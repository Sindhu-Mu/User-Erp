using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

public partial class Control_StuFullProfile : System.Web.UI.UserControl
{
    DatabaseFunctions databaseFunctions;
    AcaBLL ObjBll;
    AcaBAL ObjBal;
    DataSet ds;
    DataTable dt;
    StringBuilder Strb;
    double TotDemand, TotRcv, TotAdjust, TotBalance;
    protected void Page_Load(object sender, EventArgs e)
    {

        intialize();
        if (!IsPostBack)
            step1.ActiveTabIndex = 0;
    }
    void intialize()
    {
        databaseFunctions = new DatabaseFunctions();
        ObjBll = new AcaBLL();
        ObjBal = new AcaBAL();
        ds = new DataSet();
        dt = new DataTable();
        Strb = new StringBuilder();
    }
    void FillDetail(GridView gv, DataTable dt)
    {
        gv.DataSource = dt;
        gv.DataBind();
    }

    void InternalMarks(string StuMainId)
    {
        ObjBal.Id = StuMainId;
        Label lblHeader;
        Label lblContent;
        AjaxControlToolkit.AccordionPane pn;
        ObjBal.Id = ViewState["StuMainId"].ToString();
        ds = ObjBll.GetStudentSemInternal(ObjBal);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            lblHeader = new Label();
            lblContent = new Label();
            lblHeader.Text = "Semester:-" + ds.Tables[0].Rows[i]["ACA_SEM_NO"].ToString()
                + " Batch:-" + ds.Tables[0].Rows[i]["ACA_BATCH_NAME"].ToString()
                + " Programme:-" + ds.Tables[0].Rows[i]["Programme"].ToString();
            ds.Tables[2].DefaultView.RowFilter = "SEMESTER="
                + ds.Tables[0].Rows[i]["ACA_SEM_NO"].ToString();
            dt = ds.Tables[2].DefaultView.ToTable();
            DataRow dr = ds.Tables[1].Rows[0];
            Strb.Append("<table  border='1' style='width:100%;border-collapse: collapse;'><tr>");
            for (int a = 0; a < dr.Table.Columns.Count; a++)
            {
                Strb.Append("<th>" + dr[a].ToString() + "</th>");
            }
            Strb.Append("</tr>");


            for (int j = 0; j < dt.Rows.Count; j++)
            {
                Strb.Append("<tr><td>" + (j + 1).ToString() + ".</td>");
                for (int b = 1; b < dr.Table.Columns.Count; b++)
                {
                    Strb.Append("<td>" + dt.Rows[j][dr[b].ToString()].ToString() + "</td>");
                }

                Strb.Append("</tr>");
            }

            Strb.Append("</table>");
            lblContent.Text = Strb.ToString();
            Strb.Remove(0, Strb.Length);
            pn = new AjaxControlToolkit.AccordionPane();
            pn.ID = "pane" + i.ToString();
            pn.HeaderContainer.Controls.Add(lblHeader);
            pn.ContentContainer.Controls.Add(lblContent);
            Accordion2.Panes.Add(pn);
        }
    }


    void Examination(string StuMainId)
    {
        ObjBal.Id = StuMainId;
        Label lblHeader;
        Label lblContent;
        double MxaTotal, GainTotal, PassCredit;
        AjaxControlToolkit.AccordionPane pn;
        ds = ObjBll.GetStudentSemResult(ObjBal);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            MxaTotal = GainTotal = PassCredit = 0;
            lblHeader = new Label();
            lblContent = new Label();
            lblHeader.Text = "Semester:-" + ds.Tables[0].Rows[i]["ACA_SEM_NO"].ToString() + " Batch:-" + ds.Tables[0].Rows[i]["ACA_BATCH_NAME"].ToString() + " Programme:-" + ds.Tables[0].Rows[i]["Programme"].ToString() + "  Session:-" + ds.Tables[0].Rows[i]["SESSION_VALUE"].ToString() + " Per(%):-" + ds.Tables[0].Rows[i]["EXAM_STU_PERCENTAGE"].ToString();
            ds.Tables[1].DefaultView.RowFilter = "EXAM_STU_ID=" + ds.Tables[0].Rows[i]["EXAM_STU_ID"].ToString();
            dt = ds.Tables[1].DefaultView.ToTable();
            if (Convert.ToInt32(ds.Tables[0].Rows[0]["ACA_BATCH_ID"]) < 7)
            {
                Strb.Append("<table  border='1' style='width:100%;border-collapse: collapse;'><tr><th>S.no</th><th>Course Code</th><th>Course Title</th><th>Max.Marks</th><th>Marks Obtained</th><th>Status</th></tr>");
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    Strb.Append("<tr><td>" + (j + 1).ToString() + "</td><td>" + dt.Rows[j]["CRS_CODE"].ToString() + "</td><td>" + dt.Rows[j]["CRS_NAME"].ToString() + "</td><td>" + dt.Rows[j]["Max_Marks"] + "</td><td>" + dt.Rows[j]["Gain"].ToString() + "</td><td>" + dt.Rows[j]["CRS_RESULT_VALUE"].ToString() + "</td></tr>");
                    MxaTotal = MxaTotal + Convert.ToDouble(dt.Rows[j]["Max_Marks"]);
                    GainTotal = GainTotal + Convert.ToDouble(dt.Rows[j]["Gain"]);
                }
                Strb.Append("<tr><td></td><td></td><th>Total</th><th>" + MxaTotal.ToString() + "</th><th>" + GainTotal.ToString() + "</th><td></td></tr>");
                Strb.Append("</table>");
                lblContent.Text = Strb.ToString();
            }
            else
            {
                Strb.Append("<table  border='1' style='width:100%;border-collapse: collapse;'><tr><th>S.no</th><th>Course Code</th><th>Course Titel</th><th>Credit</th><th>Grade</th></tr>");
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    Strb.Append("<tr><td>" + (j + 1).ToString() + "</td><td>" + dt.Rows[j]["CRS_CODE"].ToString() + "</td><td>" + dt.Rows[j]["CRS_NAME"].ToString() + "</td><td>" + dt.Rows[j]["CRS_CREDIT"].ToString() + "</td><td>" + dt.Rows[j]["GRD_VALUE"].ToString() + "</td></tr>");
                    MxaTotal += Convert.ToDouble(dt.Rows[j]["CRS_CREDIT"]);
                    GainTotal += Convert.ToDouble(dt.Rows[j]["CRS_CREDIT"]) * Convert.ToDouble(dt.Rows[j]["GRD_POINT"]);
                    if (dt.Rows[j]["GRD_POINT"].ToString() != "0")
                        PassCredit += Convert.ToDouble(dt.Rows[j]["CRS_CREDIT"]);
                }
                Strb.Append("<tr><td></td><td></td><th>Total</th><th>" + PassCredit.ToString() + "/" + MxaTotal.ToString() + "</th><th>" + GainTotal.ToString() + "</th><td></td></tr>");
                Strb.Append("</table>");
                lblContent.Text = Strb.ToString();
            }
            Strb.Remove(0, Strb.Length);
            pn = new AjaxControlToolkit.AccordionPane();
            pn.ID = "pane" + i.ToString();
            pn.HeaderContainer.Controls.Add(lblHeader);
            pn.ContentContainer.Controls.Add(lblContent);
            Accordion1.Panes.Add(pn);
        }
    }
    public void StudentFullProfile(string StuMainId)
    {
        TotDemand = TotRcv = TotAdjust = TotBalance = 0;
        ViewState["StuMainId"] = StuMainId;
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "STUDENT_FULL_PROFILE_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        databaseFunctions = new DatabaseFunctions();
        cmd.Parameters.AddWithValue("@STU_MAIN_ID", StuMainId);
        DataSet ds = databaseFunctions.GetDataSet(cmd);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblName.Text = ds.Tables[0].Rows[0]["STU_FULL_NAME"].ToString();

            lblEnrollment.Text = ds.Tables[0].Rows[0]["ENROLLMENT_NO"].ToString();
            lblAddress.Text = ds.Tables[0].Rows[0]["ADD_1"].ToString() + ' ' + ds.Tables[0].Rows[0]["ADD_2"].ToString() + ' ' + ds.Tables[0].Rows[0]["CIT_VALUE"].ToString();
            lblBatch.Text = ds.Tables[0].Rows[0]["ACA_BATCH_NAME"].ToString();
            //if (lblBatch.Text == "2015")
            //{
            //    imgPicture.Src = "../images/Stuimages/2015/" + ds.Tables[0].Rows[0]["FORM_NO"].ToString() + ".jpg";
            //}
            //else
            //{
            //    imgPicture.Src = "../images/Stuimages/" + ds.Tables[0].Rows[0]["ENROLLMENT_NO"].ToString() + ".jpg";
            //}
            imgPicture.Src = "../images/Stuimages/" + ds.Tables[0].Rows[0]["ENROLLMENT_NO"].ToString() + ".jpg";
            lblBranch.Text = ds.Tables[0].Rows[0]["BRN_SHORT_NAME"].ToString();
            lblCourse.Text = ds.Tables[0].Rows[0]["PGM_SHORT_NAME"].ToString();
            lblDob.Text = ds.Tables[0].Rows[0]["DT_OF_BIRTH"].ToString();
            lblEmail.Text = ds.Tables[0].Rows[0]["EMAIL"].ToString();
            lblFatherName.Text = ds.Tables[0].Rows[0]["FATHER_NAME"].ToString();
            lblMotherName.Text = ds.Tables[0].Rows[0]["MOTHER_NAME"].ToString();
            lblInstitute.Text = ds.Tables[0].Rows[0]["INS_VALUE"].ToString();
            lblSem.Text = ds.Tables[0].Rows[0]["ACA_SEM_ID"].ToString();
            lblSection.Text = ds.Tables[0].Rows[0]["ACA_SEC_NAME"].ToString();
            lblStatus.Text = ds.Tables[0].Rows[0]["STU_STS_VALUE"].ToString();
            lblParMobile.Text = ds.Tables[0].Rows[0]["PAR_PHN_NO"].ToString();
            lblSex.Text = ds.Tables[0].Rows[0]["GEN_VALUE"].ToString();
            lblBlood.Text = ds.Tables[0].Rows[0]["BLO_GRP_VALUE"].ToString();
            lblAdmType.Text = ds.Tables[0].Rows[0]["ADM_TYPE_VALUE"].ToString();
            lblCaste.Text = ds.Tables[0].Rows[0]["CAS_VALUE"].ToString();
            lblAdmRegNo.Text = ds.Tables[0].Rows[0]["ADM_REG_NO"].ToString();
            lblNationality.Text = ds.Tables[0].Rows[0]["NAT_VALUE"].ToString();
            lblCategory.Text = ds.Tables[0].Rows[0]["ENT_EXAM_SHORT_NAME"].ToString();
            lblAdmDT.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["STU_ENROLL_DT"]).ToString("dd-MMM-yyyy");
            lblQuota.Text = ds.Tables[0].Rows[0]["QUOTA_NAME"].ToString();
            lblRank.Text = ds.Tables[0].Rows[0]["STU_TEST_RANK"].ToString();
            lblFormNo.Text = ds.Tables[0].Rows[0]["FORM_NO"].ToString();
            lblCAdd1.Text = ds.Tables[0].Rows[0]["ADD_1"].ToString();
            lblCAdd2.Text = ds.Tables[0].Rows[0]["ADD_2"].ToString();
            lblCity.Text = ds.Tables[0].Rows[0]["CIT_VALUE"].ToString();
            lblState.Text = ds.Tables[0].Rows[0]["STA_VALUE"].ToString();
            lblPState.Text = ds.Tables[0].Rows[0]["STA_VALUE"].ToString();
            lblPSTD.Text = ds.Tables[0].Rows[0]["CIT_STD_CODE"].ToString();
            lblPMobile.Text = ds.Tables[0].Rows[0]["PAR_PHN_NO"].ToString();
            lblPEMAIL.Text = ds.Tables[0].Rows[0]["PERSONAL_EMAIL"].ToString();
        }
        if (ds.Tables[1].Rows.Count > 0)
        {
            lblSTD.Text = ds.Tables[1].Rows[0]["CIT_STD_CODE"].ToString();
            lblPADD1.Text = ds.Tables[1].Rows[0]["ADD_1"].ToString();
            lblPADD2.Text = ds.Tables[1].Rows[0]["ADD_2"].ToString();
            lblPCity.Text = ds.Tables[1].Rows[0]["CIT_VALUE"].ToString();
            lblState.Text = ds.Tables[1].Rows[0]["STA_VALUE"].ToString();
            lblMobile.Text = ds.Tables[1].Rows[0]["PHN_NO"].ToString();
            lblMobile1.Text = ds.Tables[1].Rows[0]["PHN_NO"].ToString();
            lblEmail1.Text = ds.Tables[1].Rows[0]["EMAIL"].ToString();
        }
        if (ds.Tables[2].Rows.Count > 0)
        {
            lblRoom.Text = ds.Tables[2].Rows[0]["ROOM_NO"].ToString();
            lblHostel.Text = ds.Tables[2].Rows[0]["FAC_CMPLX_NAME"].ToString();
        }
        else
        {
            lblHostel.Text = "N/A";
            lblRoom.Text = "N/A";
        }
        FillDetail(gvQualification, ds.Tables[3]);
        FillDetail(gvAttendance, ds.Tables[4]);
        FillDetail(gvRegistration, ds.Tables[5]);
        //FillDetail(gvInternalMarks, ds.Tables[6]);
        if (ds.Tables[7].Rows.Count > 0)
        {
            FillDetail(gvFees, ds.Tables[7]);
            foreach (GridViewRow itm in gvFees.Rows)
            {
                TotDemand += Convert.ToDouble(ds.Tables[7].Rows[itm.RowIndex]["FD_FEE_AMT"]);
                TotAdjust += Convert.ToDouble(ds.Tables[7].Rows[itm.RowIndex]["FD_ADJUST_AMT"]);
                TotRcv += Convert.ToDouble(ds.Tables[7].Rows[itm.RowIndex]["FD_RCV_AMT"]);
                TotBalance += Convert.ToDouble(ds.Tables[7].Rows[itm.RowIndex]["FD_BALANCE_AMT"]);
            }
            if (gvFees.Rows.Count > 0)
            {
                gvFees.FooterRow.Cells[2].Text = TotDemand.ToString("N2");
                gvFees.FooterRow.Cells[3].Text = TotAdjust.ToString("N2");
                gvFees.FooterRow.Cells[4].Text = TotRcv.ToString("N2");
                gvFees.FooterRow.Cells[5].Text = TotBalance.ToString("N2");

            }
        }

    }



    protected void step1_ActiveTabChanged1(object sender, EventArgs e)
    {
        if (step1.ActiveTabIndex == 3)
        {
            Examination(ViewState["StuMainId"].ToString());
        }
        if (step1.ActiveTabIndex == 4)
        {
            InternalMarks(ViewState["StuMainId"].ToString());
        }
    }
}