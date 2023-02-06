using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for Messages
/// </summary>
public class Messages
{
    public enum MessType {EndValue, MaxPercentage,DuplicateRecord};
    public enum DataMessType { Insert, Update, Deleted, Error, Status, UpdateError, Recommand, Approve, Reject, Accept, Forward, Disable,LoginError };
    public enum MessageType { Information, Error };

	public Messages()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string GetMessage(MessType type)
    {
        string message = "";
        switch (type)
        {
            case MessType.EndValue:
                message = "End Value must be greater than Start Value";
                break;
            case MessType .MaxPercentage:
                message = "Percentage cannot be greater than 100";
                break;
            case MessType.DuplicateRecord:
                message = "Record for the specified value already exists";
                break;
            default:
                break;
        }
        return message;
    }
    public string GetMessage(DataMessType type)
    {
        string message = "Data ";
        switch (type)
        {
            case DataMessType.Deleted:
                message = "Selected record deleted successfully";
                break;
            case DataMessType.Error:
                message = "";
                message = "Error was encountered";
                break;
            case DataMessType.Insert:
                message = "One new record inserted successfully";
                break;
            case DataMessType .Update:
                message = "Selected record updated successfully";
                break;
            case DataMessType.Status:
                message = "Selected record status change successfully";
                break;
            case DataMessType.Recommand:
                message = "Selected record Recommanded successfully";
                break;
            case DataMessType.Approve:
                message = "Selected record Approved successfully";
                break;
            case DataMessType.Reject:
                message = "Selected record Rejected successfully";
                break;
            case DataMessType.Accept:
                message = "Selected record Accepted successfully";
                break;
            case DataMessType.Forward:
                message = "Your application forwarded successfully";
                break;
            case DataMessType.Disable:
                message = "Selected Record disabel successfully";
                break;
            case DataMessType.LoginError:
                message = "Invalid Login Id or Password!!.";
                break;
            case DataMessType.UpdateError:
                message = "Error on updatation of selected data.";
                break;
            default:
                break;
        }
        return message;
    }
    //public static bool DisplayMessage(Page page, string value)
    //{
    //    ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "clientScript", "alert('" + value + "')", true);
    //    return false;
    //}
    public void ShowMessages(EeekSoft.Web.PopupWin popUp, Page page,MessageType messageType, string message)
    {
        switch (messageType)
        {
            case MessageType.Error:
                popUp.Title = "Error";
                popUp.ColorStyle = EeekSoft.Web.PopupColorStyle.Red;
                break;
            case MessageType .Information:
                popUp.Title = "Information";
                popUp.ColorStyle = EeekSoft.Web.PopupColorStyle.Blue;
                break;
        }
        popUp.AutoShow = true;
        popUp.Visible = true;
        popUp.PopupSpeed = 1;
        popUp.HideAfter = 5000;
        popUp.Message = message;
        popUp.Text = message;
    } 
}
