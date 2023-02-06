<%@ Page Title="ERP | Employee Designation Master" Language="C#" MasterPageFile="~/MasterPages/Short.master" AutoEventWireup="true" CodeFile="HeadMain.aspx.cs" Inherits="HR_DesignationMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">

        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == ".") {
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
           
         
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
    </script>
    <div class="container">
        <div class="heading">
            <h2>Head Main</h2>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <th>
                                        Head Type<span style="color: #ff0000">*</span></th>
                                    <td>
                                        &nbsp;</td>
                                    <th>
                                        Head Name<span style="color: #ff0000">*</span></th>
                                    <td>
                                        &nbsp;</td>
                                    <th>
                                        Short Name<span style="color: #ff0000">*</span></th>
                                    <td>
                                        &nbsp;</td>
                                    <th>
                                        In Calculate</th>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                    </td>
                                </tr>
                               <tr style="vertical-align: top;">
                                    <td>
                                        <asp:DropDownList ID="ddlHeadType" runat="server" Width="120px" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlHeadType_SelectedIndexChanged">
                                            <asp:ListItem Value=".">Select</asp:ListItem>
                                            <asp:ListItem Value="1">Earnings</asp:ListItem>
                                            <asp:ListItem Value="0">Deduction</asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        <asp:TextBox ID="txtHeadName" runat="server" MaxLength="50" Width="300px" CssClass="textbox" /></td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        <asp:TextBox ID="txtShortName" runat="server" CssClass="textbox" MaxLength="180"
                                            Width="150px"></asp:TextBox></td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        <asp:RadioButtonList ID="RlistCal" runat="server" CellPadding="0" CellSpacing="0"
                                            Font-Bold="True" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                        </asp:RadioButtonList></td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        <asp:Button ID="btnSave" runat="server" CssClass="btnCall" Text="Save" OnClick="btnSave_Click"
                                            Font-Overline="False"></asp:Button></td>
                                </tr>

                            </table>
                        </td>
                    </tr>


                    <tr>
                        <td> <div style="overflow: auto; width: 90%; height: 400px">
                            <asp:GridView ID="GridShow" runat="server" AutoGenerateColumns="False" Width="97%"
                                    DataKeyNames="HEAD_ID"  ShowHeader="true" OnRowCommand="GridShow_RowCommand">
                                    <Columns>
                                        <asp:BoundField HeaderText="S#" >
                                            <ItemStyle Width="15px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="HEAD_NAME" HeaderText="HEAD Name">
                                            <ItemStyle Width="260px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="HEAD_SHORT_NAME" HeaderText="Short Name">
                                            <ItemStyle Width="90px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="HEAD_TYPE_VALUE" HeaderText="TYPE">
                                            <ItemStyle Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ISCAL" HeaderText="IN CALCULATION" />
                                        <asp:CommandField ButtonType="Image" SelectImageUrl='~/Siteimages/edit.gif' ShowSelectButton="True" HeaderText="Edit"  >
                                            <ItemStyle Width="40px" />
                                        </asp:CommandField>
                                        <asp:TemplateField ShowHeader="False" HeaderText="Status">
                                            <ItemStyle Width="20px" HorizontalAlign="Right" />
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgAct" runat="server" CausesValidation="false" CommandArgument='<%# Bind("HEAD_ID") %>'
                                                    CommandName="Delete" ImageUrl='<%# Bind("STATUS_IMAGE")%>' Text="Button" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle BorderColor="#FFFFC0" Font-Size="Larger" Font-Underline="True" Wrap="True" />
                                    <SelectedRowStyle BackColor="#99FF33" />
                                    <HeaderStyle ForeColor="Blue" />
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>

