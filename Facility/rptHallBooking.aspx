<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rptHallBooking.aspx.cs" Inherits="Facility_rptHallBooking" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HALL BOOKING</title>
    <style type="text/css">
        .style2
        {
            text-align: center;
            font-size: 12pt;            
               font-weight:bold;
           
        }
        .style3
        { 
        
            text-decoration: underline;
            font-weight:bold;
        }
        .style4
        {
            height: 20px;
        }
    </style>
</head>
<body>

    <form id="form1" runat="server" >
    <table style="width:680px;font-family:Book Antiqua;font-size:14px;margin-top:0px;">
   <tr><td style="height:60px" colspan="7"><span style="font-size:16px"   >
       <span class="style3" >MANGALAYATAN UNIVERSITY</span><br />
       </span>Extended NCR,Aligarh-Mathura Highway, P.O.-Beswan,Aligrah-202145(INDIA)<br />
               </td></tr>
    <tr><td colspan="7" class="style2">
        HALL BOOKING DETAIL&nbsp;<br />
        <hr/>
        &nbsp;</td></tr>
        <tr>
            <td  colspan="7">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Hall &nbsp;Name</td>
            <td>
                :</td>
            <td>
                <asp:Label ID="lblHall" runat="server"></asp:Label></td>
            <td style="width: 50px">&nbsp;
                </td>
            <td>
                Booked Date</td>
            <td>
                :</td>
            <td>
                <asp:Label ID="lblDate" runat="server" /></td>
        </tr>
        <tr>
            <td>
                Event </td>
            <td>
                :</td>
            <td>
                <asp:Label ID="lblEvent" runat="server" /></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                No of Seat
            </td>
            <td>
                :</td>
            <td>
                <asp:Label ID="lblNOStudent" runat="server" /></td>
            <td>&nbsp;
            </td>
            <td>
                Time on</td>
            <td>
                :</td>
            <td>
                <asp:Label ID="lblTime" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>
                Adm. Req.</td>
            <td>
                :</td>
            <td>
                <asp:Label ID="lblAdmReq" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>
                Facility
            </td>
            <td>
                :</td>
            <td>
                &nbsp;<asp:Label ID="lblFacility" runat="server" /></td>
        </tr>
        <tr>
            <td>
                Booked By</td>
            <td>
                :</td>
            <td>
                <asp:Label ID="lblName" runat="server"></asp:Label></td>
            <td>
            </td>
            <td>
                Department</td>
            <td>
                :</td>
            <td>
                <asp:Label ID="lblDept" runat="server"></asp:Label></td>
        </tr>
       
            
        <tr>
            <td>
                Guest Name</td>
            <td>
                :</td>
            <td>
                <asp:Label ID="lblGuestName" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                Guest PhoneNo.</td>
            <td>
                :</td>
            <td>
                <asp:Label ID="lblGuestNo" runat="server"></asp:Label>
            </td>
        </tr>
       
            
        <tr>
            <td>
                Guest Add.</td>
            <td>
                :</td>
            <td colspan="5">
                <asp:Label ID="lblGuestAddress" runat="server"></asp:Label>
            </td>
        </tr>
       
            
        <tr>
            <td colspan="7">
                Requirements from Store:</td>
        </tr>
       
            
        <tr>
            <td colspan="7">
                <asp:GridView ID="GvFac" runat="server" EmptyDataText="No requirements" EnableModelValidation="True" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField HeaderText="Item Name" DataField="ITEM_VALUE" />
                        <asp:BoundField HeaderText="Quantity" DataField="QTY" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
       
            
        <tr>
            <td colspan="7">
                &nbsp;Detail of Event&nbsp;
<hr/>
                <asp:Label ID="lblDetail" runat="server" Width="500px"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="7">
                &nbsp;</td>
        </tr>
          <tr>
            <td colspan="7">
                <strong>
               Process flow Detail </strong>
              </td>
        </tr>
              <tr>
            <td colspan="7">
                <asp:GridView ID="gvHall" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="S.No">
                            <ItemTemplate>
                                <%#((GridViewRow)Container).RowIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="STS_VALUE" HeaderText="Action" />
                        <asp:BoundField DataField="TRAN_NAME" HeaderText="Action By" />
                        <asp:BoundField DataField="HALL_TRAN_DATE" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Date" />
                        <asp:BoundField DataField="HALL_TRAN_REMARK" HeaderText="Remark" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr> 
       
    </table>
    
    </form>
</body>
</html>
