using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Finance_BankAccount : System.Web.UI.Page
{
    QueryFunctions queryfunctions;
    FillFunctions fillfunctions;
    SFBAL Objbal;
    SFBLL Objbll;
    DataSet ds;
    CommonFunctions cf;

    protected void Initialize()
    {
        queryfunctions = new QueryFunctions();
        fillfunctions = new FillFunctions();
        Objbal = new SFBAL();
        Objbll = new SFBLL();
        ds = new DataSet();
        cf = new CommonFunctions();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
       
        Initialize();
        
        if (!IsPostBack)
        {
            btnshow.Attributes.Add("OnClick", "return validate()");
            fillfunctions.Fill(ddlhead, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.MainHeadId), true, FillFunctions.FirstItem.Select);
        }
       
        
    }

    
    protected void btnshow_Click(object sender, EventArgs e)
    {
        Objbal.balMainHeadId = ddlhead.SelectedValue;
        Objbal.balCount = ddlcount.SelectedValue;
        Objbal.balStrtDate = cf.GetDateTime(txttodate.Text).ToString();
        Objbal.balEndDate = cf.GetDateTime(txtfromdate.Text).ToString();
        ds = Objbll.StufinLastTran(Objbal);
        gvshow.DataSource = ds;
        gvshow.DataBind();
    }
}