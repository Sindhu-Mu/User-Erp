<%@ Control Language="C#" AutoEventWireup="true" CodeFile="dropmenu.ascx.cs" Inherits="control_dropmenu" EnableViewState="false" %>
 <table style="width: 100%">
                                                <tr>
                                                    <td>
                                                        <a class="aBlueMenu" href="javascript:void(0)" runat="server" id="linkDropMenu">Side Info........</a>
                                                    </td>
                                                    <td>
                                                        <asp:Panel ID="panelDropMenu" runat="server" CssClass="menuPanel">
                                                            <table class="classElements">
                                                                <tr>
                                                                    <td>
                                                                        <a href="javascript:void(0)" class="aBlackMenu">Privacy</a></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <a href="javascript:void(0)" class="aBlackMenu">Feeds</a></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <a href="javascript:void(0)" class="aBlackMenu">Privacy</a></td>
                                                                </tr>
                                                                
                                                                <tr>
                                                                    <td>
                                                                        <asp:LinkButton ID="btnLogout" runat="server" Text="Logout" CssClass="aBlackMenu" OnClick="btnLogout_Click" /></td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <ajaxToolkit:DropDownExtender ID="TextBox1_DropDownExtender" runat="server" DynamicServicePath=""
                                                            Enabled="True" DropDownControlID="panelDropMenu" TargetControlID="linkDropMenu">
                                                        </ajaxToolkit:DropDownExtender>
                                                    </td>
                                                </tr>
                                            </table>
