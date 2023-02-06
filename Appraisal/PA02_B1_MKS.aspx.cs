using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
public partial class Appraisal_PA02_B1 : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions queryFunctions;
    APPBLL ObjBll;
    APPBAL ObjBal;
    CommonFunctions commonFunctions;
    DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Id"] == null || Session["Id"].ToString() == "") Response.Redirect("PA02_B1_STY.aspx");
        Initialise();
        if (!IsPostBack)
        {
            try
            {
                ViewState["ID"] = "";
                PushData(Session["id"].ToString(), Session["Date"].ToString());
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Invalid Enrollment number. Enter a valid no. and continue')", true);
                Response.Redirect("PA02_B1_STY.aspx");
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
    private void PushData(string Enrollment_No, string Date)
    {
       ds=ObjBll.GetParameters();
       GridCurriculum.DataSource = ds.Tables[0];
       GridCurriculum.DataBind();
        gvParameter.DataSource =ds.Tables[1];
        gvParameter.DataBind();
        ViewState["ID"] = ObjBal.Id = Enrollment_No;
        ObjBal.FromDate = Date;
        ds = ObjBll.PA02_B1_GET_EMP(ObjBal);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvTeacher.DataSource = ds.Tables[0];
            gvTeacher.DataBind();
            gvTeacher.SelectedIndex = 0;
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Invalid Enrollment number. Enter a valid no. and continue')", true);
            Response.Redirect("PA02_B1_STY.aspx");
        }


    }

    void Clear()
    {
        if ((gvTeacher.Rows.Count - 1) > gvTeacher.SelectedIndex)
        {
            gvTeacher.SelectedIndex = gvTeacher.SelectedIndex + 1;
            foreach (GridViewRow row in GridCurriculum.Rows)
            {
                DropDownList ddlMarks = (DropDownList)row.FindControl("ddlMarks");
                ddlMarks.SelectedIndex = 0;
            }
            foreach (GridViewRow row in gvParameter.Rows)
            {
                DropDownList ddlMarks = (DropDownList)row.FindControl("ddlMarks");
                ddlMarks.SelectedIndex = 0;
            }
            btnSave.Text="Submit and move to next course faculty";
            if ((gvTeacher.Rows.Count - 1) == gvTeacher.SelectedIndex)
                btnSave.Text = "Final Submit";
            //gvTeacher.Rows[gvTeacher.SelectedIndex].BackColor = System.Drawing.Color.YellowGreen;
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('All Papers Covered.')", true);
            //Response.Redirect("..//FeedBack/Facility_Survey.aspx?id=" + ViewState["ID"]);
            Response.Redirect("PA02_B1_STY.aspx?=1");
        }
        TextBox1.Text = "";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridCurriculum.Rows)
        {
            DropDownList ddlMarks = (DropDownList)row.FindControl("ddlMarks");
            if (ddlMarks.SelectedValue == "-1" || ddlMarks.SelectedValue == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Select valid marks!!')", true);
                return;
            }
        }
        foreach (GridViewRow row in gvParameter.Rows)
        {
            DropDownList ddlMarks = (DropDownList)row.FindControl("ddlMarks");
            if (ddlMarks.SelectedValue == "-1" || ddlMarks.SelectedValue == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Select valid marks!!')", true);
                return;
            }
        }
        XmlDocument xmlData = new XmlDocument();
        XmlElement ROOT;
        if (TextBox1.Text != "")
        {
            xmlData.LoadXml(TextBox1.Text);
            ROOT = xmlData.DocumentElement;
        }
        else
        {
            ROOT = xmlData.CreateElement("PA02_B1");
            xmlData.AppendChild(ROOT);
        }
        foreach (GridViewRow row in GridCurriculum.Rows)
        {
            XmlElement dataElement = xmlData.CreateElement("StuData");
            ROOT.AppendChild(dataElement);

            XmlElement element = xmlData.CreateElement("PA02_B1_PARAM_ID");
            element.InnerText = GridCurriculum.DataKeys[row.RowIndex].Value.ToString();
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("MKS_OBT");
            element.InnerText = ((DropDownList)GridCurriculum.Rows[row.RowIndex].FindControl("ddlMarks")).SelectedValue;
            dataElement.AppendChild(element);

        }



        foreach (GridViewRow row in gvParameter.Rows)
        {
            XmlElement dataElement = xmlData.CreateElement("StuData");
            ROOT.AppendChild(dataElement);

            XmlElement element = xmlData.CreateElement("PA02_B1_PARAM_ID");
            element.InnerText = gvParameter.Rows[row.RowIndex].Cells[0].Text;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("MKS_OBT");
            element.InnerText = ((DropDownList)gvParameter.Rows[row.RowIndex].FindControl("ddlMarks")).SelectedValue;
            dataElement.AppendChild(element);

        }

        TextBox1.Text = xmlData.OuterXml;
        ObjBal.Xml = TextBox1.Text;
        ObjBal.Usr_id = gvTeacher.DataKeys[gvTeacher.SelectedIndex].Values["USR_ID"].ToString();
        ObjBal.PaperCode = gvTeacher.DataKeys[gvTeacher.SelectedIndex].Values["BS_MAPP_CODE"].ToString();
        ObjBal.PaperName = gvTeacher.DataKeys[gvTeacher.SelectedIndex].Values["TT_PAP_ID"].ToString();
        ObjBal.Enrollment = ViewState["ID"].ToString();
        ObjBal.Sem = "0";
        string msg = ObjBll.SaveMarks(ObjBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);

        Clear();
    }
        

}