using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;
using AjaxControlToolkit;
using System.IO;
/// <summary>
/// Summary description for CommonFunctions
/// </summary>
public class CommonFunctions
{
    public enum ClearType { Index, Value };
    public enum ReturnPart { First, Second };
    public enum ParameterType { Mandatory, Expected };
    public CommonFunctions()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void showAlert(System.Web.UI.Page pageObj, string Msg)
    {

        ScriptManager.RegisterClientScriptBlock(pageObj, pageObj.GetType(), "clientScript", "alert('" + Msg + "')", true);

    }
    public void Clear(Control root)
    {
        //foreach (Control controlHead in root.Controls)
        //{
        //    if (controlHead.HasControls())
        //        Clear(controlHead);
        //    else
        //    {
        //        switch (controlHead.ToString())
        switch(root.ToString())
                {
                    case "System.Web.UI.WebControls.TextBox":
                        TextBox textBox = (TextBox)root;
                        textBox.Text = "";
                        break;
                    case "System.Web.UI.WebControls.DropDownList":
                        DropDownList ddl = (DropDownList)root;
                        ddl.SelectedIndex = -1;
                        break;
                    case "System.Web.UI.WebControls.ListBox":
                        ListBox list = (ListBox)root;
                        list.Items.Clear();
                        break;
                    case "MREDKJ.NumericTextBox":
                        MREDKJ.NumericTextBox ntextBox = (MREDKJ.NumericTextBox)root;
                        ntextBox.Text = "";
                        break;
                    case "System.Web.UI.WebControls.Repeater":
                        Repeater rep = (Repeater)root;
                        rep.DataSource = null;
                        rep.DataBind();
                        break;
                    case "System.Web.UI.WebControls.GridView":
                        GridView gv = (GridView)root;
                        gv.DataSource = null;
                        gv.DataBind();
                        break;
                    default:
                        break;
                //}
            //}
        }
    }
    public void Clear(DropDownList ddlCaller, ClearType type, params DropDownList[] ddlParams)
    {
        ddlCaller.Focus();
        switch (type)
        {
            case ClearType.Index:
                foreach (DropDownList ddl in ddlParams)
                    ddl.SelectedIndex = 0;
                break;
            case ClearType.Value:
                foreach (DropDownList ddl in ddlParams)
                    ddl.Items.Clear();
                break;
        }
    }

    public string GetValueFromFillDouble(string value, ReturnPart part)
    {
        switch (part)
        {
            case ReturnPart.Second:
                return value.Substring(value.IndexOf('(') + 1, value.IndexOf(')') - (value.IndexOf('(') + 1));
            case ReturnPart.First:
                return value.Substring(0, value.IndexOf('(') - 1);
            default:
                throw new Exception();
        }
    }

    public string ValidateParameter(string parameter)
    {
        switch (parameter)
        {
            case "":
            case ".":
            case "...":
            case "&nbsp;":
            case " ":
            case "-1":
                return null;
            default:
                return parameter;
        }
    }
    public bool ValidateParameter(params string[] parameter)
    {
        bool returnValue = false;
        foreach (string param in parameter)
        {
            switch (param)
            {
                case "":
                case ".":
                case "...":
                case "&nbsp;":
                case " ":
                case "-1":
                    returnValue = false;
                    break;
                default:
                    returnValue = true;
                    break;
            }
        }
        return returnValue;
    }
    public DateTime GetDateTime(string datetime)
    {

        CultureInfo culture = new CultureInfo("hi-IN", true);
        DateTime checkDate = Convert.ToDateTime(datetime, culture);
        return checkDate;
        

    }
    public string GetToDate(string datetime)
    {
        CultureInfo culture = new CultureInfo("hi-IN", true);
        DateTime datetimeNew = Convert.ToDateTime(datetime, culture);
        datetimeNew = datetimeNew.AddDays(1D);
        return datetimeNew.ToString("dd/MM/yyyy");
    }
    public string GetDate(string datetime)
    {
        CultureInfo culture = new CultureInfo("hi-IN", true);
        DateTime datetimeNew = Convert.ToDateTime(datetime, culture);
        return datetimeNew.ToString("dd/MM/yyyy");
    }
    public string CurrentDate()
    {
        return DateTime.Now.ToString("dd/MM/yyyy");
    }
    public string GetKeyID(TextBox txt)
    {
        return txt.Text.Split(':').GetValue(1).ToString();
    }

    public void Clear(ClearType type, params DropDownList[] ddlParams)
    {
        switch (type)
        {
            case ClearType.Index:
                foreach (DropDownList ddl in ddlParams)
                    ddl.SelectedIndex = 0;
                break;
            case ClearType.Value:
                foreach (DropDownList ddl in ddlParams)
                    ddl.Items.Clear();
                break;
        }
    }
    public void MergeRows(GridView gridView, params int[] columns)
    {
        int last = gridView.Columns.Count - 1;

        for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--)
        {
            GridViewRow row = gridView.Rows[rowIndex];
            GridViewRow previousRow = gridView.Rows[rowIndex + 1];

            if (row.Cells[0].Text == previousRow.Cells[0].Text)
            {
                foreach (int col in columns)
                {

                    row.Cells[col].RowSpan = previousRow.Cells[col].RowSpan < 2 ? 2 :
                                               previousRow.Cells[col].RowSpan + 1;
                    previousRow.Cells[col].Visible = false;
                }
            }
        }
    }
    public void MergeRows(GridView gridView)
    {
        int last = gridView.Columns.Count - 1;

        for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--)
        {
            GridViewRow row = gridView.Rows[rowIndex];
            GridViewRow previousRow = gridView.Rows[rowIndex + 1];



            if (row.Cells[0].Text == previousRow.Cells[0].Text)
            {
                row.Cells[1].RowSpan = previousRow.Cells[1].RowSpan < 2 ? 2 :
                                           previousRow.Cells[1].RowSpan + 1;
                previousRow.Cells[1].Visible = false;

                //
                row.Cells[last - 1].RowSpan = previousRow.Cells[last - 1].RowSpan < 2 ? 2 :
                                        previousRow.Cells[last - 1].RowSpan + 1;
                previousRow.Cells[last - 1].Visible = false;
                //
                row.Cells[last].RowSpan = previousRow.Cells[last].RowSpan < 2 ? 2 :
                                         previousRow.Cells[last].RowSpan + 1;
                previousRow.Cells[last].Visible = false;
            }


        }
    }
    public string checkIndex(String sts)
    {
        string index;
        if (sts == ".")
        {
            index = "-1";
        }
        else
        {
            index = sts;
        }
        return index;
    }
    #region Inventory
    public static string getFinancialYear()
    {
        int yy1 = (DateTime.Today.Month < 4) ? DateTime.Today.Year - 1 : DateTime.Today.Year;
        int yy2 = yy1 + 1;
        return (yy1.ToString() + "-" + yy2.ToString().Substring(2));
    }

    public void Clear(ClearType type, params ComboBox[] ddlParams)
    {
        switch (type)
        {
            case ClearType.Index:
                foreach (ComboBox ddl in ddlParams)
                    ddl.SelectedIndex = 0;
                break;
            case ClearType.Value:
                foreach (ComboBox ddl in ddlParams)
                    ddl.Items.Clear();
                break;
        }
    }
    public string ConvertNumberToWord(double Amount)
    {
        long CurrentNumber = (long)Amount;
        string sReturn = "";

        if (CurrentNumber >= 10000000)
        {
            sReturn = sReturn + " " + GetWord(CurrentNumber / 10000000, "Crore");
            CurrentNumber = CurrentNumber % 10000000;
        }
        if (CurrentNumber >= 100000)
        {
            sReturn = sReturn + " " + GetWord(CurrentNumber / 100000, "Lac");
            CurrentNumber = CurrentNumber % 100000;
        }

        if (CurrentNumber >= 1000)
        {
            sReturn = sReturn + " " + GetWord(CurrentNumber / 1000, "Thousand");
            CurrentNumber = CurrentNumber % 1000;
        }
        if (CurrentNumber >= 100)
        {
            sReturn = sReturn + " " + GetWord(CurrentNumber / 100, "Hundred");
            CurrentNumber = CurrentNumber % 100;
        }
        if (CurrentNumber >= 20)
        {
            sReturn = sReturn + " " + GetWord(CurrentNumber, "");
            CurrentNumber = CurrentNumber % 10;
        }
        else if (CurrentNumber > 0)
        {
            sReturn = sReturn + " " + GetWord(CurrentNumber, "");
            CurrentNumber = 0;
        }
        return sReturn.Replace("  ", " ").Trim();
    }
    private string GetWord(long nNumber, string sPrefix)
    {
        long nCurrentNumber = nNumber;
        string sReturn = "";
        while (nCurrentNumber > 0)
        {
            if (nCurrentNumber > 100)
            {
                sReturn = sReturn + " " + GetWord(nCurrentNumber / 100, "Hundred");
                nCurrentNumber = nCurrentNumber % 100;
            }
            else if (nCurrentNumber >= 20)
            {
                sReturn = sReturn + " " + GetTwentyWord(nCurrentNumber / 10);
                nCurrentNumber = nCurrentNumber % 10;
            }
            else
            {
                sReturn = sReturn + " " + GetLessThanTwentyWord(nCurrentNumber);
                nCurrentNumber = 0;
            }
        }
        sReturn = sReturn + " " + sPrefix;
        return sReturn;
    }
    private string GetTwentyWord(long nNumber)
    {
        string sReturn = "";
        switch (nNumber)
        {
            case 2: sReturn = "Twenty"; break;
            case 3: sReturn = "Thirty"; break;
            case 4: sReturn = "Forty"; break;
            case 5: sReturn = "Fifty"; break;
            case 6: sReturn = "Sixty"; break;
            case 7: sReturn = "Seventy"; break;
            case 8: sReturn = "Eighty"; break;
            case 9: sReturn = "Ninety"; break;
        }
        return sReturn;
    }
    private string GetLessThanTwentyWord(long nNumber)
    {
        string sReturn = "";
        switch (nNumber)
        {
            case 1: sReturn = "One"; break;
            case 2: sReturn = "Two"; break;
            case 3: sReturn = "Three"; break;
            case 4: sReturn = "Four"; break;
            case 5: sReturn = "Five"; break;
            case 6: sReturn = "Six"; break;
            case 7: sReturn = "Seven"; break;
            case 8: sReturn = "Eight"; break;
            case 9: sReturn = "Nine"; break;
            case 10: sReturn = "Ten"; break;
            case 11: sReturn = "Eleven"; break;
            case 12: sReturn = "Twelve"; break;
            case 13: sReturn = "Thirteen"; break;
            case 14: sReturn = "Forteen"; break;
            case 15: sReturn = "Fifteen"; break;
            case 16: sReturn = "Sixteen"; break;
            case 17: sReturn = "Seventeen"; break;
            case 18: sReturn = "Eighteen"; break;
            case 19: sReturn = "Nineteen"; break;
        }
        return sReturn;
    }
    #endregion
}
