<%@ Page Title="ERP | Room Type Master" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="RoomTypeMain.aspx.cs" Inherits="Facility_RoomTypeMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <div class="heading">
            <h2>Room Type Master</h2>
        </div>

         <script language="javascript" type="text/javascript">
             function CheckControl(ctrl) {
                 if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "Select" || bTrim(document.getElementById(ctrl).value) == ".") {
                     document.getElementById(ctrl).style.backgroundColor = "#fc6";
                     return false;
                 }
                 else
                     document.getElementById(ctrl).style.backgroundColor = "#fff";
                 return true;
             }
             function validation() {

                 var flag = true;
                 var msg = "", ctrl = "";
                 if (!CheckControl("<%=txtRoomType.ClientID%>")) {
                        msg += "- Enter Room Type Value\n";
                        if (ctrl == "")
                            ctrl = "<%=txtRoomType.ClientID%>";
                    flag = false;
                }

                if (msg != "") alert(msg);
                if (ctrl != "")
                    document.getElementById(ctrl).focus();
                return flag;
            }
        </script>
   <table border="0" width="100%">
            <tr>
                <th>Room Type Value<span style="color:red">*</span></th>
                <td>&nbsp;</td>
              
            </tr>
            <tr>
                <td>
<asp:TextBox ID="txtRoomType" runat="server" Width="150px"></asp:TextBox>
                </td>  
                <td>&nbsp;</td> <td>&nbsp;</td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="Save" Width="70px" Height="28px" OnClick="btnSave_Click" />
                </td>
            </tr>
                 <tr>
                <td colspan="4">
                    <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" DataKeyNames="FAC_ROOM_TYP_ID" OnRowCommand="gvShow_RowCommand" Width="100%" EmptyDataText="No Record Avaliable" CssClass="gridDynamic">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No.">
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                .
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Room Type Value" DataField="FAC_ROOM_VALUE" />
                          
                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True" HeaderText="Modify">
                                <ItemStyle Width="40px" />
                            </asp:CommandField>
                            <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                <ItemStyle Width="20px" HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" CommandArgument='<%# Bind("FAC_ROOM_TYP_ID") %>'
                                        ImageUrl='<%# Bind("STS_IMG") %>' CommandName='<%# Bind("STS_CMD") %>' ToolTip='<%# Bind("STS_TOOLTIP")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                         <SelectedRowStyle BackColor="#FFFF99" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

