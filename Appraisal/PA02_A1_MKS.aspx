<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PA02_A1_MKS.aspx.cs" Inherits="Appraisal_PA02_A1_MKS" %>

<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <title>CURRICULUM</title>
    <link href="../css/Main.css" type="text/css" rel="stylesheet" />
</head>

<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="mngUser1" runat="server">
        </asp:ScriptManager>
        <div class="heading">
            <h2>STUDENT'S FEEDBACK ON <span style="color:red">CURRICULUM</span>
            </h2>
        </div>
        <div class="container">

            <div style="width:100%;">
                <asp:GridView ID="gvParameter" runat="server" AutoGenerateColumns="False" 
                    CssClass="gridDynamic" Font-Size="15px"   Width="99%">
                    <Columns>
                        <asp:BoundField DataField="PA02_E_PARAM_ID" HeaderText="S.No.">
                            <ItemStyle Width="5%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PA02_E_PARAM_VALUE" HeaderText="Question">
                            <ItemStyle Width="40%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PA02_E_PARAM_DESC" HeaderText="Question">
                            <ItemStyle Width="40%"  />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Answer">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlMarks" runat="server" Width="100%">
                                    <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                    <asp:ListItem Text="Strongly Agree(अत्याधिक सहमत)" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="Mostly Agree(आंशिक रूप से सहमत)" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="Average(औसत)" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="Disagree(असहमत)" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Completely Disagree(पूरी तरह से असहमत)" Value="1"></asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                            <ItemStyle Width="15%" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div style="padding-right:40%;padding-left:40%;width:100%;">
                <asp:Button ID="btnSave" Text="Submit & Move to Course Faculty" runat="server" Height="25px" OnClick="btnSave_Click" />
                <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
            </div>
        </div>
    </form>
</body>
</html>
