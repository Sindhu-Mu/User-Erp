using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Finance_BankAccount : System.Web.UI.Page
{
    QueryFunctions queryFunctions;
    FillFunctions fillFunction;
    SFBAL ObjBal;
    SFBLL ObjBll;
    DataTable dt;
    CommonFunctions cf;

    protected void Page_Load(object sender, EventArgs e)
    {

        Initialize();

        if (!IsPostBack)
        {
            fillFunction.Fill(ddladjtype, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.AdjType), true, FillFunctions.FirstItem.Select);
            
        }



    }
    protected void Initialize()
    {
        queryFunctions = new QueryFunctions();
        fillFunction = new FillFunctions();
        ObjBal = new SFBAL();
        ObjBll = new SFBLL();
        dt = new DataTable();
        cf = new CommonFunctions();
    }
    public void clear()
    {
        txtenroll.Text = txtAmount.Text = txtdate.Text = ddltrantype.SelectedValue = txtremark.Text = LBLCREDIT.Text = "";
    }
    protected void btnadd_Click(object sender, EventArgs e)
    {
        ObjBal.balEnroll = txtenroll.Text;
        ObjBal.balSession = Session["Userid"].ToString();
        ObjBal.balAmt = txtAmount.Text;
        ObjBal.balDateTime = cf.GetDateTime(txtdate.Text);
        ObjBal.balAdjType = ddladjtype.SelectedValue;
        ObjBal.balType = ddltrantype.SelectedValue;
        ObjBal.balRemark = txtremark.Text;
        ObjBll.SaveData(ObjBal);
        clear();
    }

    protected void ddladjtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ObjBal.balRemark = 
    }

    protected void btnshow_Click(object sender, EventArgs e)
    {
        Student.ShowStudent(txtenroll.Text);
        ObjBal.balEnroll = txtenroll.Text;
        //ObjBal.balMainId = txtenroll.Text;
        LBLCREDIT.Text = ObjBll.ShowCredit(ObjBal);
    }
}