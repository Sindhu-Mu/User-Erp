<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="HeadTempMap.aspx.cs" Inherits="PayRoll_Sal_Template_Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <script language="javascript" type="text/javascript">
          function CheckControl(ctrl) {
            
             if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == ".") {
                 document.getElementById(ctrl).style.backgroundColor = "#fc6";
                 
                 return false;
             }
             else {
                 document.getElementById(ctrl).style.backgroundColor = "#fff";
                 return true;
             }
         }
         function validation() {
            
             var flag = true;
             var msg ="", ctrl = "";
             {
                msg += " * Template name can't be blank. \n";
                
                flag = false;
             
            }
          
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
         </script>
  <asp:UpdatePanel ID="UpdatePanel2" runat="server">
 <ContentTemplate>
    <h3>Template Head Map</h3>
    <hr/>
<table>
    <tr>
                                                                    <td style="height: 13px">
                                                                        Template Name<span style="color: #ff0000">*</span></td>
                                                                    <td style="height: 13px">
                                                                        &nbsp;</td>
                                                                    <td style="width: 203px; height: 13px">
                                                                        &nbsp;Head Name<span style="color: #ff0000">*</span></td>
                                                                    <td style="height: 13px">
                                                                        &nbsp;<span style="color: #ff0000"></span></td>
                                                                    <td style="height: 13px">
                                                                        &nbsp;Value Type<span style="color: #ff0000">*</span></td>
                                                                    <td style="height: 13px">
                                                                        &nbsp;Values</td>
                                                                    <td style="width: 14px; height: 13px">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <asp:DropDownList ID="ddlTemplate" runat="server" Width="150px" OnSelectedIndexChanged="ddlTemplate_SelectedIndexChanged"
                                                                            AutoPostBack="True">
                                                                        </asp:DropDownList></td>
                                                                    <td valign="top">
                                                                    </td>
                                                                    <td style="width: 203px" valign="top">
                                                                        <asp:DropDownList ID="ddlHead" runat="server" Width="200px">
                                                                        </asp:DropDownList></td>
                                                                    <td valign="top">
                                                                        &nbsp;</td>
                                                                    <td valign="top">
                                                                        &nbsp;<asp:DropDownList ID="ddlValueType" runat="server" Width="120px">
                                                                            <asp:ListItem>Select</asp:ListItem>
                                                                            <asp:ListItem Value="1">% OF BASIC</asp:ListItem>
                                                                            <asp:ListItem Value="4">% OF(BASIC+DP)</asp:ListItem>
                                                                            <asp:ListItem Value="5">% OF(BAND+GRADE)</asp:ListItem>
                                                                            <asp:ListItem Value="2">FIXED</asp:ListItem>
                                                                            <asp:ListItem Value="3">MANUAL</asp:ListItem>
                                                                        </asp:DropDownList></td>
                                                                    <td valign="top">
                                                                        &nbsp;<asp:TextBox ID="txtValue" runat="server" Width="100px" CssClass="textbox"></asp:TextBox></td>
                                                                    <td style="width: 14px" valign="top">
                                                                        <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Width="80px" Text="Save"
                                                                            CssClass="btnBrown"></asp:Button></td>
                                                                </tr>
                        </table><br/><br/>
                         <table>
                            <tr>
                              <td style="vertical-align:top;">
                                <p>Earning Head</p>
                                <asp:GridView ID="gvEarnings" runat="server" Width="97%" 
                                                                            DataKeyNames="HEAD_MAPP_ID" AutoGenerateColumns="False" OnRowCommand="GridShow_RowCommand">
                                                                            <Columns>
                                                                                <asp:BoundField HeaderText="S#" />
                                                                                <asp:BoundField DataField="Head_NAME" HeaderText="Head Name" />
                                                                                <asp:BoundField DataField="TYPE" HeaderText="Type" HtmlEncode="False">
                                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField HeaderText="Value" DataField="HEAD_ENTRY_VALUE" />
                                                                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True"
                                                                                    HeaderText="Edit" >
                                                                                    <ItemStyle Width="35px" />
                                                                                </asp:CommandField>
                                                                                <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                                                                    <ItemStyle Width="20px" HorizontalAlign="Right" />
                                                                                    <ItemTemplate>
                                                                                        <asp:ImageButton ID="imgAct" runat="server" CausesValidation="false" CommandArgument='<%# Bind("HEAD_MAPP_ID") %>'
                                                                                            CommandName="Delete" ImageUrl='<%# Bind("STATUS_IMAGE") %>' Text="Button" OnRowCommand="GridShow_RowCommand" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>

                            </td>
                            <td style="vertical-align:top;">
                                <p>Deduction Head</p>
                                
                                <asp:GridView ID="gvDeductions" runat="server" Width="97%" 
                                                                            DataKeyNames="HEAD_MAPP_ID" AutoGenerateColumns="False"  OnRowCommand="GridShow_RowCommand">
                                                                            <Columns>
                                                                                <asp:BoundField HeaderText="S#" />
                                                                                <asp:BoundField DataField="Head_NAME" HeaderText="Head Name" />
                                                                                <asp:BoundField DataField="TYPE" HeaderText="Type" HtmlEncode="False">
                                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField HeaderText="Value" DataField="HEAD_ENTRY_VALUE" />
                                                                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" ShowSelectButton="True"
                                                                                    HeaderText="Edit" >
                                                                                    <ItemStyle Width="35px" />
                                                                                </asp:CommandField>
                                                                                <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                                                                    <ItemStyle Width="20px" HorizontalAlign="Right" />
                                                                                    <ItemTemplate>
                                                                                        <asp:ImageButton ID="imgAct" runat="server" CausesValidation="false" CommandArgument='<%# Bind("HEAD_MAPP_ID") %>'
                                                                                            CommandName="Delete" ImageUrl='<%# Bind("STATUS_IMAGE") %>' Text="Button"  OnRowCommand="GridShow_RowCommand" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>

                            </td>
                             </tr>
                          </table>

     </ContentTemplate>
     </asp:UpdatePanel>


</asp:Content>

