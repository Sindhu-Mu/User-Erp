<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainPage.master" AutoEventWireup="true" CodeFile="CollectionPrint.aspx.cs" Inherits="Academic_CollectionPrint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Collection Print</h2>
        </div>
       <div>
                    <table>
                        <tr>
                           
                            <th>Date*</th>
                             <th>Shift*</th>
                             <th>Institute</th>
                            <th>&nbsp;</th>
                            <th>From Room*</th>
                            <th>To Room*</th>
                           
                            <th>Document</th>
                        </tr>
                        <tr>
                          
                            <td>
                                <asp:TextBox ID="txtdate" runat="server" Width="130px"></asp:TextBox>
                                 <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                        TargetControlID="txtDate">
                    </ajaxToolkit:CalendarExtender>
                            </td>
                             <td>
                                <asp:DropDownList ID="ddlshift" runat="server" Width="130px"></asp:DropDownList>
                            </td>
                               <td>
                        <asp:DropDownList ID="ddlInstitute" runat="server" AutoPostBack="true" ></asp:DropDownList>
                    </td>
                            <td>
                                <asp:Button ID="btnLoad" runat="server" Text="Load" OnClick="btnLoad_Click" Width="50px" />
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlFromRoom" runat="server" Width="130px"></asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlToRoom" runat="server" Width="130px"></asp:DropDownList>
                            </td>
                           
                            <td>
                                <asp:DropDownList ID="ddldocument" runat="server" Width="130px">
                                    <asp:ListItem Value="1">Attendance</asp:ListItem>
                                    <asp:ListItem Value="2">Copy Receive</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="btnprint" runat="server" Text="Print" Width="80px" OnClick="btnprint_Click" />
                            </td>
                        </tr>

                    </table>
              </div>
         

    </div>

</asp:Content>

