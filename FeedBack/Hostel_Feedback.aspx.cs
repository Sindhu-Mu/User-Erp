using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Xml;
using System.Data;
public partial class FeedBack_Hostel_Feedback : System.Web.UI.Page
{
    DatabaseFunctions databaseFunction;
    FillFunctions fillFunction;
    FEEBLL Objbll;
    FEEBAL Objbal;
    DataTable dt;
    void initialise()
    {
        dt = new DataTable();
        databaseFunction = new DatabaseFunctions();
        fillFunction = new FillFunctions();
        Objbll = new FEEBLL();
        Objbal = new FEEBAL();
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        initialise();



        if (!IsPostBack)
        {
            PushData();

        }

        Objbal.Stu_AdmNo = Session["UserId"].ToString();
        dt = Objbll.FEED_REG_OPEN(Objbal).Tables[1];
        string a = dt.Rows[0]["GEN_FAC"].ToString();
        if (a == "1")
        {
            lblMsg.Text = "Aready Submitted";
            TR1.Visible = false;
            TR2.Visible = false;
        }
        else
        {
            TR1.Visible = true;
        }
    }

    public void PushData()
    {

        DataSet Ds = Objbll.FeedQuesSelect(Objbal);

        gvHostel.DataSource = Ds.Tables[7];
        gvHostel.DataBind();

        gvMess.DataSource = Ds.Tables[8];
        gvMess.DataBind();

        gvMedical.DataSource = Ds.Tables[9];
        gvMedical.DataBind();



    }

    public void clear()
    {

        gvHostel.DataSource = "";
        gvHostel.DataBind();
        gvMedical.DataSource = "";
        gvMedical.DataBind();
        gvMess.DataSource = "";
        gvMess.DataBind();
        txtsugg.Text = "";
        TR1.Visible = false;
        TR2.Visible = false;
    }

    protected void txtSave_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow row in gvHostel.Rows)
            {

                DropDownList ddlHostel = (DropDownList)row.FindControl("ddlHostel");
                if (ddlHostel.SelectedValue == "-1" || ddlHostel.SelectedValue == "")
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
                ROOT = xmlData.CreateElement("MARKS");
                xmlData.AppendChild(ROOT);
            }

            foreach (GridViewRow row in gvHostel.Rows)
            {
                DropDownList ddlHostel = (DropDownList)row.FindControl("ddlHostel");
                XmlElement dataElement = xmlData.CreateElement("StuData");
                ROOT.AppendChild(dataElement);

                XmlElement element = xmlData.CreateElement("QUES_ID");
                element.InnerText = gvHostel.DataKeys[row.RowIndex].Value.ToString();
                dataElement.AppendChild(element);

                element = xmlData.CreateElement("MKS_OBT");
                DropDownList ddlHostel1 = (DropDownList)row.FindControl("ddlHostel");
                element.InnerText = ddlHostel1.SelectedValue;
                dataElement.AppendChild(element);

            }
            XmlDocument xmlData1 = new XmlDocument();
            XmlElement ROOT1;
            if (TextBox2.Text != "")
            {
                xmlData1.LoadXml(TextBox2.Text);
                ROOT1 = xmlData1.DocumentElement;
            }
            else
            {
                ROOT1 = xmlData1.CreateElement("MARKS");
                xmlData1.AppendChild(ROOT1);
            }


            foreach (GridViewRow row in gvMess.Rows)
            {
                DropDownList ddlMess = (DropDownList)row.FindControl("ddlMess");
                if (ddlMess.SelectedValue == "-1" || ddlMess.SelectedValue == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Select valid marks!!')", true);
                    return;
                }

                XmlElement dataElement = xmlData1.CreateElement("StuData");
                ROOT1.AppendChild(dataElement);

                XmlElement element = xmlData1.CreateElement("QUES_ID");
                element.InnerText = gvMess.DataKeys[row.RowIndex].Value.ToString();
                dataElement.AppendChild(element);

                element = xmlData1.CreateElement("MKS_OBT");
                DropDownList ddlMess1 = (DropDownList)row.FindControl("ddlMess");
                element.InnerText = ddlMess1.SelectedValue;
                dataElement.AppendChild(element);

            }
            XmlDocument xmlData2 = new XmlDocument();
            XmlElement ROOT2;
            if (TextBox3.Text != "")
            {
                xmlData2.LoadXml(TextBox3.Text);
                ROOT2 = xmlData2.DocumentElement;
            }
            else
            {
                ROOT2 = xmlData2.CreateElement("MARKS");
                xmlData2.AppendChild(ROOT2);
            }


            foreach (GridViewRow row in gvMedical.Rows)
            {
                DropDownList ddlMedical = (DropDownList)row.FindControl("ddlMedical");
                if (ddlMedical.SelectedValue == "-1" || ddlMedical.SelectedValue == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Select valid marks!!')", true);
                    return;
                }

                XmlElement dataElement = xmlData2.CreateElement("StuData");
                ROOT2.AppendChild(dataElement);

                XmlElement element = xmlData2.CreateElement("QUES_ID");
                element.InnerText = gvMedical.DataKeys[row.RowIndex].Value.ToString();
                dataElement.AppendChild(element);

                element = xmlData2.CreateElement("MKS_OBT");
                DropDownList ddlMedical1 = (DropDownList)row.FindControl("ddlMedical");
                element.InnerText = ddlMedical1.SelectedValue;
                dataElement.AppendChild(element);

            }


            TextBox1.Text = xmlData.OuterXml;
            Objbal.XmlValue = TextBox1.Text;
            Objbal.Stu_AdmNo = Session["UserId"].ToString();
            Objbll.FeedFacMarksInsert(Objbal);
            TextBox2.Text = xmlData1.OuterXml;
            Objbal.XmlValue = TextBox2.Text;
            Objbal.Stu_AdmNo = Session["UserId"].ToString();
            Objbll.FeedFacMarksInsert(Objbal);
            TextBox3.Text = xmlData2.OuterXml;
            Objbal.XmlValue = TextBox3.Text;
            Objbal.Stu_AdmNo = Session["UserId"].ToString();
            Objbll.FeedFacMarksInsert(Objbal);
            Objbal.Stu_AdmNo = Session["UserId"].ToString();
            Objbal.Description = txtsugg.Text;
            Objbll.HostFeedRmkInsert(Objbal);
                  
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('THANKS!! For completing your feedback.')", true);
            clear();
            txtSave.Visible = false;

        }

        catch
        {

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('You have already Submitted..')", true);
        }


    }
}
