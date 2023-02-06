using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.Data.SqlClient;

public partial class Finance_BankAccount : System.Web.UI.Page
{
    QueryFunctions glb_qf;
    FillFunctions glb_ff;
    SFBAL balObj;
    SFBLL bllObj;
    DataTable dt;
    DataSet ds;
    CommonFunctions cf;
    double First, Second, Third, Fourth, Fifth, Sixth;
    protected void Page_Load(object sender, EventArgs e)
    {

        Initialize();
        btnSave.Attributes.Add("OnClick", "return validation()");
        Initialize();

        if (!IsPostBack)
        {
            glb_ff.Fill(ddlBatch, glb_qf.GetCommand(QueryFunctions.QueryBaseType.Batch), true, FillFunctions.FirstItem.Select);
            glb_ff.Fill(ddlInstitute, glb_qf.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
            ViewState["Edit"] = "1";
            ddlBatch.Focus();
        }


    }
    protected void ddlInstitute_SelectedIndexChanged(object sender, EventArgs e)
    {
        glb_ff.Fill(ddlCourse, glb_qf.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlInstitute.SelectedValue), true, FillFunctions.FirstItem.Select);

    }
    protected void Initialize()
    {
        glb_qf = new QueryFunctions();
        glb_ff = new FillFunctions();
        balObj = new SFBAL();
        bllObj = new SFBLL();
        dt = new DataTable();
        cf = new CommonFunctions();
        ds = new DataSet();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        balObj.balCourseId = ddlCourse.SelectedValue;
        ds = bllObj.FeeStrcforHead(balObj);
        gvFeeStrac.DataSource = ds.Tables[0];
        gvFeeStrac.DataBind();
        ViewState["COURSEYEAR"] = ds.Tables[0].Rows[0][0].ToString();
    }
    void Add()
    {
        TextBox txtAmount = null;
        RadioButtonList RListType = null;
        XmlDocument xmlData = new XmlDocument();
        XmlElement ROOT;
        if (txtData.Text != "")
        {
            xmlData.LoadXml(txtData.Text);
            ROOT = xmlData.DocumentElement;
        }
        else
        {
            ROOT = xmlData.CreateElement("FEE");
            xmlData.AppendChild(ROOT);
        }
        foreach (GridViewRow row in gvFeeStrac.Rows)
        {
            RListType = (RadioButtonList)row.FindControl("RListType");
            for (int i = 1; i <= 6; i++)
            {
                txtAmount = (TextBox)row.FindControl("txt" + i.ToString());
                if (Convert.ToDouble(txtAmount.Text) > 0)
                {
                    XmlElement dataElement = xmlData.CreateElement("DATA");
                    ROOT.AppendChild(dataElement);

                    XmlElement element = xmlData.CreateElement("FEE_MAIN_HEAD_ID");
                    element.InnerText = gvFeeStrac.DataKeys[row.RowIndex].Value.ToString();
                    dataElement.AppendChild(element);

                    element = xmlData.CreateElement("FEE_FOR_YEAR");
                    element.InnerText = i.ToString();
                    dataElement.AppendChild(element);

                    element = xmlData.CreateElement("FEE_IS_YEARLY");
                    element.InnerText = RListType.SelectedValue;
                    dataElement.AppendChild(element);

                    element = xmlData.CreateElement("FEE_HEAD_AMT");
                    element.InnerText = txtAmount.Text;
                    dataElement.AppendChild(element);
                }
            }
        }
        txtAmount.Dispose();
        RListType.Dispose();
        txtData.Text = xmlData.OuterXml;
    }
    protected void btnCalculat_Click(object sender, EventArgs e)
    {
        TextBox txtAmount = null;
        foreach (GridViewRow row in gvFeeStrac.Rows)
        {
            for (int i = 1; i <= 6; i++)
            {
                txtAmount = (TextBox)row.FindControl("txt" + i.ToString());
                txtAmount.Text = (txtAmount.Text != "") ? txtAmount.Text : "0";
                Convert.ToDouble(txtAmount.Text);
                switch (i)
                {
                    case 1:
                        First += Convert.ToDouble(txtAmount.Text);
                        break;
                    case 2:
                        Second += Convert.ToDouble(txtAmount.Text);
                        break;
                    case 3:
                        Third += Convert.ToDouble(txtAmount.Text);
                        break;
                    case 4:
                        Fourth += Convert.ToDouble(txtAmount.Text);
                        break;
                    case 5:
                        Fifth += Convert.ToDouble(txtAmount.Text);
                        break;
                    case 6:
                        Sixth += Convert.ToDouble(txtAmount.Text);
                        break;
                }
            }
        }
        if (gvFeeStrac.Rows.Count > 0)
        {
            gvFeeStrac.FooterRow.Cells[3].Text = First.ToString("N2");
            gvFeeStrac.FooterRow.Cells[4].Text = Second.ToString("N2");
            gvFeeStrac.FooterRow.Cells[5].Text = Third.ToString("N2");
            gvFeeStrac.FooterRow.Cells[6].Text = Fourth.ToString("N2");
            gvFeeStrac.FooterRow.Cells[7].Text = Fifth.ToString("N2");
            gvFeeStrac.FooterRow.Cells[8].Text = Sixth.ToString("N2");
        }
        Add();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            balObj.balCourseId = ddlCourse.SelectedValue;
            balObj.balBatchId = ddlBatch.SelectedValue;
            balObj.balCurUser = Session["UserId"].ToString();
            balObj.balData = txtData.Text;
            balObj.balCommonID = ddladmType.SelectedValue;
            bllObj.FeeStrcInsert(balObj);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Fees structure for selected course inserted.')", true);
            txtData.Text = "";
            ddlCourse.SelectedIndex = 0;
            gvFeeStrac.DataSource = "";
            gvFeeStrac.DataBind();
        }
        catch (SqlException k)
        {
            if (k.ErrorCode.ToString() == "-2146232060")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Selected fee head already existed in this structure.')", true);
                ddlCourse.Focus();
                return;
            }
        }
    }






}