using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Academic_prtClassStudent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.Count > 0)
        {
            AcaBAL AcaBal = new AcaBAL();
            AcaBLL AcaBll = new AcaBLL();
            AcaBal.KeyID = Request.QueryString["id"];

            DataSet dataSet = AcaBll.GetAttendanceDetails(AcaBal);
            FillFunctions fillFunctions = new FillFunctions();
            fillFunctions.Fill(gridViewData, dataSet.Tables[0]);
            fillFunctions.Fill(gridDetail, dataSet.Tables[1]);
            dataSet.Dispose();
        }
    }
}