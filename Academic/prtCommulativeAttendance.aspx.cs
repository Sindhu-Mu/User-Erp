using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Specialized;

public partial class Academic_prtAttendanceCommulativeDetail : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    AcaBAL AcaBal;
    AcaBLL AcaBll;

    void Initialize()
    {
        fillFunctions = new FillFunctions();
        AcaBal = new AcaBAL();
        AcaBll = new AcaBLL();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            FillData(Request.QueryString);
        }
    }

    void FillData(NameValueCollection parameters)
    {
        AcaBal.KeyID = parameters.Get(0);
        AcaBal.CommonId = parameters.Get(1);
        AcaBal.TypeId = parameters.Get(2);
        AcaBal.DeptId = parameters.Get(3);
        AcaBal.Description = parameters.Get(4);
        AcaBal.ChangeStatus = parameters.Get(5);
        AcaBal.SessionUserID = parameters.Get(6);
        DataSet dataSet = AcaBll.GetAttClsNamePerDetails(AcaBal);
            //timeTable.GetAttClsNamePerDetails(parameters.Get(0),
            //parameters.Get(1), parameters.Get(2), parameters.Get(3), parameters.Get(4), parameters.Get(5), parameters.Get(6));
        fillFunctions.Fill(Repeater1, dataSet.Tables[0]);
        fillFunctions.Fill(gridAttClsNamePerDetail, dataSet.Tables[1]);
    }
}