using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
public partial class HR_ShortlistApplicant : System.Web.UI.Page
{
    FillFunctions FillFunction = new FillFunctions();
    QueryFunctions QueryFunction;
    CommonFunctions common;
    HRBLL ObjHrBll;
    HRBAL ObjHrBAL;
    CommonFunctions commonFunctions;
    DataSet ds;
    
    public void Initialize()
    {
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        common = new CommonFunctions();
        ObjHrBll = new HRBLL();
        ObjHrBAL = new HRBAL();
        commonFunctions = new CommonFunctions();
        ds = new DataSet();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        this.MaintainScrollPositionOnPostBack = true;
        Initialize();

        if (!IsPostBack)
        {
            FillFunction.Fill(ddlJob, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.JobNo), true, FillFunctions.FirstItem.Select);
            ViewState["ds"] = "";
        }
    }
    protected void ddlJob_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlJob.SelectedIndex > 0)
        {
            bindGrid();
            trDetails.Visible = true;
        }
        else
            trDetails.Visible = false;
    }
    void bindGrid()
    {
        ObjHrBAL.KeyID = ddlJob.SelectedValue;
        ViewState["ds"] = ds = ObjHrBll.getJobAppDetails(ObjHrBAL);
        gvDetail.DataSource = ds.Tables[0];
        gvDetail.DataBind();
        gvApplicant.DataSource = ds.Tables[1];
        gvApplicant.DataBind();
        foreach (GridViewRow row in gvApplicant.Rows)
        {
            if (Convert.ToInt32(ds.Tables[0].Rows[0]["ACA_BASE_PRP"].ToString()) > Convert.ToInt32(gvApplicant.DataKeys[row.RowIndex].Values[2].ToString()))
            {
                gvApplicant.Rows[row.RowIndex].Cells[2].BackColor = System.Drawing.Color.Red;
                gvApplicant.Rows[row.RowIndex].Cells[2].ToolTip = "Qualification is less than expected";
            }
            if (Convert.ToInt32(ds.Tables[0].Rows[0]["MAX_SALARY"].ToString()) < Convert.ToInt32(gvApplicant.Rows[row.RowIndex].Cells[6].Text))
            {
                gvApplicant.Rows[row.RowIndex].Cells[6].BackColor = System.Drawing.Color.Orange;
                gvApplicant.Rows[row.RowIndex].Cells[6].ToolTip = "Expected Salary is more than salary offered for this job";
            }
        }
        trOldApplicants.Visible = false;
    }
    protected void gvApplicant_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ObjHrBAL.HeadID = gvApplicant.DataKeys[Convert.ToInt16(e.CommandArgument)].Values[0].ToString();
        gvExperience.DataSource = ObjHrBll.getJobAppDetails(ObjHrBAL).Tables[2];
        gvExperience.DataBind();
        ModalPopupExtender1.Show();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        XmlDocument xmlData = new XmlDocument();
        XmlElement ROOT;
        if (TextBox1.Text != "")
        {
            xmlData.LoadXml(TextBox1.Text);
            ROOT = xmlData.DocumentElement;
        }
        else
        {
            ROOT = xmlData.CreateElement("JOB");
            xmlData.AppendChild(ROOT);
        }

        foreach (GridViewRow row in gvApplicant.Rows)
        {

            CheckBox chk = (CheckBox)row.FindControl("CHK_SelectAll");
            if (chk.Checked == true)
            {

                XmlElement dataElement = xmlData.CreateElement("DATA");
                ROOT.AppendChild(dataElement);

                XmlElement element = xmlData.CreateElement("INT_CAN_ID");
                element.InnerText = gvApplicant.DataKeys[row.RowIndex].Values[0].ToString();
                dataElement.AppendChild(element);

                element = xmlData.CreateElement("MAP_ID");
                element.InnerText = gvApplicant.DataKeys[row.RowIndex].Values[1].ToString();
                dataElement.AppendChild(element);
            }
           
        }

        foreach (GridViewRow row in gvOldApplicants.Rows)
        {

            CheckBox chk = (CheckBox)row.FindControl("CHK_SelectAll");
            if (chk.Checked == true)
            {

                XmlElement dataElement = xmlData.CreateElement("DATA");
                ROOT.AppendChild(dataElement);

                XmlElement element = xmlData.CreateElement("INT_CAN_ID");
                element.InnerText = gvOldApplicants.DataKeys[row.RowIndex].Values[0].ToString();
                dataElement.AppendChild(element);

                element = xmlData.CreateElement("MAP_ID");
                ObjHrBAL.HeadID = gvOldApplicants.DataKeys[row.RowIndex].Values[0].ToString();
                ObjHrBAL.JobId = gvDetail.DataKeys[0].Values[0].ToString();
                element.InnerText = ObjHrBll.getMapId(ObjHrBAL);
                dataElement.AppendChild(element);
            }
           
        }
        TextBox1.Text = xmlData.OuterXml;
        ObjHrBAL.XmlData = TextBox1.Text;
        ObjHrBAL.RemValue = txtRemark.Text;
        ObjHrBAL.SessionUserID = Session["UserId"].ToString();
        string msg = ObjHrBll.ShortlistApplicant(ObjHrBAL);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('" + msg + "')", true);
        bindGrid();
       

    }
    protected void btnSelect_Click(object sender, EventArgs e)
    {
        ObjHrBAL.KeyID = ddlJob.SelectedValue;
        ds = (DataSet)ViewState["ds"];
        gvOldApplicants.DataSource = ObjHrBll.getOldAppDetails(ObjHrBAL).Tables[0];
        gvOldApplicants.DataBind();
        foreach (GridViewRow row in gvOldApplicants.Rows)
        {
            //if (Convert.ToInt32(ds.Tables[0].Rows[0]["ACA_BASE_PRP"].ToString()) > Convert.ToInt32(gvOldApplicants.DataKeys[row.RowIndex].Values[2].ToString()))
            //{
            //    gvOldApplicants.Rows[row.RowIndex].Cells[2].BackColor = System.Drawing.Color.Red;
            //    gvOldApplicants.Rows[row.RowIndex].Cells[2].ToolTip = "Qualification is less than expected";
            //}
            if (Convert.ToInt32(ds.Tables[0].Rows[0]["MAX_SALARY"].ToString()) < Convert.ToInt32(gvOldApplicants.Rows[row.RowIndex].Cells[6].Text))
            {
                gvOldApplicants.Rows[row.RowIndex].Cells[6].BackColor = System.Drawing.Color.Orange;
                gvOldApplicants.Rows[row.RowIndex].Cells[6].ToolTip = "Expected Salary is more than salary offered for this job";
            }
        }
        trOldApplicants.Visible = true;
    }
    protected void gvOldApplicants_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ObjHrBAL.HeadID = gvApplicant.DataKeys[Convert.ToInt16(e.CommandArgument)].Values[0].ToString();
        gvExperience.DataSource = ObjHrBll.getOldAppDetails(ObjHrBAL).Tables[1];
        gvExperience.DataBind();
        ModalPopupExtender1.Show();
    }
}