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
using System.Net;

public partial class Academic_MenterShipForm : System.Web.UI.Page
{
    string Filter;
    int Filter_Type;
    AcaBAL ObjAcaBal;
    AcaBLL ObjAcaBll;
    FillFunctions FillFunction;
    QueryFunctions QueryFunction;
    CommonFunctions CommonFunction;
    DatabaseFunctions DataBaseFunction;
    //string Msg;
    DataTable dt;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            FillGrid();
           // btnSaveMentee.Visible = false;
            btnVisit.Visible = false;
            btnAchvSave.Visible = false;
            main.Visible = false;
            DivSMS.Visible = false;
        }
    }
    void Initialize()
    {
        ObjAcaBal = new AcaBAL();
        ObjAcaBll = new AcaBLL();
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        CommonFunction = new CommonFunctions();
        DataBaseFunction = new DatabaseFunctions();
        dt = new DataTable();
    }
    void FillGrid()
    {
        ObjAcaBal.Id = Session["UserId"].ToString();
        ds = ObjAcaBll.MentorDetail(ObjAcaBal);
        ViewState["ds"] = ds;
        gvStu.DataSource = ds.Tables[0];
        gvStu.DataBind();
    }

    protected void gvStu_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Detail")
      {
          string a = gvStu.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            //ds=ObjAcaBll.(a);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "MENTORSHIP_PROFILE_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STU_MAIN_ID", a);
        DataSet ds = DataBaseFunction.GetDataSet(cmd);
        dt = ds.Tables[0];
        ViewState["ds"] = ds;
        if (dt.Rows.Count > 0)
        {
            lblMentee.Text = dt.Rows[0]["STU_FULL_NAME"].ToString();
            imgPicture.Src = "../images/Stuimages/" + dt.Rows[0]["ENROLLMENT_NO"].ToString() + ".jpg";
            lblEnroll.Text = dt.Rows[0]["ENROLLMENT_NO"].ToString();
            lblAddress.Text = dt.Rows[0]["ADD_1"].ToString() + ' ' + dt.Rows[0]["ADD_2"].ToString() + ' ' + dt.Rows[0]["CIT_VALUE"].ToString();
            lblMentor.Text = dt.Rows[0]["EMP_NAME"].ToString();
            lblContPart.Text = dt.Rows[0]["PARENT_CONTACT"].ToString();
            lblBranch.Text = dt.Rows[0]["BRN_SHORT_NAME"].ToString();
            lblSection.Text = dt.Rows[0]["ACA_SEC_NAME"].ToString();
            lblProgram.Text = dt.Rows[0]["PGM_SHORT_NAME"].ToString();
            lblInst.Text = dt.Rows[0]["INS_VALUE"].ToString();
            lblContStu.Text = dt.Rows[0]["PHN_NO"].ToString();
            lblSem.Text = dt.Rows[0]["ACA_SEM_ID"].ToString();
            gvPrevQuali.DataSource = ds.Tables[1];
            gvPrevQuali.DataBind();

        }
        PopulateDataOnCharts(Filter, Filter_Type);
        FillAttendance();
        ViewState["STU_MAIN_ID"] = a;
       }
        main.Visible = true;
    }
    void FillAttendance()
    {
        DataSet ds2 = (DataSet)ViewState["ds"];
        gvAttendance.DataSource = ds2.Tables[2];
        gvAttendance.DataBind();
        gvMarks.DataSource = ds2.Tables[3];
        gvMarks.DataBind();
        gvSemResult.DataSource = ds2.Tables[4];
        gvSemResult.DataBind();
        if (ds2.Tables[5].Rows.Count > 0)
        {
            gvBack.DataSource = ds2.Tables[5];
            gvBack.DataBind();
        }

    }



    private void PopulateDataOnCharts(string Filter, int Filter_Type)
    {
        Initialize();


        DataSet ds1 = (DataSet)ViewState["ds"];
        if (ds1.Tables[2] != null)
        {
            Chart1.DataSource = ds1.Tables[2];
            Chart1.DataBind();
        }
        if (ds1.Tables[3] != null)
        {
            Chart2.DataSource = ds1.Tables[3];
            Chart2.DataBind();
        }




    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {

        Add();
        btnAchvSave.Visible = true;
        PopulateDataOnCharts(Filter, Filter_Type);
       
        txtachv.Text = "";
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

        XmlElement dataElement = xmlData.CreateElement("DATA");
        ROOT.AppendChild(dataElement);


        XmlElement element = xmlData.CreateElement("Achievement");
        element.InnerText = txtachv.Text;
        dataElement.AppendChild(element);

        txtxml.Text = xmlData.OuterXml;
        AddXmlData();

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

    protected void btnAdd1_Click(object sender, EventArgs e)
    {
        Add1();
        btnVisit.Visible = true;
        PopulateDataOnCharts(Filter, Filter_Type);
       
        txtDate.Text = txtPurpose.Text = txtSuggestion.Text = "";
    }
    protected void btnSaveMentee_Click(object sender, EventArgs e)
    {
        ObjAcaBal.TypeId = rdoAtt.SelectedValue;
        ObjAcaBal.KeyID = rdoBehaviour.SelectedValue;
        ObjAcaBal.Id = rdoParents.SelectedValue;
        ObjAcaBal.Stu_AdmNo = ViewState["STU_MAIN_ID"].ToString();
        ObjAcaBll.StuBehParInsert(ObjAcaBal);
                  

        ObjAcaBal.TypeId = rdoAtt.SelectedValue;
        //ObjAcaBal.SessionUserID = rdoBehave.SelectedValue;
        //ObjAcaBal.Ev_Sch_Id = rdoAca.SelectedValue;
        ObjAcaBal.Display = txtAcaRemark.Text;
        ObjAcaBal.Description = txtBehave.Text;
        ObjAcaBal.KeyValue = txtAttRemark.Text;
        ObjAcaBal.Stu_AdmNo = ViewState["STU_MAIN_ID"].ToString();
        ObjAcaBll.StuMenRmkInsert(ObjAcaBal);



        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Mentee Record Inserted Successfully.')", true);
        txtAcaRemark.Text = txtAttRemark.Text = txtBehave.Text = "";

        PopulateDataOnCharts(Filter, Filter_Type);
       
    }

    public void AddXmlData1()
    {
        if (txtxml1.Text != "")
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new StringReader(txtxml1.Text));
            gvMentee.DataSource = dataSet.Tables[0];
            gvMentee.DataBind();
        }
        else
        {
            gvMentee.DataSource = null;
            gvMentee.DataBind();
        }
    }

    public void Add1()
    {
        XmlDocument xmlData1 = new XmlDocument();


        XmlElement ROOT;
        if (txtxml1.Text != "")
        {
            xmlData1.LoadXml(txtxml1.Text);
            ROOT = xmlData1.DocumentElement;
        }
        else
        {
            ROOT = xmlData1.CreateElement("ADD");
            xmlData1.AppendChild(ROOT);
        }

        XmlElement dataElement = xmlData1.CreateElement("DATA");
        ROOT.AppendChild(dataElement);


        XmlElement element = xmlData1.CreateElement("VISITDATE");
        element.InnerText = CommonFunction.GetDateTime(txtDate.Text).ToString();
        dataElement.AppendChild(element);

        element = xmlData1.CreateElement("PURPOSE");
        element.InnerText = txtPurpose.Text;
        dataElement.AppendChild(element);

        element = xmlData1.CreateElement("SUGGESTION");
        element.InnerText = txtSuggestion.Text;
        dataElement.AppendChild(element);

        txtxml1.Text = xmlData1.OuterXml;
        AddXmlData1();

    }
    protected void btnAchvSave_Click(object sender, EventArgs e)
    {
        ObjAcaBal.XmlValue = txtxml.Text;
        ObjAcaBal.TypeId = rdoAtt.SelectedValue;
        ObjAcaBal.Stu_AdmNo = ViewState["STU_MAIN_ID"].ToString();
        ObjAcaBll.StuMentorInsert(ObjAcaBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Mentee Achievement Inserted Successfully.')", true);
        txtxml.Text = "";
        GvAdd.DataSource = "";
        GvAdd.DataBind();
        btnAchvSave.Visible = false;

        PopulateDataOnCharts(Filter, Filter_Type);

        
    }
    protected void btnVisit_Click(object sender, EventArgs e)
    {
        ObjAcaBal.XmlValue = txtxml1.Text;
        ObjAcaBal.TypeId = rdoAtt.SelectedValue;
        ObjAcaBal.Stu_AdmNo = ViewState["STU_MAIN_ID"].ToString();
        ObjAcaBll.StuMenteeVisit(ObjAcaBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Mentee Visit Inserted Successfully.')", true);
        btnVisit.Visible = false;
        txtxml1.Text = "";
        
        gvMentee.DataSource = "";
        gvMentee.DataBind();

        PopulateDataOnCharts(Filter, Filter_Type);
       // btnSaveMentee.Visible = true;
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        PopulateDataOnCharts(Filter, Filter_Type);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('MentorShipFormView.aspx?=" + ViewState["STU_MAIN_ID"].ToString() + "','_blank','scrollbars=1')", true);
    }

    protected void btnSMS_Click(object sender, EventArgs e)
    {
        if (txtSMS.Text != "")
        {
            string Msg = txtSMS.Text;
            string url = "http://BULK.SMS-INDIA.IN/unified.php?usr=27303&pwd=7351002587&ph=" + lblContPart.Text + "&sndr=MUUNIV&text=" + Msg + "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('SMS has been Sent.')", true);
           
            DivSMS.Visible = false;

            
        }
            
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Enter the text to send SMS.')", true);
        }

        PopulateDataOnCharts(Filter, Filter_Type);
    }
    protected void rdoParents_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoParents.SelectedValue == "0")
            DivSMS.Visible = true;
       
    }
    
}