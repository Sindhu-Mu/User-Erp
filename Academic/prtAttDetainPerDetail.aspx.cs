using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Data;


public partial class Academic_prtAttDetainPerDetail : System.Web.UI.Page
{
    AcaBAL Objbal;
    AcaBLL Objbll;
    FillFunctions FillFunction;
    QueryFunctions QueryFunction;
    CommonFunctions CommonFunction;
    DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            if (Request.QueryString.Count == 6)
            {
                PushData(Request.QueryString);
            }

        }
    }
    void Initialize()
    {
        Objbal = new AcaBAL();
        Objbll = new AcaBLL();
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        CommonFunction = new CommonFunctions();
        ds = new DataSet();
    }
    void PushData(NameValueCollection parameters)
    {
        NameValueCollection par = parameters;
        Objbal.Brn_Id = par.Get(0);
        Objbal.Semid = par.Get(1);
        Objbal.TypeId = par.Get(2);
        Objbal.Value = par.Get(3);
        Objbal.Max_Dt = par.Get(4);
        Objbal.UseFor = par.Get(5);
        ds = Objbll.GetStuPrintDetail(Objbal);

        FillFunction.Fill(Repeater1, ds.Tables[0]);

        if (ds.Tables[1].Rows.Count > 0)
        {
            BoundField field;
            foreach (DataColumn column in ds.Tables[1].Columns)
            {
                if (column.ColumnName != "ENROLLMENT_NO" && column.ColumnName != "SEM_ROLL_NO" && column.ColumnName != "STU_FULL_NAME")
                {
                    field = new BoundField();

                    field.DataField = column.ColumnName;
                    field.HtmlEncode = false;

                    field.HeaderText = column.ColumnName;
                    field.ItemStyle.HorizontalAlign = HorizontalAlign.Center;

                    gridData.Columns.Add(field);
                }

            }

        }
        FillFunction.Fill(gridData, ds.Tables[1]);
    }
}
