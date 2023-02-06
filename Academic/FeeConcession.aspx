<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="FeeConcession.aspx.cs" Inherits="Academic_FeeConcession" %>

<%@ Register Src="~/Control/Student.ascx" TagPrefix="uc1" TagName="Student1" %>
<%@ Register Src="~/Control/Calender.ascx" TagPrefix="uc1" TagName="Calender" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="heading">
            <h2>Fee Concession</h2>
        </div>
        <div>
            &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtEnrol" runat="server"></asp:TextBox>
           
             <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionSetCount="12"
                                                        EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetStudentList"
                                                        ServicePath="~\AutoComplete.asmx" TargetControlID="txtEnrol" ContextKey="1,2,3,4,5,6">
         </ajaxToolkit:AutoCompleteExtender>
            &nbsp;&nbsp; <asp:Button Text="Show" runat="server" OnClick="Show_Click" />
            <br/><br/>
            <uc1:Student1 runat="server" ID="Student" />
        
        </div>
        <br/>
        <div>
            <br/>
            <table>
            <tr>
                <td>Rule Name</td>
                <td>Session</td>
                <td>Applied Date</td>
                <td>Upload Document</td>
            </tr>
            <tr>
                <td><asp:DropDownList runat="server" ID="ddlRule"></asp:DropDownList></td>
                <td><asp:DropDownList runat="server" ID="ddlSession"></asp:DropDownList></td>
                <td><asp:TextBox runat="server" ID="txtDate"></asp:TextBox></td>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate" Format="dd/MM/yyyy">
                    </ajaxToolkit:CalendarExtender>
                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtDate" Mask="99/99/9999"
                                 MaskType ="Date" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True">
                                     </ajaxToolkit:MaskedEditExtender>
               <td> <asp:FileUpload ID="fileUpload" runat="server" /></td>
                <td><asp:Button ID="btnSave" runat="server" Text="ADD" OnClick="btnSave_Click"/></td>
            </tr>
</table>
        </div>
        <div>
            <br/>
            <asp:GridView ID="grdView" runat="server" AutoGenerateColumns="false" EmptyDataText="No Concession Found">
                 <Columns>
                                            <asp:TemplateField HeaderText="S.No">
                                                <ItemTemplate>
                                                    <%#((GridViewRow)Container).RowIndex +1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Concession Name" DataField="CONC_RULE_NAME" />
                                            <asp:BoundField HeaderText="Applied Date" DataField="APPLIED_DT" />
                                            <asp:BoundField HeaderText="Session" DataField="ACA_SESN_VALUE" />
                                            <asp:BoundField HeaderText="Document" DataField="URL" />
                                        </Columns>

            </asp:GridView>
            
        </div>


        </div>

</asp:Content>

