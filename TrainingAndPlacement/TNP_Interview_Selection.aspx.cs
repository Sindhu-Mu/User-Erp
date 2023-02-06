using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.IO;

public partial class TrainingAndPlacement_TNP_Interview_Selection : System.Web.UI.Page
{
    FillFunctions fillFunction;
    DatabaseFunctions databaseFunctions;
    QueryFunctions queryFunctions;
    TPBAL ObjBal;
    TPBLL ObjBll;
    DataTable dt;

    public void initialise()
    {
        fillFunction = new FillFunctions();
        databaseFunctions = new DatabaseFunctions();
        queryFunctions = new QueryFunctions();
        ObjBal = new TPBAL();
        ObjBll = new TPBLL();
        dt = new DataTable();

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

            element = xmlData.CreateElement("STATUS_ID");
            DropDownList ddlselect = (DropDownList)GvShow.Rows[row.RowIndex].FindControl("ddlselect");
            element.InnerText = ddlselect.SelectedValue;
        
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
        btnsave.Visible = false;
        GvAdd.Visible = false;
        if (!IsPostBack)
        {
            GvShow.DataSource = ObjBll.INT_RESULT(ObjBal).Tables[0];
           
            GvShow.DataBind();
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        ObjBal.xml = txtxml.Text;
        DropDownList ddlselect = (DropDownList)GvShow.Rows[0].FindControl("ddlselect");
        ObjBll.INT_RESULT_INSERT(ObjBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Result Saved Successfully.')", true);

    }

    protected void GvShow_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        foreach (GridViewRow row in GvShow.Rows)
        {
            DropDownList ddlselect = (DropDownList)row.FindControl("ddlselect");
            fillFunction.Fill(ddlselect, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.IntSTATUS), true, FillFunctions.FirstItem.Select);
        }
    }

    protected void btnshow_Click(object sender, EventArgs e)
    {
        GvAdd.Visible = true;
        btnsave.Visible = true;
        Add();
    }
}