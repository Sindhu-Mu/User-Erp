using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Inventory_IssueT_shirt : System.Web.UI.Page
{
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    INVBAL objBal;
    INVBLL objBll;
    DatabaseFunctions databaseFunctions;
    DataTable dt;
    string msg, enroll;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnsubmit.Attributes.Add("OnClick", "return validation()");
        if (!IsPostBack)
        {
            ViewState["Id"] = "";
        }
    }

    public void Initialize()
    {
        queryFunctions = new QueryFunctions();
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        objBal = new INVBAL();
        objBll = new INVBLL();
        databaseFunctions = new DatabaseFunctions();
        dt = new DataTable();
    }
    protected void btnshow_Click(object sender, EventArgs e)
    {
        if (txtenroll.Text == "")
        {
            if (txtformno.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Enter Enrollment no. or Form no.!!')", true);
                return;
            }
            else
            {
                objBal.KeyId = txtformno.Text;
                enroll = objBll.getEnrollment(objBal);
            }
        }
        else
        {
            enroll = commonFunctions.GetKeyID(txtenroll);
        }

        objBal.ID = enroll;

        ViewState["Id"] = objBll.getStuDetail(objBal);
        if (objBll.getStuDetail(objBal) != "0")
        {
            Student.ShowStudent(objBal.ID);
            trDetail.Visible = true;
            fillFunctions.Fill(ddlsubcat, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Sub), true, FillFunctions.FirstItem.Select);
        }
        else
        {
            trDetail.Visible = false;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Student withdrawl admission.!!')", true);
        }
    }
    protected void ddlsubcat_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlsubcat.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlitem, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Item, ddlsubcat.SelectedValue), true, FillFunctions.FirstItem.Select);
        }
        else
            ddlitem.Items.Clear();
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        objBal.ID = ViewState["Id"].ToString();
        objBal.ItemId = ddlitem.SelectedValue;
        objBal.SessionUserId = Session["UserId"].ToString();
        msg = objBll.IssueTshirt(objBal);

        if (msg == "Issued successfully!!")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prtRcpt.aspx?" + ViewState["Id"].ToString() + "')", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
        }
        clear();
    }
    void clear()
    {
        ddlitem.SelectedIndex = ddlsubcat.SelectedIndex = 0;
        txtenroll.Text = txtformno.Text = "";
        Student.Clear();
        trDetail.Visible = false;
    }
}