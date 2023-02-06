<%@ Page Language="C#" AutoEventWireup="true" CodeFile="prtGatePass.aspx.cs" Inherits="Inventory_prtGatePass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gate Pass</title>
    <style type="text/css">
        .auto-style1 {
            width: 579px;
        }

        .auto-style2 {
            height: 18px;
            width: 579px;
        }

        .auto-style4 {
            width: 273px;
        }

        .auto-style6 {
            width: 227px;
        }

        .auto-style7 {
            width: 293px;
        }
        .auto-style8 {
            width: 272px;
        }
    </style>
</head>
<body onload="window.print();" oncontextmenu="return false" ondragstart="return false"
    onselectstart="return false">
    <form id="form1" runat="server">
        <table cellspacing="0" style="font-family: Arial; font-size: 10pt; width: 650px">
            <tr>
                <td>
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td align="left" style="width: 50%" valign="top">
                                <img src="../Siteimages/mu_logo.jpg" alt="" style="width: 300px; height: 100px" /></td>
                            <td width="45%">
                                <p style="margin-top: 0; margin-bottom: 0">
                                    &nbsp;
                                </p>
                                <p style="margin-top: 0; margin-bottom: 0">
                                    &nbsp;
                                </p>
                                <p style="margin-top: 0; margin-bottom: 0">
                                    &nbsp;
                                </p>
                                <p style="margin-top: 0; margin-bottom: 0" align="right">
                                    <font face="Tahoma" size="2">Extended NCR, Aligarh-Mathura Highway</font>
                                </p>
                                <p style="margin-top: 0; margin-bottom: 0" align="right">
                                    <font face="Tahoma" size="2">Beswan, Aligarh-202145, India</font>
                                </p>
                                <p style="margin-top: 0; margin-bottom: 0" align="right">
                                    Cont.<font face="Tahoma" size="2">: +91-8393878627 </font>
                                </p>
                                <p style="margin-top: 0; margin-bottom: 0" align="right">
                                    <font face="Tahoma" size="2">Website: www.mangalayatan.in</font>
                                </p>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: center">
                    <span style="font-size: 14pt;">GATE-PASS(<asp:Label ID="lblType" runat="server"></asp:Label>)</span></td>

            </tr>
            <tr>
                <td style="text-align: left; ">Gate Pass No :<b><asp:Label ID="lblGatePass" runat="server" Font-Bold="True" /></b></td>
            </tr>
            <tr>
                <td>
                    <table style="width: 653px">
                        <tr>
                            <td >Name :<asp:Label ID="lblName" runat="server"  /></td>

                            <td style="text-align: left" >Date :<asp:Label ID="lblDate" runat="server" /></td>
                         <%--   <td style="text-align: left">Time :<asp:Label ID="lblTime" runat="server" /></td>--%>
                        </tr>
                        <tr id="rowDesc" runat="server">
                            <td  colspan="3">Description :<asp:Label ID="lbldesc" runat="server" /></td>
                        </tr>
                        <tr id="rowUnivEmp" runat="server">
                            <td >Designation :<asp:Label ID="lblDesignation" runat="server"  /></td>
                            
                            <td >Institute/ Department :<asp:Label ID="lblDept" runat="server" /></td>


                        </tr>
                        <tr id="rowRtnDate" runat="server">



                            <td  colspan="3">Return Date :<asp:Label ID="lblRtnDate" runat="server"  /></td>

                        </tr>
                        <tr >
              
                <td  colspan="3" >Recipient:<asp:Label ID="lblRecpt" runat="server"  />
                </td>
            </tr>
                      <tr id="row_Ven_Cont" runat="server" >
                            <td>
                                Contact:<asp:Label ID="lblVen_Mob" runat="server"></asp:Label>
                            </td>
                        </tr>  
                    </table>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="False"
                        ShowFooter="false" CellPadding="3" CssClass="lblblack" Width="500px" Style="margin-left: 60px">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No.">
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="ITEM_NAME" HeaderText="Item Name">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="QTY" HeaderText="Qty">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="REMARK" HeaderText="Remark">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SENDER" HeaderText="Sender">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                        </Columns>
                        <FooterStyle Font-Bold="True" HorizontalAlign="Right" />
                    </asp:GridView>
                </td>
            </tr>



            <tr>
                <td class="auto-style1">&nbsp;</td>
            </tr>

            <tr>
                <td class="auto-style2">The above mentioned materials are hereby requested to be passed through main gate of University on 
                       <b> <asp:Label ID="lblType1" runat="server"></asp:Label></b> basis.
                </td>
            </tr>


            <tr>
                <td class="auto-style1">&nbsp;</td>
            </tr>

            <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                                <b>
                                    <asp:Label ID="lblAuthBy" runat="server"></asp:Label></b>
                            </td>
                        </tr>
                         <tr>
                            <td>
                                <b>
                                    Contact:<asp:Label ID="lbl_AUTH_MOB" runat="server"></asp:Label></b>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 280px">Authorised By</td>
                            <td style="width: 220px">Security</td>
                            <td style="width: 200px">Signature of HOD</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
