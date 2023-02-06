using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Finance_BankAccount : System.Web.UI.Page
{
    QueryFunctions queryfunction;
    FillFunctions fillfunction;
    SFBAL balObj;
    SFBLL bllObj;
    DataTable dt;
    CommonFunctions cf;

    protected void Page_Load(object sender, EventArgs e)
    {
        //btnShow.Attributes.Add("OnClick", "return valid()");
        //btnAdd.Attributes.Add("OnClick", "return validCurrency()");
        Initialize();
        dvCrncy.Visible = false;

        if (!IsPostBack)
        {
            fillfunction.Fill(ddlSem, queryfunction.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.Select);
        }
    }
    protected void Initialize()
    {
        queryfunction = new QueryFunctions();
        fillfunction = new FillFunctions();
        balObj = new SFBAL();
        bllObj = new SFBLL();
        dt = new DataTable();
        cf = new CommonFunctions();
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        balObj.balEnrol = txtEnroll.Text;
        Student.ShowStudent(txtEnroll.Text);
        balObj.balSem = ddlSem.SelectedValue;
        dt = bllObj.FeeStatusSelect(balObj);
        gvShow.DataSource = dt;
        gvShow.DataBind();
        dvCrncy.Visible = true;
        //Clear();
        txtRate.Text = "";
        ddlCurrencyTo.SelectedIndex = 0;
        ddlCurrencyFrom.SelectedIndex = 0;

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        balObj.balEnrol = txtEnroll.Text;
        balObj.balSem = ddlSem.SelectedValue;
        balObj.balRate = txtRate.Text;
        balObj.balCrncyTo = ddlCurrencyTo.SelectedValue;
        balObj.balCrncyFrom = ddlCurrencyFrom.SelectedValue;
        balObj.balInBy = Session["UserId"].ToString();
        bllObj.FeeInfoInsert(balObj);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Data Inserted.')", true);
        Clear();

    }
    public void Clear()
    {
        txtEnroll.Text = "";
        ddlSem.SelectedIndex = 0;
        txtRate.Text = "";
        ddlCurrencyTo.SelectedIndex = 0;
        ddlCurrencyFrom.SelectedIndex = 0;
    }
}