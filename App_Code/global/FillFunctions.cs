using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Data.SqlClient;


/// <summary>
/// Summary description for FillFunctions
/// </summary>
public class FillFunctions
{
    public enum FirstItem { Select, All };
    public enum FillDoubleType { Item, Value };
    public const string noValue = "No records exists";
    DatabaseFunctions databaseFunctions;

    public FillFunctions()
    {
        databaseFunctions = new DatabaseFunctions();
    }
    #region StudentFinance
    public void Fill(RadioButtonList radioList, SqlCommand command, bool hasValue)
    {
        radioList.Items.Clear();
        SqlDataReader reader = null;

        try
        {
            reader = databaseFunctions.GetReader(command);

            if (hasValue)
            {
                while (reader.Read())
                    radioList.Items.Add(new ListItem(reader[0].ToString(), reader[1].ToString()));
            }
            else
            {
                while (reader.Read())
                    radioList.Items.Add(new ListItem(reader[0].ToString(), reader[0].ToString()));
            }
            radioList.Items[0].Selected = true;

        }
        catch
        {
            throw;
        }
        finally
        {
            command.Cancel();
            reader.Close();
        }
    }
    #endregion
    public void FillInteger(int startValue, int endValue, int interval, FirstItem item, params DropDownList[] ddlParams)
    {
        foreach (DropDownList ddl in ddlParams)
        {
            ddl.Items.Clear();
            for (; startValue <= endValue; startValue += interval)
                ddl.Items.Add(new ListItem(startValue.ToString(), startValue.ToString()));

            if (ddl.Items.Count > 0)
                ddl.Items.Insert(0, new ListItem(item.ToString(), "."));
            else
                ddl.Items.Insert(0, new ListItem(noValue, "."));
            ddl.SelectedIndex = 0;
        }
    }
    public void FillInteger(int startValue, int endValue, int interval, string appendText, FirstItem item, params DropDownList[] ddlParams)
    {
        foreach (DropDownList ddl in ddlParams)
        {
            ddl.Items.Clear();
            ddl.Items.Add(new ListItem(item.ToString(), "."));
            ddl.SelectedIndex = 0;
            for (; startValue <= endValue; startValue += interval)
                ddl.Items.Add(new ListItem(startValue.ToString() + " " + appendText, startValue.ToString()));
        }
    }
    public void FillYear(int startYear, int endYear, int interval, FirstItem item, params DropDownList[] ddlParams)
    {
        foreach (DropDownList ddl in ddlParams)
        {
            ddl.Items.Clear();


            for (; startYear <= endYear; startYear += interval)
                ddl.Items.Add(new ListItem(startYear.ToString(), startYear.ToString()));

            if (ddl.Items.Count > 0)
                ddl.Items.Insert(0, new ListItem(item.ToString(), "."));
            else
                ddl.Items.Insert(0, new ListItem(noValue, "."));
            ddl.SelectedIndex = 0;
        }
    }


    public void FillFinancialYear(int startYear, int endYear, int interval, FirstItem item, params DropDownList[] ddlParams)
    {
        foreach (DropDownList ddl in ddlParams)
        {
            ddl.Items.Clear();
            for (; startYear <= endYear; startYear += interval)
            {
                ddl.Items.Add(new ListItem(startYear.ToString() + '-' + (startYear + 1).ToString().Substring(2), startYear.ToString() + '-' + (startYear + 1).ToString().Substring(2)));
            }

            if (ddl.Items.Count > 0)
                ddl.Items.Insert(0, new ListItem(item.ToString(), "."));
            else
                ddl.Items.Insert(0, new ListItem(noValue, "."));
            ddl.SelectedIndex = 0;
        }
    }



    public static string getFinancialYear()
    {
        int yy1 = (DateTime.Today.Month < 4) ? DateTime.Today.Year - 1 : DateTime.Today.Year;
        int yy2 = yy1 + 1;
        return (yy1.ToString() + "-" + yy2.ToString().Substring(2));
    }

    public void Fill(DropDownList ddl, SqlCommand command, bool hasValue, FirstItem item)
    {
        ddl.Items.Clear();
        SqlDataReader reader = databaseFunctions.GetReader(command);



        if (hasValue)
        {
            while (reader.Read())
                ddl.Items.Add(new ListItem(reader[0].ToString(), reader[1].ToString()));
        }
        else
        {
            while (reader.Read())
                ddl.Items.Add(new ListItem(reader[0].ToString(), reader[0].ToString()));
        }


        if (ddl.Items.Count > 0)
            ddl.Items.Insert(0, new ListItem(item.ToString(), "."));
        else
            ddl.Items.Insert(0, new ListItem(noValue, "."));
        ddl.SelectedIndex = 0;

        command.Cancel();
        reader.Close();
    }
    public void Fill(DropDownList ddlCaller, DropDownList ddl, SqlCommand command, bool hasValue, FirstItem item)
    {
        ddl.Items.Clear();
        SqlDataReader reader = databaseFunctions.GetReader(command);


        if (hasValue)
        {
            while (reader.Read())
                ddl.Items.Add(new ListItem(reader[0].ToString(), reader[1].ToString()));
        }
        else
        {
            while (reader.Read())
                ddl.Items.Add(new ListItem(reader[0].ToString(), reader[0].ToString()));
        }

        if (ddl.Items.Count > 0)
            ddl.Items.Insert(0, new ListItem(item.ToString(), "."));
        else
            ddl.Items.Insert(0, new ListItem(noValue, "."));
        ddl.SelectedIndex = 0;

        command.Cancel();
        reader.Close();
        ddlCaller.Focus();
    }
    public void FillDouble(DropDownList ddl, SqlCommand command, bool hasValue, FirstItem item, FillDoubleType type)
    {
        ddl.Items.Clear();
        SqlDataReader reader = databaseFunctions.GetReader(command);

        if (hasValue)
        {
            if (type == FillDoubleType.Item)
            {
                while (reader.Read())
                    ddl.Items.Add(new ListItem(reader[0].ToString() + " (" + reader[2].ToString() + ") ", reader[1].ToString()));
            }
            else
            {
                while (reader.Read())
                    ddl.Items.Add(new ListItem(reader[0].ToString(), reader[1].ToString() + " (" + reader[2].ToString() + ") "));
            }
        }
        else
        {
            if (type == FillDoubleType.Item)
            {
                while (reader.Read())
                    ddl.Items.Add(new ListItem(reader[0].ToString() + " (" + reader[1].ToString() + ") ", reader[1].ToString()));
            }
            else
            {
                while (reader.Read())
                    ddl.Items.Add(new ListItem(reader[0].ToString(), reader[1].ToString() + " (" + reader[1].ToString() + ") "));
            }
        }

        if (ddl.Items.Count > 0)
            ddl.Items.Insert(0, new ListItem(item.ToString(), "."));
        else
            ddl.Items.Insert(0, new ListItem(noValue, "."));
        ddl.SelectedIndex = 0;
        command.Cancel();
        reader.Close();
    }
    public void FillDouble(DropDownList ddlCaller, DropDownList ddl, SqlCommand command, bool hasValue, FirstItem item, FillDoubleType type)
    {
        ddlCaller.Focus();
        ddl.Items.Clear();
        SqlDataReader reader = databaseFunctions.GetReader(command);

        if (hasValue)
        {
            if (type == FillDoubleType.Item)
            {
                while (reader.Read())
                    ddl.Items.Add(new ListItem(reader[0].ToString() + " (" + reader[2].ToString() + ") ", reader[1].ToString()));
            }
            else
            {
                while (reader.Read())
                    ddl.Items.Add(new ListItem(reader[0].ToString(), reader[1].ToString() + " (" + reader[2].ToString() + ") "));
            }
        }
        else
        {
            if (type == FillDoubleType.Item)
            {
                while (reader.Read())
                    ddl.Items.Add(new ListItem(reader[0].ToString() + " (" + reader[1].ToString() + ") ", reader[1].ToString()));
            }
            else
            {
                while (reader.Read())
                    ddl.Items.Add(new ListItem(reader[0].ToString(), reader[1].ToString() + " (" + reader[1].ToString() + ") "));
            }
        }

        if (ddl.Items.Count > 0)
            ddl.Items.Insert(0, new ListItem(item.ToString(), "."));
        else
            ddl.Items.Insert(0, new ListItem(noValue, "."));
        ddl.SelectedIndex = 0;

        command.Cancel();
        reader.Close();
    }
    public void Fill(GridView grid, SqlCommand command)
    {
        grid.DataSource = null;
        grid.DataBind();
        SqlDataReader reader = databaseFunctions.GetReader(command);
        grid.DataSource = reader;
        grid.DataBind();
        command.Cancel();
        reader.Close();
    }
    public void Fill(Repeater rep, SqlCommand command)
    {
        rep.DataSource = null;
        rep.DataBind();
        SqlDataReader reader = databaseFunctions.GetReader(command);
        rep.DataSource = reader;
        rep.DataBind();
        command.Cancel();
        reader.Close();
    }
    public void Fill(GridView grid, DataTable dataTable)
    {
        grid.DataSource = null;
        grid.DataBind();
        grid.DataSource = dataTable;
        grid.DataBind();
    }
    public void Fill(Repeater rep, DataTable dataTable)
    {
        rep.DataSource = null;
        rep.DataBind();
        rep.DataSource = dataTable;
        rep.DataBind();
    }
    public void Fill(DataList rep, SqlCommand command)
    {
        rep.DataSource = null;
        rep.DataBind();
        SqlDataReader reader = databaseFunctions.GetReader(command);
        rep.DataSource = reader;
        rep.DataBind();
        command.Cancel();
        reader.Close();
    }
    public void Fill(DropDownList ddl, DataTable dataTable, bool hasValue, FirstItem item)
    {
        ddl.Items.Clear();
        foreach (DataRow row in dataTable.Rows)
        {
            if (hasValue)
                ddl.Items.Add(new ListItem(row[0].ToString(), row[1].ToString()));
            else
                ddl.Items.Add(new ListItem(row[0].ToString(), row[0].ToString()));
        }
        if (ddl.Items.Count > 0)
            ddl.Items.Insert(0, new ListItem(item.ToString(), "."));
        else
            ddl.Items.Insert(0, new ListItem(noValue, "."));
        ddl.SelectedIndex = 0;
    }

    public void FillWeekdays(CheckBoxList checkList, DateTime startDate)
    {
        checkList.Items.Clear();
        int dayOfWeek = Convert.ToInt32(startDate.DayOfWeek);
        foreach (DayOfWeek weekDay in Enum.GetValues(typeof(DayOfWeek)))
        {
            if (Convert.ToInt32(weekDay) > dayOfWeek)
                checkList.Items.Add(new ListItem(weekDay.ToString(), Convert.ToString(Convert.ToInt32(weekDay))));
        }
    }

    public void Fill(AjaxControlToolkit.ComboBox ddl, SqlCommand command, bool hasValue, FirstItem firstItem)
    {
        ddl.Items.Clear();
        //SqlDataReader reader = new SqlDataReader();
        try
        {
            SqlDataReader reader = databaseFunctions.GetReader(command);


            if (hasValue)
            {
                while (reader.Read())
                    ddl.Items.Add(new ListItem(reader[0].ToString(), reader[1].ToString()));
            }
            else
            {
                while (reader.Read())
                    ddl.Items.Add(new ListItem(reader[0].ToString(), reader[0].ToString()));
            }
            //if (ddl.Items.Count > 0)
            //    ddl.Items.Insert(0, new ListItem(item.ToString(), ""));
            //else
            //    ddl.Items.Insert(0, new ListItem(noValue, ""));
            ddl.SelectedIndex = 0;
            //throw new NotImplementedException();
        }
        catch
        {

        }
    }

    public void FillSection(DropDownList ddl, int level, FirstItem item)
    {
        ddl.Items.Clear();
        char ch;
        ddl.Items.Add(new ListItem(item.ToString(), ""));
        for (int i = 0; i <= level; i++)
        {
            ch = Convert.ToChar(65 + i);
            ddl.Items.Add(new ListItem(ch.ToString(), ch.ToString()));
        }
    }
    public void Fill(CheckBoxList lstBox, SqlCommand command, bool hasValue)
    {

        lstBox.Items.Clear();
        SqlDataReader reader = databaseFunctions.GetReader(command);



        if (hasValue)
        {
            while (reader.Read())
                lstBox.Items.Add(new ListItem(reader[0].ToString(), reader[1].ToString()));
        }
        else
        {
            while (reader.Read())
                lstBox.Items.Add(new ListItem(reader[0].ToString(), reader[0].ToString()));
        }




        lstBox.SelectedIndex = 0;

        command.Cancel();
        reader.Close();
    }


    public void FillList(ListBox lstBox, DataTable dataTable)
    {
        ListItem lst;
        foreach (DataRow row in dataTable.Rows)
        {
            lst = new ListItem();
            lst.Text = row[1].ToString();
            lst.Value = row[0].ToString();
            lstBox.Items.Add(lst);
        }
    }
    public void Fill(DropDownList ddl, SqlCommand command, bool hasValue)
    {
        ddl.Items.Clear();
        SqlDataReader reader = databaseFunctions.GetReader(command);
        ddl.Items.Add(new ListItem("Select", "-1"));
        if (hasValue)
        {
            while (reader.Read())
                ddl.Items.Add(new ListItem(reader[0].ToString(), reader[1].ToString()));
        }
        else
        {
            while (reader.Read())
                ddl.Items.Add(new ListItem(reader[0].ToString(), reader[0].ToString()));
        }
        command.Cancel();
        reader.Close();
    }
}
