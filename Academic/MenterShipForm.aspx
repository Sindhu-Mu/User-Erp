<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="MenterShipForm.aspx.cs" Inherits="Academic_MenterShipForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script lang="javascript" type="text/javascript">
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == "-1") {
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




            if (!CheckControl("<%=txtAttRemark.ClientID%>")) {
                msg += "- Please Enter Attendance Suggestion \n";
                if (ctrl == "")
                    ctrl = "<%=txtAttRemark.ClientID%>";
                flag = false;
            }

            if (!CheckControl("<%=txtBehave.ClientID%>")) {
                msg += "- Please Enter Behaviour Suggestion \n";
                if (ctrl == "")
                    ctrl = "<%=txtBehave.ClientID%>";
                flag = false;
            }

            if (!CheckControl("<%=txtAcaRemark.ClientID%>")) {
                msg += "- Please Enter Academic Suggestion \n";
                if (ctrl == "")
                    ctrl = "<%=txtAcaRemark.ClientID%>";
                flag = false;
            }

            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }

    </script>
    <div class="container">
        <div class="heading">
        </div>
        <div>
            

                    <table>
                        <tr>
                            <td>
                                <div style="height: 250px; overflow: scroll;">
                                    <asp:GridView ID="gvStu" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" OnRowCommand="gvStu_RowCommand" DataKeyNames="STU_MAIN_ID">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No">
                                                <ItemTemplate>
                                                    <%#((GridViewRow)Container).RowIndex +1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Enrollment No" DataField="ENROLLMENT_NO" />
                                            <asp:BoundField HeaderText="Name" DataField="STU_FULL_NAME" />
                                            <asp:BoundField HeaderText="Program" DataField="PGM_SHORT_NAME" />
                                            <asp:BoundField HeaderText="Branch" DataField="BRN_SHORT_NAME" />
                                            <asp:ButtonField ButtonType="Button" CommandName="Detail" Text="Detail" HeaderText="Detail" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                    </table>


                    <%-- Start Main Div--%>
                    <div id="main" style="width: 700px" runat="server">

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
                                <td rowspan="2" style="width: 140px; border: 1px solid black;">
                                    <strong>CONTACT</strong> <strong>PARENT</strong>
                                </td>
                                <td rowspan="2" style="border: 1px solid black;">
                                    <asp:Label runat="server" ID="lblContPart"></asp:Label>
                                </td>
                                <td rowspan="2" style="width: 140px; border: 1px solid black;">
                                    <strong>ADDRESS</strong></td>
                                <td rowspan="2" style="width: 195px; border: 1px solid black;">
                                    <asp:Label runat="server" ID="lblAddress"></asp:Label>
                                </td>


                            </tr>
                        </table>

                        <asp:GridView ID="gvPrevQuali" Width="700px" Caption="Previous Education Details" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" EmptyDataText="No Records Found">
                            <Columns>

                                <asp:BoundField DataField="ACA_BASE_FULL_NAME" HeaderText="Qualification" />
                                <asp:BoundField DataField="PRSNT" HeaderText="Percentage" />
                                <%--<asp:BoundField DataField="STU_FULL_NAME" HeaderText="Name" />--%>
                            </Columns>
                        </asp:GridView>

                        <%--End Table for Name, detail & Contact--%>
                        <div id="DIV_SEM_MARKS">
                            <asp:GridView ID="gvSemResult" runat="server" AutoGenerateColumns="False" Caption="Student Tracking Report"
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
                        <div runat="server" style="width: 700px" id="div_Attendance_Marks">

                            <asp:GridView ID="gvAttendance" runat="server" AutoGenerateColumns="False" Caption="Attendance Percentage"
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

                            <asp:Chart ID="Chart1" runat="server" BorderlineWidth="0" Width="650px">
                                <Series>
                                    <asp:Series Name="Series1" XValueMember="EVA_SCH_PAPER_CODE" YValueMembers="PER_M1"
                                        LegendText="Minor-I" IsValueShownAsLabel="true" ChartArea="ChartArea1"
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
                             <hr style="visibility: hidden; page-break-after: always" />
                            <asp:GridView ID="gvMarks" runat="server" AutoGenerateColumns="False" Caption="Academic Profile"
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
                                    <asp:Title Docking="Bottom" Text="Marks Status" ></asp:Title>
                                </Titles>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea2"></asp:ChartArea>
                                </ChartAreas>
                            </asp:Chart>
                        </div>

<%-----------------------------------------------------------------------------------------%>

    <asp:UpdatePanel ID="up" runat="server">
     
  <ContentTemplate>
<div id="form_entery">
                        <%--Start Div For Achievements--%>
                        <div>
                            <%--Start table For Achievements--%>
                            <table style="width: 100%; border: 1px solid black; border-collapse: collapse;">
                                <tr>
                                    <td style="text-align: center"><b>Achievements(If Any)</b></td>
                                </tr>

                                <tr>

                                    <td>
                                        <asp:TextBox ID="txtachv" runat="server" Width="500px"></asp:TextBox>
                                        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" />
                                    </td>
                                    <asp:TextBox ID="txtxml" runat="server" Visible="false"></asp:TextBox>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="GvAdd" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" EmptyDataText="No Achievement Added">
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
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnAchvSave" runat="server" OnClick="btnAchvSave_Click" Text="Save Achievement" />
                                    </td>
                                </tr>


                                <%--End table For Achievements--%>
                            </table>
                            <%--End Div For Achievements--%>
                        <%--Start Div For Behaviour/Parent--%>
                       
                            <%--Start table For Behaviour/Parent--%>

                            <table style="width: 100%; border: 1px solid black; border-collapse: collapse;">
                                <tr>
                                    <td  style=" width: 380px"><b>Behaviour</b></td>
                                   
                                    <td style=" width: 380px"><b>Parents to be called</b></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:RadioButtonList ID="rdoBehaviour" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="0" Selected>Satisfactory</asp:ListItem>
                                            <asp:ListItem Value="1">Unsatisfactory</asp:ListItem>

                                        </asp:RadioButtonList></td>
                                    
                                    <td>
                                        <asp:RadioButtonList ID="rdoParents" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdoParents_SelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem Value="0">Yes</asp:ListItem>
                                            <asp:ListItem Value="1" Selected>No</asp:ListItem>

                                        </asp:RadioButtonList></td>
                                </tr>
                                <%--End table For Behaviour/Parent--%>
                            </table>
                            <%--End Div For Behaviour/Parent--%>
                      
                            <div id="DivSMS" runat="server">
                                <table>
                                    <tr>
                                        <th>Maximum 160 characters used for SMS</th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtSMS" TextMode="MultiLine" runat="server" Width="200px" Height="80px"></asp:TextBox>
                                        </td> 
                                        <td><asp:Button ID="btnSMS" runat="server" Text="SEND SMS" OnClick="btnSMS_Click"/></td>
                                    </tr>
                                </table>
                            </div>

                        <%--Start Div For Parent Comments--%>
                    
                            <%--Start table For Parent Comments--%>
                            <table style="width: 100%; border: 1px solid black; ">

                                <tr>
                                    <td style="width:98%;"><b>Parent(s)/Gaurdian(s) Comments:</b></td>
                                </tr>
                               <tr>
                                   <td style="height:50px"></td>
                               </tr>
                                <%--End table For Parent Comments--%>
                            </table>
                            <%--End Div For Parent Comments--%>
                        </div>

                        <%--Start Div For Mentor Suggestion--%>
                        <div>
                            <%--Start table For  Mentor Suggestion--%>
                            <table style="width: 100%; border: 1px solid black; border-collapse: collapse;">
                                <tr>
                                    <td style="text-align: center"><b>Mentor Suggestions for Improvements</b></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:RadioButtonList ID="rdoAtt" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="0" Selected="True">Minor-I</asp:ListItem>
                                            <asp:ListItem Value="1">Minor-II</asp:ListItem>
                                            <asp:ListItem Value="2">Major</asp:ListItem>

                                        </asp:RadioButtonList></td>
                                </tr>
                                <tr>
                                    <td style="text-align: center"><strong>(a)Attendance</strong></td>
                                </tr>
                                
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtAttRemark" runat="server" TextMode="MultiLine" Width="500px" Height="50px"></asp:TextBox>
                                    </td>
                                </tr>

                            </table>
                            <table style="width: 100%; border: 1px solid black; border-collapse: collapse;">

                                <tr>
                                    <td style="text-align: center"><strong>(b)Academic</strong></td>
                                </tr>
                                <%--<tr>
                                  <td><asp:RadioButtonList id="rdoAca" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="0" Selected>Minor-I</asp:ListItem>
                                    <asp:ListItem Value="1" >Minor-II</asp:ListItem>
                                    <asp:ListItem Value="2" >Major</asp:ListItem>

                                     </asp:RadioButtonList></td>
                                </tr>--%>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtAcaRemark" runat="server" TextMode="MultiLine" Width="500px" Height="50px"></asp:TextBox>
                                    </td>
                                </tr>

                            </table>

                            <table style="width: 100%; border: 1px solid black; border-collapse: collapse;">

                                <tr>
                                    <td style="text-align: center"><strong>(C)Behaviour</strong></td>
                                </tr>
                                <%-- <tr>
                                  <td><asp:RadioButtonList id="rdoBehave" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="0" Selected>Minor-I</asp:ListItem>
                                    <asp:ListItem Value="1" >Minor-II</asp:ListItem>
                                    <asp:ListItem Value="2" >Major</asp:ListItem>

                                     </asp:RadioButtonList></td>
                                </tr>--%>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtBehave" runat="server" TextMode="MultiLine" Width="500px" Height="50px"></asp:TextBox>
                                    </td>
                                </tr>
                                <%--End table For  Mentor Suggestion--%>
                            </table>
                            <%--End Div For  Mentor Suggestion--%>
                        </div>
                        <%--Start Div For Mentee Visit--%>
                        <div>
                            <%--Start table For  Mentee Visit--%>
                            <table style="width: 100%; border: 1px solid black; border-collapse: collapse;">
                                <tr>
                                    <td colspan="4" style="text-align: center"><strong>Mentee Visit Record(Other Than Shedule)</strong></td>
                                </tr>
                                <tr>
                                   <th>Date</th>
                                    <th>
                                        Purpose of visit
                                    </th>
                                    <th colspan="2">
                                        Suggestions
                                    </th>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtDate" runat="server" Width="116px"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox ID="txtPurpose" runat="server" Width="200px"></asp:TextBox></td>
                                    <td>
                                        <asp:TextBox ID="txtSuggestion" runat="server" TextMode="MultiLine" Height="50px" Width="226px"></asp:TextBox></td>
                                    <td>
                                        <asp:Button ID="btnAdd1" runat="server" Text="Add" OnClick="btnAdd1_Click" /></td>
                                </tr>
                                <asp:TextBox ID="txtxml1" runat="server" Visible="false"></asp:TextBox>
                                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtDate"
                                    Mask="99/99/9999" MaskType="Date">
                                </ajaxToolkit:MaskedEditExtender>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtDate"
                                    Format="dd/MM/yyyy">
                                </ajaxToolkit:CalendarExtender>

                            </table>


                            <asp:GridView ID="gvMentee" runat="server" AutoGenerateColumns="false" CssClass="gridDynamic" Width="700px" EmptyDataText="No Achievement Added">
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
                            <table style="width: 100%; border: 1px solid black; border-collapse: collapse;">
                                <tr>
                                    <td colspan="2">
                                        <asp:Button ID="btnVisit" runat="server" OnClick="btnVisit_Click" Text="Save Visit" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnSaveMentee" runat="server" OnClick="btnSaveMentee_Click" Text="Save Mentee Details" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnView" runat="server" OnClick="btnView_Click" Text="View" />
                                    </td>
                                </tr>
                                <%--End table For Mentee Visit--%>
                            </table>
                            <%--End Div ForMentee Visit--%>
                        </div>
                        <%--Start Div For Signature--%>
                        <div>
                            <%--Start table For Signature--%>
                            <table style="width: 100%; margin-top: 40px;">

                                <tr>
                                    <td style="width:33%">Signature Mentor</td>
                                    <td style="width:33%">Signature Mentee</td>
                                    <td>Signature Parent(s)/Gaurdian(s)</td>
                                </tr>

                                <%--End table For Signature--%>
                            </table>
                            <%--End Div For Signature--%>
                        </div>
    

                        </div>
       
      
                                </ContentTemplate>

        <Triggers>
            <asp:PostBackTrigger ControlID="btnAdd" />
        </Triggers>
                        </asp:UpdatePanel>
                        <%-- END Main Div--%>
                    </div>
              
        </div>
    </div>
</asp:Content>

