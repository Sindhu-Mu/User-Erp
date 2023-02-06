<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="TemplateMain.aspx.cs" Inherits="PayRoll_Sal_Template_Master" %>

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
             if (!CheckControl("<%=txtTempName.ClientID%>")) {
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
    <h3>Salary Template Master</h3>
    <hr/>
<table>
    <tr>
        <td>Template Name*</td>
        <td>Description</td>
    </tr>
     <tr>
        <td><asp:TextBox ID="txtTempName" runat="server"></asp:TextBox></td>
        <td><asp:TextBox ID="txtTempDescription" runat="server"></asp:TextBox></td>
        <td><asp:Button Text="Add Template" ID="btnAddTemplate" runat="server" OnClick="btnSave_Click"/></td>
    </tr>
</table><br/><br/>
    <asp:GridView ID="GridShow" runat="server" AutoGenerateColumns="False" 
                                 Width="80%" DataKeyNames="SAL_TEMPLATE_ID"   style="margin-top: 0px" CssClass="gridDynamic" Caption="Templates" onrowcommand="GridShow_RowCommand">
                            <Columns>
                                <asp:BoundField HeaderText="S#" >
                                    <ItemStyle Width="15px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SAL_TEMPLATE_NAME" HeaderText="TEMPLATE" >
                                    <ItemStyle Width="300px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SAL_TEMPLATE_DESC" HeaderText="Short Name" >
                                    <ItemStyle Width="100px" />
                                </asp:BoundField>
                              
                                <asp:BoundField DataField="SAL_TEMPLATE_DT" HeaderText="DATE" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false"  >
                                    <ItemStyle Width="80px" />
                                </asp:BoundField>
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Siteimages/edit.gif" 
                                    ShowSelectButton="True"  HeaderText="Edit">
                                    <ItemStyle Width="40px" />
                                </asp:CommandField>
                                      <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                            <ItemStyle Width="20px" HorizontalAlign="Right" />
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgAct" runat="server" CausesValidation="false" CommandArgument='<%# Bind("SAL_TEMPLATE_ID") %>'
                                                   ></asp:ImageButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                            </Columns>
                            <PagerStyle BorderColor="#FFFFC0"  Font-Size="Larger" 
                                     Font-Underline="True" Wrap="True" />
                                 <SelectedRowStyle BackColor="#99FF33" />
                                 <HeaderStyle ForeColor="Blue" />
                        </asp:GridView>
     </ContentTemplate>
     </asp:UpdatePanel>


</asp:Content>

