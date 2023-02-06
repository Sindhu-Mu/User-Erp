using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

public partial class FeedBack_Facility_Survey : System.Web.UI.Page
{
    DataTable dt;
    DatabaseFunctions databaseFunction;
    FillFunctions fillFunction;
    FEEBLL Objbll;
    FEEBAL Objbal;


    void initialise()
    {
        databaseFunction = new DatabaseFunctions();
        fillFunction = new FillFunctions();
        Objbll = new FEEBLL();
        Objbal = new FEEBAL();
        dt = new DataTable();

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        initialise();
        
        //Objbal.balStuAdmNo = Session["UserId"].ToString();
        //string a = Objbll.FEED_REG_OPEN(Objbal);
        //if (a == "1")
        //{

            if (!IsPostBack)
            {
                PushData();

          }
        //}
        //else if (a == "2")
        //{ 
        //lblMsg.Text="YOU HAVE ALREADY SUBMITTED THE FEEDBACK. THANKS!!";
        //}
        //else
        //{
        //    TR1.Visible = false;
        //    lblMsg.Text = a;


        //}
            ViewState["id"] = Request.QueryString["id"].ToString();
            Objbal.Stu_AdmNo = ViewState["id"].ToString();
            dt = Objbll.FEED_REG_OPEN(Objbal).Tables[0];
            string a = dt.Rows[0]["GEN_FAC"].ToString();
            if (a == "1")
            {
                lblMsg.Text = "Already Submitted";
                TR1.Visible = false;
               
            }
            else if (a == "3")
            {
                lblMsg.Text = "Feedback Slot is not Opened for Current Semseter.";
                TR1.Visible = false;
            }
            else
            {
                TR1.Visible = true;
            }

    }
        public void PushData()
        {
       
       DataSet Ds = Objbll.FeedQuesSelect(Objbal);

       gvParameter.DataSource = Ds.Tables[1];
       gvParameter.DataBind();
        

        gvSports.DataSource = Ds.Tables[2];
        gvSports.DataBind();

        gvInfra.DataSource = Ds.Tables[3];
        gvInfra.DataBind();

        gvSecurity.DataSource = Ds.Tables[4];
        gvSecurity.DataBind();

        gvCafe.DataSource = Ds.Tables[5];
        gvCafe.DataBind();

        }

        public void clear()
        {

            gvParameter.DataSource = gvSecurity.DataSource = gvSports.DataSource = gvInfra.DataSource = gvCafe.DataSource = "";
            gvParameter.DataBind();
            gvSecurity.DataBind();
            gvSports.DataBind();
            gvInfra.DataBind();
            gvCafe.DataBind();
        
        }

    protected void btnAdd_Click(object sender, EventArgs e)
   
    {
       foreach (GridViewRow row in gvParameter.Rows)
       {

           DropDownList ddlParamMarks = (DropDownList)row.FindControl("ddlParamMarks");
           if (ddlParamMarks.SelectedValue == "-1" || ddlParamMarks.SelectedValue == "")
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

        foreach (GridViewRow row in gvParameter.Rows)
        {
            DropDownList ddlParamMarks = (DropDownList)row.FindControl("ddlParamMarks");

            XmlElement dataElement = xmlData.CreateElement("StuData");
            ROOT.AppendChild(dataElement);

            XmlElement element = xmlData.CreateElement("QUES_ID");
            element.InnerText = gvParameter.Rows[row.RowIndex].Cells[0].Text;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("MKS_OBT");
            DropDownList ddlParamMarks1 = (DropDownList)row.FindControl("ddlParamMarks");
            element.InnerText = ddlParamMarks1.SelectedValue;
            dataElement.AppendChild(element);

        }
        //TextBox1.Text = xmlData.OuterXml;
        //Objbal.Xml = TextBox1.Text;
        //Objbal.balStuAdmNo = Session["UserId"].ToString();
        //Objbll.FeedFacMarksInsert(Objbal);


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


        foreach (GridViewRow row in gvSports.Rows)
        {
            DropDownList ddlSportMarks1 = (DropDownList)row.FindControl("ddlSportMarks");
           if (ddlSportMarks1.SelectedValue == "-1" || ddlSportMarks1.SelectedValue == "")
           {
               ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Select valid marks!!')", true);
               return;
           }

            XmlElement dataElement = xmlData1.CreateElement("StuData");
            ROOT1.AppendChild(dataElement);

            XmlElement element = xmlData1.CreateElement("QUES_ID");
            element.InnerText = gvSports.Rows[row.RowIndex].Cells[0].Text;
            dataElement.AppendChild(element);

            element = xmlData1.CreateElement("MKS_OBT");
            DropDownList ddlSportMarks=(DropDownList)row.FindControl("ddlSportMarks");
            element.InnerText = ddlSportMarks.SelectedValue;
            dataElement.AppendChild(element);

        }


        //TextBox2.Text = xmlData1.OuterXml;
        //Objbal.Xml = TextBox2.Text;
        //Objbal.balStuAdmNo = Session["UserId"].ToString();
        //Objbll.FeedFacMarksInsert(Objbal);
   

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


        foreach (GridViewRow row in gvInfra.Rows)
        {
            DropDownList ddlInfraMarks1 = (DropDownList)row.FindControl("ddlInfraMarks");
            if (ddlInfraMarks1.SelectedValue == "-1" || ddlInfraMarks1.SelectedValue == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Select valid marks!!')", true);
                return;
            }

            XmlElement dataElement = xmlData2.CreateElement("StuData");
            ROOT2.AppendChild(dataElement);

            XmlElement element = xmlData2.CreateElement("QUES_ID");
            element.InnerText = gvInfra.Rows[row.RowIndex].Cells[0].Text;
            dataElement.AppendChild(element);

            element = xmlData2.CreateElement("MKS_OBT");
            DropDownList ddlInfraMarks = (DropDownList)row.FindControl("ddlInfraMarks");
            element.InnerText = ddlInfraMarks.SelectedValue;
            dataElement.AppendChild(element);

        }


        //TextBox3.Text = xmlData2.OuterXml;
        //Objbal.Xml = TextBox3.Text;
        //Objbal.balStuAdmNo = Session["UserId"].ToString();
        //Objbll.FeedFacMarksInsert(Objbal);


        XmlDocument xmlData3 = new XmlDocument();
        XmlElement ROOT3;
        if (TextBox4.Text != "")
        {
            xmlData3.LoadXml(TextBox4.Text);
            ROOT3 = xmlData3.DocumentElement;
        }
        else
        {
            ROOT3 = xmlData3.CreateElement("MARKS");
            xmlData3.AppendChild(ROOT3);
        }


        foreach (GridViewRow row in gvSecurity.Rows)
        {
            DropDownList ddlSecMarks1 = (DropDownList)row.FindControl("ddlSecMarks");
            if (ddlSecMarks1.SelectedValue == "-1" || ddlSecMarks1.SelectedValue == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Select valid marks!!')", true);
                return;
            }

            XmlElement dataElement = xmlData3.CreateElement("StuData");
            ROOT3.AppendChild(dataElement);

            XmlElement element = xmlData3.CreateElement("QUES_ID");
            element.InnerText = gvSecurity.Rows[row.RowIndex].Cells[0].Text;
            dataElement.AppendChild(element);

            element = xmlData3.CreateElement("MKS_OBT");
            DropDownList ddlSecMarks = (DropDownList)row.FindControl("ddlSecMarks");
            element.InnerText = ddlSecMarks.SelectedValue;
            dataElement.AppendChild(element);

        }


        //TextBox4.Text = xmlData3.OuterXml;
        //Objbal.Xml = TextBox4.Text;
        //Objbal.balStuAdmNo = Session["UserId"].ToString();
        //Objbll.FeedFacMarksInsert(Objbal);


        XmlDocument xmlData4 = new XmlDocument();
        XmlElement ROOT4;
        if (TextBox5.Text != "")
        {
            xmlData4.LoadXml(TextBox5.Text);
            ROOT4 = xmlData4.DocumentElement;
        }
        else
        {
            ROOT4 = xmlData4.CreateElement("MARKS");
            xmlData4.AppendChild(ROOT4);
        }


        foreach (GridViewRow row in gvCafe.Rows)
        {
            DropDownList ddlCafeMarks1 = (DropDownList)row.FindControl("ddlCafeMarks");
            if (ddlCafeMarks1.SelectedValue == "-1" || ddlCafeMarks1.SelectedValue == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Select valid marks!!')", true);
                return;
            }

            XmlElement dataElement = xmlData4.CreateElement("StuData");
            ROOT4.AppendChild(dataElement);

            XmlElement element = xmlData4.CreateElement("QUES_ID");
            element.InnerText = gvCafe.Rows[row.RowIndex].Cells[0].Text;
            dataElement.AppendChild(element);

            element = xmlData4.CreateElement("MKS_OBT");
            DropDownList ddlCafeMarks = (DropDownList)row.FindControl("ddlCafeMarks");
            element.InnerText = ddlCafeMarks.SelectedValue;
            dataElement.AppendChild(element);

        }
        TextBox1.Text = xmlData.OuterXml;
        Objbal.XmlValue = TextBox1.Text;
        Objbal.Stu_AdmNo = ViewState["id"].ToString();
        Objbll.FeedFacMarksInsert(Objbal);
        TextBox2.Text = xmlData1.OuterXml;
        Objbal.XmlValue = TextBox2.Text;
        Objbal.Stu_AdmNo = ViewState["id"].ToString();
        Objbll.FeedFacMarksInsert(Objbal);
        TextBox3.Text = xmlData2.OuterXml;
        Objbal.XmlValue = TextBox3.Text;
        Objbal.Stu_AdmNo = ViewState["id"].ToString();
        Objbll.FeedFacMarksInsert(Objbal);
        TextBox4.Text = xmlData3.OuterXml;
        Objbal.XmlValue = TextBox4.Text;
        Objbal.Stu_AdmNo = ViewState["id"].ToString();
        Objbll.FeedFacMarksInsert(Objbal);
        TextBox5.Text = xmlData4.OuterXml;
        Objbal.XmlValue = TextBox5.Text;
        Objbal.Stu_AdmNo = ViewState["id"].ToString();
        Objbll.FeedFacMarksInsert(Objbal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('THANKS!! For completing your feedback.')", true);
        Response.Redirect("Trans_Host_Feedback.aspx?id=" + ViewState["id"]);

        clear();
        btnAdd.Visible = false;
 
    }
}