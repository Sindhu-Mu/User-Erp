using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;

public class NoticePicker
{
    private int _newsID;
    private String _newsDate;
    private String _expiredon;
    private String _newsHeading;
    private String _newsDesc;
    private String _vewFileName;
    private String _dwfilename;

    public NoticePicker()
    {
        _newsID = 0;
        _newsDate = "";
        _expiredon = "";
        _newsHeading = "";
        _newsDesc = "";
        _vewFileName = "";
        _dwfilename = "";

    }

    public NoticePicker(int newsID, String newsDate, String expiredon, String newsHeading, String newsDesc, String vewFileName, String dwfilename)
    {
        _newsID = newsID;
        _newsDate = newsDate;
        _expiredon = expiredon;
        _newsHeading = newsHeading;
        _newsDesc = newsDesc;
        _vewFileName = vewFileName;
        _dwfilename = dwfilename;
    }

    public int newsID { get { return _newsID; } }
    public string newsDate { get { return _newsDate; } }
    public string expiredon { get { return _expiredon; } }
    public string newsHeading { get { return _newsHeading; } }
    public string newsDesc { get { return _newsDesc; } }
    public string vewFileName { get { return _vewFileName; } }
    public string dwfilename { get { return _dwfilename; } }

    public List<NoticePicker> GetAllUserNotices(string UserID,string Type)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
        SqlCommand cmd = new SqlCommand("GET_NOTICE_CIRCULAR_FOR_EMPLOYEE", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@USR_ID", UserID);
        cmd.Parameters.AddWithValue("@TYP", Type);
        cn.Open();
        List<NoticePicker> lst = new List<NoticePicker>();
        SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        while (sdr.Read())
        {
            NoticePicker objNp = new NoticePicker(Convert.ToInt32(sdr["NEWS_ID"]), sdr["NEWS_DT"].ToString(), sdr["EXPIRED_ON"].ToString(), sdr["NEWS_HEADING"].ToString(), sdr["NEWS_DESC"].ToString(), sdr["FILE_PATH"].ToString(), sdr["FILE_PATH"].ToString());
            lst.Add(objNp);
        }
        return lst;

    }

    public List<NoticePicker> GetAllUserNoticesSearch(string UserID,string filter,string date,string Type)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
        SqlCommand cmd = new SqlCommand("GET_NOTICE_CIRCULAR_FOR_EMPLOYEE_SEARCH", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@USR_ID", UserID);
        cmd.Parameters.AddWithValue("@FILTER", filter);
        cmd.Parameters.AddWithValue("@DATE", date);
        cmd.Parameters.AddWithValue("@TYP", Type);
        cn.Open();
        List<NoticePicker> lst = new List<NoticePicker>();
        SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        while (sdr.Read())
        {
            NoticePicker objNp = new NoticePicker(Convert.ToInt32(sdr["NEWS_ID"]), sdr["NEWS_DT"].ToString(), sdr["EXPIRED_ON"].ToString(), sdr["NEWS_HEADING"].ToString(), sdr["NEWS_DESC"].ToString(), sdr["FILE_PATH"].ToString(), sdr["FILE_PATH"].ToString());
            lst.Add(objNp);
        }
        return lst;

    }

    //public List<NoticePicker> GetAllScrolledNotices()
    //{
    //    SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
    //    SqlCommand cmd = new SqlCommand("sp_Notice_Select_Scroll", cn);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cn.Open();
    //    List<NoticePicker> lst = new List<NoticePicker>();
    //    SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
    //    while (sdr.Read())
    //    {
    //        NoticePicker objNp = new NoticePicker(Convert.ToInt32(sdr["newsID"]), Convert.ToString(sdr["newsDate"]), Convert.ToString(sdr["expiredon"]), Convert.ToString(sdr["newsHeading"]), Convert.ToString(sdr["newsDesc"]), Convert.ToString(sdr["vewFileName"]), Convert.ToString(sdr["dwfilename"]));
    //        lst.Add(objNp);
    //    }
    //    return lst;

    //}
    //public List<NoticePicker> GetAllUserNotices()
    //{
    //    SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
    //    SqlCommand cmd = new SqlCommand("sp_Notice_Select_All", cn);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cn.Open();
    //    List<NoticePicker> lst = new List<NoticePicker>();
    //    SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
    //    while (sdr.Read())
    //    {
    //        NoticePicker objNp = new NoticePicker(Convert.ToInt32(sdr["newsID"]), Convert.ToString(sdr["newsDate"]), Convert.ToString(sdr["expiredon"]), Convert.ToString(sdr["newsHeading"]), Convert.ToString(sdr["newsDesc"]), Convert.ToString(sdr["vewFileName"]), Convert.ToString(sdr["dwfilename"]));
    //        lst.Add(objNp);
    //    }
    //    return lst;

    //}
    public List<NoticePicker> GetSpecificNotice(int newsid)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
        SqlCommand cmd = new SqlCommand("SELECT_NOTICE_INFO_BY_ID", cn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@NEWS_ID", newsid));
        cn.Open();
        List<NoticePicker> lst = new List<NoticePicker>();
        SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        while (sdr.Read())
        {
            NoticePicker objNp = new NoticePicker(Convert.ToInt32(sdr["NEWS_ID"]), sdr["NEWS_DT"].ToString(), sdr["EXPIRED_ON"].ToString(), sdr["NEWS_HEADING"].ToString(), sdr["NEWS_DESC"].ToString(), sdr["FILE_PATH"].ToString(), sdr["FILE_PATH"].ToString());
            lst.Add(objNp);
        }
        return lst;

    }

    //public int GetMaxNoticeID()
    //{
    //    SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
    //    SqlCommand cmd = new SqlCommand("sp_Notice_Max", cn);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cn.Open();
    //    SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
    //    sdr.Read();


    //    return Convert.ToInt32(sdr["newsID"]);
    //}
}