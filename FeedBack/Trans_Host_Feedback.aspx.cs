using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

public partial class FeedBack_Trans_Host_Feedback : System.Web.UI.Page
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

        //Objbal.balStuAdmNo = Session["UserId"].ToString();
        //string a = Objbll.FEED_REG_OPEN(Objbal);
        //if (a == "1")
        //{

        if (!IsPostBack)
        {
            PushData();

        }
        //}
        //else
        //{
        //    TR1.Visible = false;
        //    TR2.Visible = false;
        //    lblMsg.Text = a;


        //}
        ViewState["id"] = Request.QueryString["id"].ToString();
        Objbal.Stu_AdmNo = ViewState["id"].ToString();
        dt = Objbll.FEED_REG_OPEN(Objbal).Tables[1];
        string a = dt.Rows[0]["GEN_FAC"].ToString();
        if (a == "1")
        {
            lblMsg.Text = "Already Submitted";
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

        gvTransport.DataSource = Ds.Tables[6];
        gvTransport.DataBind();

    }
    public void clear()
    {

        gvTransport.DataSource = "";
        gvTransport.DataBind();
        txtsugg.Text = txtRoute.Text = txtIncharge.Text = "";
        TR1.Visible = false;
        TR2.Visible = false;
    }
    protected void txtSave_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow row in gvTransport.Rows)
            {

                DropDownList ddlTransport = (DropDownList)row.FindControl("ddlTransport");
                if (ddlTransport.SelectedValue == "-1" || ddlTransport.SelectedValue == "")
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

            foreach (GridViewRow row in gvTransport.Rows)
            {
                DropDownList ddlTransport = (DropDownList)row.FindControl("ddlTransport");
                XmlElement dataElement = xmlData.CreateElement("StuData");
                ROOT.AppendChild(dataElement);

                XmlElement element = xmlData.CreateElement("QUES_ID");
                element.InnerText = gvTransport.DataKeys[row.RowIndex].Value.ToString();
                dataElement.AppendChild(element);

                element = xmlData.CreateElement("MKS_OBT");
                DropDownList ddlTransport1 = (DropDownList)row.FindControl("ddlTransport");
                element.InnerText = ddlTransport1.SelectedValue;
                dataElement.AppendChild(element);

            }
            TextBox1.Text = xmlData.OuterXml;
            Objbal.XmlValue = TextBox1.Text;
            Objbal.Stu_AdmNo = ViewState["id"].ToString();
            Objbll.FeedFacMarksInsert(Objbal);

            Objbal.Stu_AdmNo = ViewState["id"].ToString();
            Objbal.KeyValue = txtRoute.Text;
            Objbal.Name = txtIncharge.Text;
            Objbal.Description = txtsugg.Text;
            Objbll.FeedRmkInsert(Objbal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('THANKS!! For completing your feedback.')", true);
            clear();

        }

        catch
        {

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('You have already Submitted..')", true);
        }
    }
}
