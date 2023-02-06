<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PA02_B1_STY.aspx.cs" Inherits="Appraisal_PA02_B1_STY" MasterPageFile="~/MasterPages/StudentFeedback.master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script lang="javascript" type="text/javascript">
        function CheckControl(ctrl) {
            if (bTrim(document.getElementById(ctrl).value) == "" || bTrim(document.getElementById(ctrl).value) == ".") {
                document.getElementById(ctrl).style.backgroundColor = "skyblue";
                return false;
            }

            return true;
        }
        function validation() {

            var flag = true;
            var msg = "", ctrl = "";
            if (!CheckControl("<%=txtEnroll.ClientID%>")) {
                msg += " * Enter your enrollment no.\n";
                if (ctrl == "")
                    ctrl = "<%=txtEnroll.ClientID%>";
                flag = false;
            }
            if (!CheckControl("<%=txtDate.ClientID%>")) {
                msg += " * Enter your date of birth.\n";
                if (ctrl == "")
                    ctrl = "<%=txtDate.ClientID%>";
                flag = false;
            }
            if (msg != "") alert(msg);
            if (ctrl != "")
                document.getElementById(ctrl).focus();
            return flag;
        }
    </script>
    <div id="DivLogin" runat="server">
        <div id="login">
            <h1>EVEN SEM-2021</h1>

            <div class="field-wrap">
                <label>
                    Enrollment Number<span class="req">*</span>
                </label>
                <asp:TextBox ID="txtEnroll" runat="server"></asp:TextBox>
            </div>
            <div class="field-wrap">
                <label>
                    Date of Birth<span class="req">*</span>
                </label>
                <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtDate" Format="dd/MM/yyyy">
                </ajaxToolkit:CalendarExtender>
                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999" MaskType="Date"
                    TargetControlID="txtDate">
                </ajaxToolkit:MaskedEditExtender>
            </div>
        </div>
        <div>
            <asp:Button ID="btnSubmit" Text="Start" runat="server" CssClass="button button-block" OnClick="btnSubmit_Click" />
        </div>
    </div>
    <div id="DivInstruction" runat="server">

        <div>
            <h4>Instructions for Feedback</h4>
        </div>
        <div>
            <ul>                
                <li>Student Feedback divided into two parts Curriculum Feedback and Course faculty Feedback.  </li>
                <li>छात्र प्रतिक्रिया को दो भागों में विभाजित किया गया है पाठ्यचर्या प्रतिक्रिया और पाठ्यक्रम शिक्षक प्रतिक्रिया। </li>
                <li>CURRICULUM FEEDBACK : In this part students have to submit feedback for curriculum and click on submit button move to next feedback part.</li>
                <li>इस भाग में छात्रों को पाठ्यक्रम के लिए फीडबैक जमा करना होगा और सबमिट बटन पर क्लिक करना होगा और अगले फीडबैक भाग में जाना होगा। </li>
                <li>COURSE FACULTY FEEDBACK: In second part students have to submit feedback for each course teacher who have teach to you in last semester.</li>
                <li>दूसरे भाग में छात्रों को प्रत्येक पाठ्यक्रम शिक्षक के लिए फीडबैक जमा करना होता है, जिन्होंने आपको पिछले सेमेस्टर में पढ़ाया है।</li>
                <li style="color: #f00;">It is compulsory to click on Final Submit button to submit your feedback completely.</li>
                <li style="color: #f00;">अपना फीडबैक पूरी तरह से जमा करने के लिए फाइनल सबमिट बटन पर क्लिक करना अनिवार्य है।</li>
            </ul>
            <div>
                <asp:Button ID="btnProcess" runat="server" BackColor="ForestGreen" ForeColor="White" Font-Size="18px" Text="I have read the above instructions for Feedback carefully." OnClick="btnProcess_Click" /><br />
                <asp:Button ID="Button1" runat="server" BackColor="ForestGreen" ForeColor="White" Text="मैंने फीडबैक के लिए उपरोक्त निर्देशों को ध्यान से पढ़ लिया है" OnClick="btnProcess_Click" />
            </div>
        </div>
    </div>


</asp:Content>
