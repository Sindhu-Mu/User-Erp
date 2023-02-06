<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="StuAssignment.aspx.cs" Inherits="Academic_StuAssignment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

           <div class="heading">
            <h2>Assignment</h2>
        </div>
    
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>

                <asp:GridView ID="gvShow" runat="server" SelectedRowStyle-BackColor="Yellow" CssClass="gridDynamic" AutoGenerateColumns="False" DataKeyNames="TT_ID,TT_PAP_ID,EMP_ID,GRP_ID" EmptyDataText="No Record Avaliable" OnRowCommand="gvShow_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <ItemTemplate>
                                <%# ((GridViewRow)Container).RowIndex + 1%>.
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Course_Code" HeaderText="COURSE CODE" />
                        <asp:BoundField DataField="ACA_SEM_NO" HeaderText="SEM" />
                        <asp:BoundField DataField="ACA_SEC_NAME" HeaderText="SECTION " />
                        <asp:BoundField DataField="GRP_VALUE" HeaderText="GROUP" />
                        <asp:CommandField ButtonType="Button" HeaderText="Select" ShowSelectButton="True" />

                    </Columns>
                </asp:GridView>

            </ContentTemplate>
        </asp:UpdatePanel>     
    <div>
        <table>
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <asp:GridView ID="gvAssignment" Width="500px" runat="server" SelectedRowStyle-BackColor="Yellow" CssClass="gridDynamic" AutoGenerateColumns="False" DataKeyNames="DOC_NAME" EmptyDataText="No Record Available" OnRowCommand="gvAssignment_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <ItemTemplate>
                                <%# ((GridViewRow)Container).RowIndex + 1%>.
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="DOC_NAME" HeaderText="Assignment Title" />
                        <asp:BoundField DataField="DUE_DATE" HeaderText="Due Date" />
                         <asp:CommandField ButtonType="Button" HeaderText="Select" ShowSelectButton="True" />
                       

                    </Columns>
                </asp:GridView>

            </ContentTemplate>
        </asp:UpdatePanel>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>

                <asp:GridView ID="gvstu" Width="500px" runat="server" SelectedRowStyle-BackColor="Yellow" CssClass="gridDynamic" AutoGenerateColumns="False" EmptyDataText="No Record Available" OnRowCommand="gvstu_RowCommand" >
                    <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <ItemTemplate>
                                <%# ((GridViewRow)Container).RowIndex + 1%>.
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField  DataField="Enrollment_NO" HeaderText="Enrollment" />
                        <asp:BoundField DataField="STU_FULL_NAME" HeaderText="Name" />
                        <asp:BoundField DataField="DOC_NAME" HeaderText="Assignment" />
                        <asp:BoundField DataField="DUE_DATE" HeaderText="Due Date" />
                         <asp:CommandField ButtonType="Button" HeaderText="Select" ShowSelectButton="True" />
                       

                    </Columns>
                </asp:GridView>

                <table>
                    <tr>
                        <td><a id="A1" runat="server"><b>Download</b></a></td>
                    </tr>
                </table>

            </ContentTemplate>
        </asp:UpdatePanel>
                </td>

                
            </tr>
        </table>
        
    </div>
         
    
             
</asp:Content>

