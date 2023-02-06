<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="PA03_Home.aspx.cs" Inherits="Appraisal_PA03_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
        function show_confirm() {
            var r = confirm("You have decided to mark the entries as final. You won't be able any further changes. Do you wish to continue?");
            if (r == true) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>
    <div class="container">
        <div class="heading">
            <h2>Performance Appraisal
            </h2>
        </div>

        <div>
            <table style="width: 80%; text-align: justify;">
                <tr>
                    <th style="text-align: center; font-size: 18px; color: red; border-bottom: 1px solid #000">Performa: PA03<br />
                        <span style="font-size: 18px; color: #0094ff;">Mangalayatan University
                        <br />
                            Faculty Performance Appraisal</span>
                        <br />
                        (<asp:Label ID="lblRFrom" runat="server"></asp:Label>
                        to <asp:Label ID="lblRTo" runat="server"></asp:Label>                        )                        
                    </th>
                </tr>


                <tr>
                    <td>
                        <ajaxToolkit:Accordion ID="Accordion1" runat="server" Width="950px" SelectedIndex="0" HeaderCssClass="accordionHeader" ContentCssClass="accordionContent" HeaderSelectedCssClass="accordionHeaderSelected"
                            AutoSize="None" FadeTransitions="true" TransitionDuration="250" FramesPerSecond="40" RequireOpenedPane="false" SuppressHeaderPostbacks="true">
                            <Panes>
                                <ajaxToolkit:AccordionPane runat="server" ID="AccordionPane1">
                                    <Header>Objective</Header>
                                    <Content>
                                        &nbsp;&nbsp;&nbsp;&nbsp;Faculty Performance Appraisal is a vital practice in any progressive educational institution. It is conducted regularly to assess the performance of any individual during the stated period.
        It is an exercise recommended by the all national and the international regulatory bodies as it gives a faculty member a chance to present his achievements and the university administration a chance to highlight expected improvements, both leading to an individual’s career advancement.<br />
                                        <br />
                                        &nbsp; Performance of faculty is assessed by measuring the involvement of the individual in various duty sectors, namely, academics (teaching and research), administrative (departmental/institute/university level), organization/participation in extra/co-curricular activities related to students and faculty. I encourage you to state your contributions clearly and honestly, leading to a rewarding exchange of views between you and your reviewing officers.<br />
                                    </Content>
                                </ajaxToolkit:AccordionPane>


                                <ajaxToolkit:AccordionPane ID="AccordionPane2" runat="server">
                                    <Header>Procedure</Header>
                                    <Content>
                                        •	There are  8-attributes to be filled to complete the appraisal. Details of these attributes can be retrieved by clicking the corresponding  STEP links.
            <br />
                                        •	Filled information can be saved by clicking  <span style="color: Red; font-weight: bold">‘Save’</span> button wherever it appears.<br />
                                        •	The appraisal can be filled in one or more sittings.
                        <br />
                                        •	After completion of all the steps (filling all the attributes) , the appraisal form can be submitted by clicking the button <span style="color: Red; font-weight: bold">[Mark As Final] </span>given after Report link.<br />
                                        •	After submission (clicking <span style="color: Red; font-weight: bold">[Mark As Final] </span>) you won't be able to make any further changes.<br />
                                        •	Clicking <span style="color: Red; font-weight: bold">[Mark As Final]</span> will forward the report to your Dean/Director.<br />


                                    </Content>
                                </ajaxToolkit:AccordionPane>
                                <ajaxToolkit:AccordionPane ID="AccordionPane3" runat="server">
                                    <Header>Attributes to be filled...</Header>
                                    <Content>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:HyperLink ID="link1" runat="server">
                                                        <asp:Label ID="lblHeader1" runat="server" CssClass="mactive"></asp:Label>
                                                    </asp:HyperLink>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblDescription1" runat="server" CssClass="paTopDesc"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:HyperLink ID="link2" runat="server">
                                                        <asp:Label ID="lblHeader2" runat="server" CssClass="mactive"></asp:Label>
                                                    </asp:HyperLink>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblDescription2" runat="server" CssClass="paTopDesc"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:HyperLink ID="link3" runat="server">
                                                        <asp:Label ID="lblHeader3" runat="server" CssClass="mactive"></asp:Label>
                                                    </asp:HyperLink>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblDescription3" runat="server" CssClass="paTopDesc"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:HyperLink ID="link4" runat="server">
                                                        <asp:Label ID="lblHeader4" runat="server" CssClass="mactive"></asp:Label>
                                                    </asp:HyperLink>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblDescription4" runat="server" CssClass="paTopDesc"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:HyperLink ID="link5" runat="server">
                                                        <asp:Label ID="lblHeader5" runat="server" CssClass="mactive"></asp:Label>
                                                    </asp:HyperLink>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblDescription5" runat="server" CssClass="paTopDesc"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:HyperLink ID="link6" runat="server">
                                                        <asp:Label ID="lblHeader6" runat="server" CssClass="mactive"></asp:Label>
                                                    </asp:HyperLink>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblDescription6" runat="server" CssClass="paTopDesc"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:HyperLink ID="link7" runat="server">
                                                        <asp:Label ID="lblHeader7" runat="server" CssClass="mactive"></asp:Label>
                                                    </asp:HyperLink>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblDescription7" runat="server" CssClass="paTopDesc"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:HyperLink ID="link8" runat="server">
                                                        <asp:Label ID="lblHeader8" runat="server" CssClass="mactive"></asp:Label>
                                                    </asp:HyperLink>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblDescription8" runat="server" CssClass="paTopDesc"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </Content>
                                </ajaxToolkit:AccordionPane>
                            </Panes>
                        </ajaxToolkit:Accordion>
                    </td>
                </tr>
                <tr>
                    <th></th>
                </tr>

                <tr>
                    <td class="accordionHeader">

                        <asp:HyperLink ID="linkReport" runat="server" Text="Report" Font-Bold="true" Font-Size="14px" ForeColor="White">
                        
                        </asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>

                        <asp:Button ID="btnMark" runat="server" OnClientClick="return show_confirm()" Text="Mark As Final" OnClick="btnMark_Click" />
                        <span style="font-size: 14px; color: red;font-weight:bold">Last day to fill this appraisal is <asp:Label ID="lblLastDate" runat="server"></asp:Label></span>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

