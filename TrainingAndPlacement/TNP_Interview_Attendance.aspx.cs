using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Xml;
using System.IO;
public partial class TrainingAndPlacement_TNP_Interview_Attendance : System.Web.UI.Page
{
    FillFunctions fillFunction;
    QueryFunctions queryFunctions;
    DatabaseFunctions databaseFunctions;
    CommonFunctions commonFunction;
    TPBAL ObjBal;
    TPBLL Objbll;

    void initialise()
    {
        fillFunction = new FillFunctions();
        queryFunctions = new QueryFunctions();
        databaseFunctions = new DatabaseFunctions();
        commonFunction = new CommonFunctions();
        ObjBal = new TPBAL();
        Objbll = new TPBLL();
    }
    void clear()
    {
        ddlcompany.SelectedIndex = ddljobprofile.SelectedIndex = ddlinterviewdate.SelectedIndex = 0;
        GvShow.DataSource = "";
        GvShow.DataBind();
        GvAdd.DataSource = "";
        GvAdd.DataBind();
    }
    public void Add()
    {
        XmlDocument xmlData = new XmlDocument();


        XmlElement ROOT;
        if (txtxml.Text != "")
        {
            xmlData.LoadXml(txtxml.Text);
            ROOT = xmlData.DocumentElement;
        }
        else
        {
            ROOT = xmlData.CreateElement("ADD");
            xmlData.AppendChild(ROOT);
        }
        foreach (GridViewRow row in GvShow.Rows)
        {
            XmlElement dataElement = xmlData.CreateElement("DATA");
            ROOT.AppendChild(dataElement);


            XmlElement element = xmlData.CreateElement("ENROLLMENT_NO");
            element.InnerText = GvShow.Rows[row.RowIndex].Cells[1].Text;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("STU_FULL_NAME");
            
            element.InnerText = GvShow.Rows[row.RowIndex].Cells[2].Text;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("BRN_SHORT_NAME");
            element.InnerText = GvShow.Rows[row.RowIndex].Cells[3].Text;
            dataElement.AppendChild(element);
            
            element = xmlData.CreateElement("INT_ATT_STS");
            CheckBox chkselect = (CheckBox)row.FindControl("chkselect");
            if (chkselect.Checked)
                element.InnerText = "1";
            else
                element.InnerText = "0";
            dataElement.AppendChild(element);
            txtxml.Text = xmlData.OuterXml;
            AddXmlData();
        }
    }
    public void AddXmlData()
    {
        if (txtxml.Text != "")
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new StringReader(txtxml.Text));
            GvAdd.DataSource = dataSet.Tables[0];
            GvAdd.DataBind();
        }
        else
        {
            GvAdd.DataSource = null;
            GvAdd.DataBind();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        initialise();
        if (!IsPostBack)
        {
            btnSearch.Attributes.Add("OnClick", "return validation()");
          fillFunction.Fill(ddlcompany, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.cmpny), true, FillFunctions.FirstItem.Select);
          btnsubmit.Visible = false;
          GvAdd.Visible = false;
          btnshow.Visible = false;
        }
    }
   
    protected void ddlcompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlcompany.SelectedIndex > 0)
        {
            fillFunction.Fill(ddljobprofile, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Job_profile, ddlcompany.SelectedValue), true, FillFunctions.FirstItem.Select);
        }
    }
    protected void ddljobprofile_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddljobprofile.SelectedIndex > 0)
        {
            fillFunction.Fill(ddlinterviewdate, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Intdate, ddljobprofile.SelectedValue), true, FillFunctions.FirstItem.Select);
        }
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ObjBal.Id = ddlinterviewdate.SelectedValue;
       fillFunction.Fill(GvShow, Objbll.INT_ATT_SELECT(ObjBal).Tables[0]);
       btnshow.Visible = true;
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        ObjBal.xml = txtxml.Text;
        //StringBuilder data = new StringBuilder();
        //CheckBox chkselect;

        //foreach (GridViewRow row in GvShow.Rows)
        //{
        //    chkselect = (CheckBox)row.FindControl("chkselect");
        //    if (chkselect.Checked)
        //    {
                
                Objbll.INT_ATT_INSERT(ObjBal);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Attendance Marked Successfully')", true);
                clear();
        //    }
        //    else 
        //    {
                
        //        Objbll.INT_ATT_INSERT(ObjBal);
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Attendance Marked Successfully')", true);
        //        clear();
        //    }
        //}

    }

    protected void btnshow_Click(object sender, EventArgs e)
    {
        GvAdd.Visible = true;
        btnsubmit.Visible = true;
        Add();
    }
}
