<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prtAllIssue.aspx.cs" Inherits="IssueTracking_prtAllIssue" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Issue Detail</title>
    <style>
        th {
            text-align: left;
        }
    </style>
</head>
<body onload="window.print();">
    <form id="form1" runat="server">

        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <div>

                    <table style="width: 100%; margin-top: 20px;">

                        <tr>
                            <td style="text-align: center;">
                                <img alt="print" src="../Siteimages/PrintLogo.png" /></td>
                        </tr>
                        <tr>
                            <th style="font-size: 25px; text-align: center;">

                                <u>Issue Detail</u><br />

                                <br />
                            </th>
                        </tr>


                        <tr >
                            <td style="border-bottom: 1px black solid; font-size: 20px;">
                                <table style="width: 100%;">
                                    <tr>
                                        <td>Token No :# <%# DataBinder.Eval(Container.DataItem, "ISSUE_TOKEN_NO") %>
                                
                                        </td>
                                        <td>Status:# <%# DataBinder.Eval(Container.DataItem, "ISSUE_STS_VALUE") %></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>

                        <tr style="text-align: left;">
                            <td>
                                <table>
                                    <tr>
                                        <th>From: </th>
                                        <td><%# DataBinder.Eval(Container.DataItem, "EMP_NAME") %></td>
                                    </tr>
                                    <tr>
                                        <th>Mobile No:</th>
                                        <td><%# DataBinder.Eval(Container.DataItem, "Mobile_Off") %></td>
                                    </tr>
                                    <tr>
                                        <th>Department: </th>
                                        <td>
                                            <%# DataBinder.Eval(Container.DataItem, "DEPT_VALUE") %> 
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>Building: </th>
                                        <td>
                                            <%# DataBinder.Eval(Container.DataItem, "FAC_CMPLX_NAME") %>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>Location: </th>
                                        <td>
                                            <%# DataBinder.Eval(Container.DataItem, "ISSUE_LOCATION") %>    
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>Complain about: </th>
                                        <td>
                                            <%# DataBinder.Eval(Container.DataItem, "SUB_HEAD_VALUE") %>       
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>Posted On: </th>
                                        <td>
                                            <%# DataBinder.Eval(Container.DataItem, "ISSUE_DT") %>  
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <th>Complain Details</th>
                        </tr>
                        <tr>
                            <td><%# DataBinder.Eval(Container.DataItem, "ISSUE_DETAIL") %>  
                            </td>
                        </tr>
                        <tr>
                            <th>ASSIGN DETAIL
                        
                            </th>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvAssign" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic" DataKeyNames="ISSUE_TRANSFER_ID">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No.">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                            </ItemTemplate>
                                            <ItemStyle Width="50px" />
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Assign To" DataField="EMP_NAME" />
                                        <asp:BoundField HeaderText="Assign Remark" DataField="TRANSFER_REMARK" />
                                        <asp:BoundField HeaderText="Assign Date" DataField="TRANSFER_DT" DataFormatString="{0:dd/MM/yyyy}" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <th>RESPONSE DETAIL
                        <hr />
                            </th>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="False" DataKeyNames="ISSUE_DET_ID">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No.">
                                            <ItemTemplate>
                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                            </ItemTemplate>
                                            <ItemStyle Width="15px" />
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Work Description" DataField="WORK_DETAIL">
                                            <ItemStyle Width="300px" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Meterial Used" DataField="MATERIAL_USED">
                                            <ItemStyle Width="200px" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Action Date" DataField="SRT_DT" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:BoundField HeaderText="Action By" DataField="EMP_NAME" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
                <hr style='visibility: hidden; page-break-after: always' />
            </ItemTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
