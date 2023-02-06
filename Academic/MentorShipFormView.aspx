<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="MentorShipFormView.aspx.cs" Inherits="Academic_MentorShipFormView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
        function CallPrint(strid) {
            var prtContent = document.getElementById(strid);
            var WinPrint = window.open('', '', 'letf=0,top=0,width=800,height=700,toolbar=0,scrollbars=0,status=0,dir=ltr');
            WinPrint.document.write(prtContent.innerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
            //prtContent.innerHTML = strOldOne;
        }
    </script>

    <div class="container">
        <div class="heading">
        </div>
        <div style="margin-left: 20px;" id="printDiv1">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>




                    <%-- Start Main Div--%>
                    <div id="main" style="width: 700px">

                        <%--Start Div For Header--%>
                        <div style="height: 120px">
                            <table>
                                <tr>
                                    <td style="width: 100px;">
                                        <img runat="server" id="img_logo" src="~/images/Mangalayatan-University.jpg" style="height: 100px; width: 80px; margin: 10px" />
                                    </td>
                                    <td style="width: 500px; text-align: center">
                                        <span style="font-weight: bold; font-family: 'Times New Roman'; font-size: 22px">MANGALAYATAN  UNIVERSITY</span><br />
                                        <span style="font-weight: bold; font-family: 'Times New Roman'; font-size: 22px">
                                            <asp:Label ID="lblInst" runat="server"></asp:Label></span><br />
                                        <span style="font-weight: bold; font-family: 'Times New Roman'; font-size: 22px">Student Mentoring Report</span>
                                    </td>
                                    <td style="width: 100px;">

                                        <img id="imgPicture" runat="server" alt="Image" src="~/images/Stuimages/" style="width: 100px; height: 100px; margin: 10px" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <%--End Div For Header--%>


                        <%-- Start Table for Name, detail & Contact--%>
                        <table style="width: 100%; border: 1px solid black; border-collapse: collapse;">
                            <tr>
                                <td style="width: 140px; border: 1px solid black">
                                    <strong>ENROLLMENT NO. </strong>
                                </td>
                                <td style="width: 195px; border: 1px solid black">
                                    <asp:Label runat="server" ID="lblEnroll"></asp:Label>
                                </td>
                                <td style="width: 140px; border: 1px solid black">
                                    <strong>MENTEE NAME </strong>
                                </td>
                                <td style="border: 1px solid black">
                                    <asp:Label runat="server" ID="lblMentee"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px; border: 1px solid black">
                                    <strong>PROGRAM</strong></td>
                                <td style="width: 195px; border: 1px solid black">
                                    <asp:Label runat="server" ID="lblProgram"></asp:Label>
                                </td>
                                <td style="width: 140px; border: 1px solid black">
                                    <strong>BRANCH</strong>
                                </td>
                                <td style="border: 1px solid black">
                                    <asp:Label runat="server" ID="lblBranch"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 140px; border: 1px solid black">
                                    <strong>SEMESTER</strong>
                                </td>
                                <td style="width: 195px; border: 1px solid black">
                                    <asp:Label runat="server" ID="lblSem"></asp:Label>
                                </td>
                                <td style="width: 140px; border: 1px solid black">
                                    <strong>SECTION</strong>
                                </td>
                                <td style="width: 195px; border: 1px solid black">
                                    <asp:Label runat="server" ID="lblSection"></asp:Label>
                                </td>

                            </tr>
                            <tr>
                                <td style="width: 140px; border: 1px solid black;">
                                    <strong>MENTOR NAME</strong>
                                </td>
                                <td style="border: 1px solid black;">
                                    <asp:Label runat="server" ID="lblMentor"></asp:Label>
                                </td>
                                <td style="width: 140px; border: 1px solid black;">
                                    <strong>CONTACT STUDENT</strong>
                                </td>
                                <td style="width: 195px; border: 1px solid black;">
                                    <asp:Label runat="server" ID="lblContStu"></asp:Label>
                                </td>

                            </tr>

                            <tr>
                                <td style="width: 140px; border: 1px solid black;" rowspan="2">
                                    <strong>CONTACT</strong> <strong>PARENT</strong>
                                </td>
                                <td style="border: 1px solid black;" rowspan="2">
                                    <asp:Label runat="server" ID="lblContPart"></asp:Label>
                                </td>
                                <td rowspan="2" style="width: 140px; border: 1px solid black;">
                                    <strong>ADDRESS</strong></td>
                                <td rowspan="2" style="width: 195px; border: 1px solid black;">
                                    <asp:Label runat="server" ID="lblAddress"></asp:Label>
                                </td>


                            </tr>
                          </table>
                          <table style=" width:100%; margin-top:8px">
                              <tr>
                                  <th style="text-align:center;"><span style="font-weight: normal; text-decoration: underline"><strong>Previous Education Details</strong></span></th>
                              </tr>
                          </table>
                                    <asp:GridView ID="gvPrevQuali" runat="server"  AutoGenerateColumns="false" CssClass="gridDynamic" EmptyDataText="No Records Found" Width="700px">
                                         <HeaderStyle Font-Bold="true" Font-Size="14px"   ForeColor="black" />
                                        <Columns>

                                            <asp:BoundField DataField="ACA_BASE_FULL_NAME" HeaderText="Qualification" />
                                            <asp:BoundField DataField="PRSNT" HeaderText="Percentage" />
                                            <%--<asp:BoundField DataField="STU_FULL_NAME" HeaderText="Name" />--%>
                                        </Columns>
                                    </asp:GridView>
                               
                      
                        <%--End Table for Name, detail & Contact--%>
                           <table style=" width:100%; margin-top:8px">
                              <tr>
                                  <th style="text-align:center;"><span style="font-weight: normal; text-decoration: underline"><strong>Student Tracking Report</strong></span></th>
                              </tr>
                          </table>
                        <div id="DIV_SEM_MARKS">
                            <asp:GridView ID="gvSemResult" runat="server" AutoGenerateColumns="False"
                                CssClass="gridDynamic" Width="700px">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                        </ItemTemplate>
                                        <ItemStyle Width="50px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="COL" HeaderText="Parameter" />
                                    <asp:BoundField DataField="SEM1" HeaderText="I" />
                                    <asp:BoundField DataField="SEM2" HeaderText="II" />

                                    <asp:BoundField DataField="SEM3" HeaderText="III" />
                                    <asp:BoundField DataField="SEM4" HeaderText="IV" />
                                    <asp:BoundField DataField="SEM5" HeaderText="V" />
                                    <asp:BoundField DataField="SEM6" HeaderText="VI" />
                                    <asp:BoundField DataField="SEM7" HeaderText="VII" />

                                    <asp:BoundField DataField="SEM8" HeaderText="VIII" />
                                    <asp:BoundField DataField="SEM9" HeaderText="IX" />
                                    <asp:BoundField DataField="SEM10" HeaderText="X" />
                                </Columns>
                                <HeaderStyle BackColor="#000000" ForeColor="#000099" />
                            </asp:GridView>
                        </div>

                        <%--PREVIOUSE BACK--%>
                        <%--<table style=" width:100%">
                              <tr>
                                  <th style="text-align:center;"><span style="font-weight: normal; text-decoration: underline"><strong>Previous Back Paper Details(if any)</strong></span></th>
                              </tr>
                          </table>--%>
                        <div id="div_Back">
                            <asp:GridView ID="gvBack" runat="server" AutoGenerateColumns="False" Caption="Previous Back Paper Details(if any)"
                                CssClass="gridDynamic" Width="700px" EmptyDataText="No Record Exists">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                        </ItemTemplate>
                                        <ItemStyle Width="50px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="COL" HeaderText="Parameter" />
                                    <asp:BoundField DataField="SEM1" HeaderText="I" />
                                    <asp:BoundField DataField="SEM2" HeaderText="II" />

                                    <asp:BoundField DataField="SEM3" HeaderText="III" />
                                    <asp:BoundField DataField="SEM4" HeaderText="IV" />
                                    <asp:BoundField DataField="SEM5" HeaderText="V" />
                                    <asp:BoundField DataField="SEM6" HeaderText="VI" />
                                    <asp:BoundField DataField="SEM7" HeaderText="VII" />

                                    <asp:BoundField DataField="SEM8" HeaderText="VIII" />
                                    <asp:BoundField DataField="SEM9" HeaderText="IX" />
                                    <asp:BoundField DataField="SEM10" HeaderText="X" />
                                </Columns>
                                <HeaderStyle BackColor="#000000" ForeColor="#000099" />
                            </asp:GridView>
                        </div>
                        <table style=" width:100%;  margin-top:8px">
                              <tr>
                                  <th style="text-align:center;"><span style="font-weight: normal; text-decoration: underline"><strong>Attendance Percentage</strong></span></th>
                              </tr>
                          </table>
                        <div style="width: 700px" id="div_Attendance_Marks">
                           

                            <asp:GridView ID="gvAttendance" runat="server" AutoGenerateColumns="False" 
                                CssClass="gridDynamic" Width="700px">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                        </ItemTemplate>
                                        <ItemStyle Width="50px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="EVA_SCH_PAPER_CODE" HeaderText="Subject Code" />
                                    <asp:BoundField DataField="ACA_SUB_NAME" HeaderText="Subject Name" />

                                    <asp:BoundField DataField="PER_M1" HeaderText="Minor-I" />
                                    <asp:BoundField DataField="PER_M2" HeaderText="Minor-II" />
                                    <asp:BoundField DataField="PER_MAJOR" HeaderText="Major" />
                                </Columns>
                                <HeaderStyle BackColor="#000000" ForeColor="#000099" />
                            </asp:GridView>
<hr style="visibility: hidden; page-break-after: always" />
                            <asp:Chart ID="Chart1" runat="server" BorderlineWidth="0" Width="650px">
                                <Series>
                                    <asp:Series Name="Series1" XValueMember="EVA_SCH_PAPER_CODE" YValueMembers="PER_M1"
                                        LegendText="Minor-I" IsValueShownAsLabel="false" ChartArea="ChartArea1"
                                        MarkerBorderColor="#0066cc">
                                    </asp:Series>

                                    <asp:Series Name="Series2" XValueMember="EVA_SCH_PAPER_CODE" YValueMembers="PER_M2"
                                        LegendText="Minor-II" IsValueShownAsLabel="false" ChartArea="ChartArea1"
                                        MarkerBorderColor="#ff3300">
                                    </asp:Series>

                                    <asp:Series Name="Series3" XValueMember="EVA_SCH_PAPER_CODE" YValueMembers="PER_MAJOR"
                                        LegendText="Major" IsValueShownAsLabel="false" ChartArea="ChartArea1"
                                        MarkerBorderColor="#0066cc">
                                    </asp:Series>

                                </Series>
                                <Legends>
                                    <asp:Legend Title="Attendance">
                                    </asp:Legend>
                                </Legends>
                                <Titles>
                                    <asp:Title Docking="Bottom" Text="Attendance Status"></asp:Title>
                                </Titles>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                </ChartAreas>
                            </asp:Chart>
                            

                            <table style=" width:100%;margin-top:30px; margin-bottom:20px">
                              <tr>
                                  <th style="text-align:center;"><span style="font-weight: normal; text-decoration: underline"><strong>Academic Profile</strong></span></th>
                              </tr>
                          </table>
                            <asp:GridView ID="gvMarks" runat="server" AutoGenerateColumns="False"
                                CssClass="gridDynamic" Width="700px">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                        </ItemTemplate>
                                        <ItemStyle Width="50px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="EVA_SCH_PAPER_CODE" HeaderText="Subject Code" />
                                    <asp:BoundField DataField="SUBJECT" HeaderText="Subject Name" />

                                    <asp:BoundField DataField="M1" HeaderText="Minor-I" />
                                    <asp:BoundField DataField="M2" HeaderText="Minor-II" />
                                    <asp:BoundField DataField="MAJOR" HeaderText="Major" />

                                </Columns>
                                <HeaderStyle BackColor="#000000" ForeColor="#000099" />
                            </asp:GridView>
                            <asp:Chart ID="Chart2" runat="server" BorderlineWidth="0" Width="650px">
                                <Series>
                                    <asp:Series Name="Series1" XValueMember="EVA_SCH_PAPER_CODE" YValueMembers="M1"
                                        LegendText="Minor-I" IsValueShownAsLabel="false" ChartArea="ChartArea2"
                                        MarkerBorderColor="#0066cc">
                                    </asp:Series>

                                    <asp:Series Name="Series2" XValueMember="EVA_SCH_PAPER_CODE" YValueMembers="M2"
                                        LegendText="Minor-II" IsValueShownAsLabel="false" ChartArea="ChartArea2"
                                        MarkerBorderColor="#ff3300">
                                    </asp:Series>

                                    <asp:Series Name="Series3" XValueMember="EVA_SCH_PAPER_CODE" YValueMembers="MAJOR"
                                        LegendText="Major" IsValueShownAsLabel="false" ChartArea="ChartArea2"
                                        MarkerBorderColor="#0066cc">
                                    </asp:Series>

                                </Series>
                                <Legends>
                                    <asp:Legend Title="Marks">
                                    </asp:Legend>
                                </Legends>
                                <Titles>
                                    <asp:Title Docking="Bottom" Text="Marks Status"></asp:Title>
                                </Titles>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea2"></asp:ChartArea>
                                </ChartAreas>
                            </asp:Chart>
                        </div>

                        <%-----------------------------------------------------------------------------------------%>
                         <hr style="visibility: hidden; page-break-after: always" />
                        <%--Start Div For Achievements--%>
                        <div>
                            <%--Start table For Achievements--%>
                            <table style=" width:100%">
                              <tr>
                                  <th style="text-align:center;"><span style="font-weight: normal; text-decoration: underline"><strong>Achievements(If Any)</strong></span></th>
                              </tr>
                          </table>

                            <asp:GridView ID="GvAdd" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" EmptyDataText="No Achievement Added" Width="700px">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1%>.
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Achievement" HeaderText="Achievements" />
                                    <%--<asp:BoundField DataField="STU_FULL_NAME" HeaderText="Name" />--%>
                                </Columns>
                            </asp:GridView>

                            <%--End table For Achievements--%>

                            <%--End Div For Achievements--%>
                        </div>

                        <%--Start Div For Behaviour/Parent--%>
                        <div>
                            <%--Start table For Behaviour/Parent--%>

                            <table style="width: 100%; border: 1px solid black; border-collapse: collapse;">
                                <tr>
                                    <td style="text-align: left; width: 350px"><b>Behaviour</b></td>

                                    <td style="text-align: left; width: 350px"><b>Parents to be called</b></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:RadioButtonList ID="rdoBehaviour" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="0">Satisfactory</asp:ListItem>
                                            <asp:ListItem Value="1">Unsatisfactory</asp:ListItem>

                                        </asp:RadioButtonList></td>


                                    <td>
                                        <asp:RadioButtonList ID="rdoParents" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="0">Yes</asp:ListItem>
                                            <asp:ListItem Value="1">No</asp:ListItem>

                                        </asp:RadioButtonList></td>
                                </tr>
                                <%--End table For Behaviour/Parent--%>
                            </table>


                            <%--End Div For Behaviour/Parent--%>
                        </div>

                        <%--Start Div For Parent Comments--%>
                        <div>
                            <%--Start table For Parent Comments--%>
                            <table style="width: 100%; border: 1px solid black; border-collapse: collapse;">

                                <tr>
                                    <td><b>Parent(s)/Gaurdian(s) Comments:</b></td>
                                </tr>
                                <tr>
                                    <td style="height: 50px"></td>
                                </tr>
                                <%--End table For Parent Comments--%>
                            </table>
                            <%--End Div For Parent Comments--%>
                        </div>
                       
                        <%--Start Div For Mentor Suggestion--%>
                        <div style="text-align: center">
                            <br />
                            <%--Start table For  Mentor Suggestion--%>
                            <strong>Mentor Suggestions for Improvements </strong>

                           <table style=" width:100%">
                              <tr>
                                  <th style="text-align:center;"><span style="font-weight: normal; text-decoration: underline"><strong>(a)Attendance</strong></span></th>
                              </tr>
                          </table>

                            <asp:GridView ID="gvAttSugg" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" EmptyDataText="No Suggestions Added" Width="700px">
                                <Columns>

                                    <asp:BoundField DataField="EXAM_ID" HeaderText="EXAM TYPE" />
                                    <asp:BoundField DataField="ATT_RMK" HeaderText="SUGGESTIONS" />

                                </Columns>
                            </asp:GridView>

                            <table style=" width:100%">
                              <tr>
                                  <th style="text-align:center;"><span style="font-weight: normal; text-decoration: underline"><strong>(b)Academic</strong></span></th>
                              </tr>
                          </table>

                            <asp:GridView ID="gvAcaSugg"  runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" EmptyDataText="No Suggestions Added" Width="700px">
                                <Columns>

                                    <asp:BoundField DataField="EXAM_ID" HeaderText="EXAM TYPE" />
                                    <asp:BoundField DataField="ACA_RMK" HeaderText="SUGGESTIONS" />

                                </Columns>
                            </asp:GridView>
                             <table style=" width:100%">
                              <tr>
                                  <th style="text-align:center;"><span style="font-weight: normal; text-decoration: underline"><strong>(C)Behaviour</strong></span></th>
                              </tr>
                          </table>


                            <asp:GridView  ID="gvBehSugg" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" EmptyDataText="No Suggestions Added" Width="700px">
                                <Columns>

                                    <asp:BoundField DataField="EXAM_ID" HeaderText="EXAM TYPE" />
                                    <asp:BoundField DataField="BEH_RMK" HeaderText="SUGGESTIONS" />

                                </Columns>
                            </asp:GridView>

                            <%--End Div For  Mentor Suggestion--%>
                        </div>
                        <%--Start Div For Mentee Visit--%>
                        <div>

                             <table style=" width:100%">
                              <tr>
                                  <th style="text-align:center;"><span style="font-weight: normal; text-decoration: underline"><strong>Mentee Visit Record(Other Than Shedule)</strong></span></th>
                              </tr>
                          </table>
                            <%--Start table For  Mentee Visit--%>


                            <asp:GridView  ID="gvMentee" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" EmptyDataText="No Suggestions Added" Width="700px">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%# ((GridViewRow)Container).RowIndex + 1%>.
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="VISITDATE" HeaderText="DATE" />
                                    <asp:BoundField DataField="PURPOSE" HeaderText="PURPOSE OF VISIT" />
                                    <asp:BoundField DataField="SUGGESTION" HeaderText="SUGGESTION" />
                                    <%--<asp:BoundField DataField="STU_FULL_NAME" HeaderText="Name" />--%>
                                </Columns>
                            </asp:GridView>

                            <%--End table For Mentee Visit--%>

                            <%--End Div ForMentee Visit--%>
                        </div>
                        <%--Start Div For Signature--%>
                        <div>
                            <%--Start table For Signature--%>
                            <table style="width: 100%; margin-top: 40px;">

                                <tr>
                                    <td>Signature Mentor</td>
                                    <td>Signature Mentee</td>
                                    <td>Signature Parent(s)/Gaurdian(s)</td>
                                </tr>

                                <%--End table For Signature--%>
                            </table>
                            <%--End Div For Signature--%>
                        </div>


                        <%-- END Main Div--%>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
        <div>
            <table>
                <tr>

                    <td>
                        <asp:Button ID="btnPrint" runat="server" OnClientClick="javascript:CallPrint('printDiv1');" Text="Print" />
                    </td>
                </tr>
            </table>
        </div>

    </div>

</asp:Content>

