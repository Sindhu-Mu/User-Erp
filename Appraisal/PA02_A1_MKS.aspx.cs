using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;

public partial class Appraisal_PA02_A1_MKS : System.Web.UI.Page
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
                PushData();
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
    private void PushData()
    {
        gvParameter.DataSource = ObjBll.PA02_A1_GetParameters().Tables[0];
        gvParameter.DataBind();
    }

    void Clear()
    {
        //if ((gvTeacher.Rows.Count - 1) > gvTeacher.SelectedIndex)
        //{
        //    gvTeacher.SelectedIndex = gvTeacher.SelectedIndex + 1;
        //    foreach (GridViewRow row in gvParameter.Rows)
        //    {
        //        DropDownList ddlMarks = (DropDownList)row.FindControl("ddlMarks");
        //        ddlMarks.SelectedIndex = 0;
        //    }
        //    //gvTeacher.Rows[gvTeacher.SelectedIndex].BackColor = System.Drawing.Color.YellowGreen;
        //}

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
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
        TextBox1.Text = "";
        ROOT = xmlData.CreateElement("PA02_A1");
        xmlData.AppendChild(ROOT);
        foreach (GridViewRow row in gvParameter.Rows)
        {
            XmlElement dataElement = xmlData.CreateElement("StuData");
            ROOT.AppendChild(dataElement);

            XmlElement element = xmlData.CreateElement("PA02_E_PARAM_ID");
            element.InnerText = gvParameter.Rows[row.RowIndex].Cells[0].Text;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("MKS_OBT");
            element.InnerText = ((DropDownList)gvParameter.Rows[row.RowIndex].FindControl("ddlMarks")).SelectedValue;
            dataElement.AppendChild(element);

        }
        TextBox1.Text = xmlData.OuterXml;
        ObjBal.Xml = TextBox1.Text;
        ObjBal.Enrollment = Session["id"].ToString();
        ObjBal.Year = "2021";
        ObjBal.Sem = "1";
        string msg = ObjBll.PA02_A1_SaveMarks(ObjBal);
        if (msg.Contains("successfully"))
        {
            Clear();
            Response.Redirect("PA02_B1_MKS.aspx");
        }
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);

    }


}