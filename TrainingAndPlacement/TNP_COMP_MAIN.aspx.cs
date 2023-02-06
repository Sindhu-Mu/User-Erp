using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class TrainingAndPlacement_TNP_COMP_MAIN : System.Web.UI.Page
{
    FillFunctions fillfunctions;
    QueryFunctions queryFunctions;
    DatabaseFunctions databaseFunctions;
    TPBAL ObjBal;
    TPBLL ObjBll;

    public void initialise()
    { 
    fillfunctions=new FillFunctions();
    queryFunctions = new QueryFunctions();
    databaseFunctions = new DatabaseFunctions();
    ObjBal = new TPBAL();
    ObjBll = new TPBLL();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        initialise();
        btnsave.Attributes.Add("onclick", "return validation()");
        if(!IsPostBack)
        {
        fillfunctions.Fill(ddlcity,queryFunctions.GetCommand(QueryFunctions.QueryBaseType.CITY), true, FillFunctions.FirstItem.Select);
            fillfunctions.Fill(ddlcompprofile,queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Comp_profile), true, FillFunctions.FirstItem.Select);
           // btnsave.Visible = false;
        }
    }
    public void clear()
    {
        ddlcity.SelectedIndex = ddlcompprofile.SelectedIndex = 0;
        txtcompadd.Text = txtcompemail.Text = txtcompname.Text = txtcompphn.Text = txtcompwebsite.Text = txtOthers.Text = txtperadd.Text = txtperemail.Text = txtpername.Text = txtperphn.Text = "";
        //gvCompDetail.DataSource = "";
        //gvCompDetail.DataBind();
        //GvPersonDetail.DataSource = "";
        //GvPersonDetail.DataBind();
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        ObjBal.Id = ddlcity.SelectedValue;
        ObjBal.Name = txtcompname.Text;
        ObjBal.Address = txtcompadd.Text;
        ObjBal.Phone = txtcompphn.Text;
        ObjBal.Email = txtcompemail.Text;
        ObjBal.Website = txtcompwebsite.Text;
        ObjBal.Profile = ddlcompprofile.SelectedValue; 
        ObjBal.Others=txtOthers.Text;
        ObjBal.SessionUserId = Session["UserId"].ToString();
        ObjBal.Per_Name = txtpername.Text;
        ObjBal.Per_Add = txtperadd.Text;
        ObjBal.Per_Phn = txtperphn.Text;
        ObjBal.Per_Email = txtperemail.Text;
        ObjBll.GetMain(ObjBal);
        clear();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Company Registered Successfully.')", true);
        
    }
    protected void btnshow_Click(object sender, EventArgs e)
    {
        //fillfunctions.Fill(gvCompDetail, ObjBll.Comp_Detail(ObjBal).Tables[0]);

       // fillfunctions.Fill(GvPersonDetail, ObjBll.PER_DETAIL(ObjBal).Tables[0]);
       // btnsave.Visible = true;
    }
}