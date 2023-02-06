using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Appraisal_PA03_Home : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions queryFunctions;
    APPBLL ObjBll;
    APPBAL ObjBal;
    CommonFunctions commonFunctions;
    DataSet ds;
    string status = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialise();
        DataRow dr = ObjBll.getReviewPeriod(ObjBal).Tables[0].Rows[0];
        lblRFrom.Text = dr[0].ToString();
        lblRTo.Text = dr[1].ToString();
        lblLastDate.Text = dr[2].ToString();
        if (!IsPostBack)
        {
            ObjBal.SessionUserId = Session["UserId"].ToString();
            ObjBal.Sem = ObjBll.GetSemester(DateTime.Now.Month);
            ObjBal.Year = DateTime.Now.Year.ToString();

            status = ObjBll.GetFacultyStatus(ObjBal);
            if (status != "-1")
            {
                ViewState["ID"] = ObjBll.GetFaculty(ObjBal);

                if (ViewState["ID"].ToString() != "0")
                {
                    linkReport.NavigateUrl = "PA03.aspx?id=" + ViewState["ID"].ToString() + "&sts=" + status;
                    linkReport.Target = "_blank";
                }
                //if (status == "0")
                //{
                //    ObjBal.Id = ViewState["ID"].ToString();
                //    ObjBll.FacUpdateStatus(ObjBal);
                //}
                if (status == "2" || status == "3")
                {
                    link1.Enabled = link2.Enabled = link3.Enabled = link4.Enabled = link5.Enabled = link6.Enabled = link7.Enabled = link8.Enabled = false;
                    if (status == "2")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Your Appraisal is pending with HOD/HOI.')", true);
                    }
                    if (status == "3")
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Your Appraisal is completed.')", true);
                    }
                    btnMark.Enabled = false;
                }
            }
            else
            {
                ViewState["ID"] = ObjBll.SaveFaculty(ObjBal);
            }
            SetLabel();
            SetLinks();
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

    private void SetLabel()
    {

        ObjBll.SetHeader(APPBLL.LinkFeild.PA03_1, lblHeader1, lblDescription1);
        ObjBll.SetHeader(APPBLL.LinkFeild.PA03_2, lblHeader2, lblDescription2);
        ObjBll.SetHeader(APPBLL.LinkFeild.PA03_3, lblHeader3, lblDescription3);
        ObjBll.SetHeader(APPBLL.LinkFeild.PA03_4, lblHeader4, lblDescription4);
        ObjBll.SetHeader(APPBLL.LinkFeild.PA03_5, lblHeader5, lblDescription5);
        ObjBll.SetHeader(APPBLL.LinkFeild.PA03_6, lblHeader6, lblDescription6);
        ObjBll.SetHeader(APPBLL.LinkFeild.PA03_7, lblHeader7, lblDescription7);
        ObjBll.SetHeader(APPBLL.LinkFeild.PA03_8, lblHeader8, lblDescription8);
    }
    private void SetLinks()
    {
        ObjBll.SetLinks(APPBLL.LinkFeild.PA03_1, link1, "_top");
        ObjBll.SetLinks(APPBLL.LinkFeild.PA03_2, link2, "_top");
        ObjBll.SetLinks(APPBLL.LinkFeild.PA03_3, link3, "_top");
        ObjBll.SetLinks(APPBLL.LinkFeild.PA03_4, link4, "_top");
        ObjBll.SetLinks(APPBLL.LinkFeild.PA03_5, link5, "_top");
        ObjBll.SetLinks(APPBLL.LinkFeild.PA03_6, link6, "_top");
        ObjBll.SetLinks(APPBLL.LinkFeild.PA03_7, link7, "_top");
        ObjBll.SetLinks(APPBLL.LinkFeild.PA03_8, link8, "_top");
        //pA03.SetLinks(PA03.LinkFeild.PA03, linkReport, "_blank");
    }
    protected void btnMark_Click(object sender, EventArgs e)
    {
        ObjBal.Id = ViewState["ID"].ToString();
        string msg = ObjBll.MarkFinal(ObjBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
        link1.Enabled = link2.Enabled = link3.Enabled = link4.Enabled = link5.Enabled = link6.Enabled = link7.Enabled = link8.Enabled = false;
    }
}