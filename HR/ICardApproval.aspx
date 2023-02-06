<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="ICardApproval.aspx.cs" Inherits="HR_ICardApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="heading">
            <h2>I Card Details</h2>
        </div>
        <div>
            <div>
                <asp:GridView ID="gvShow" runat="server" AutoGenerateColumns="False" CssClass="gridDynamic"
                    EmptyDataText="No record found" DataKeyNames="EMP_ID" OnRowCommand="gvShow_RowCommand" Width="500" OnRowDataBound="gvShow_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <ItemTemplate>
                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                                        .
                            </ItemTemplate>
                            <ItemStyle Width="15px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="EMP_ID" HeaderText="Employee Code " />
                        <asp:BoundField DataField="EMP_NAME" HeaderText="Employee " />
                         <asp:BoundField DataField="STATUS" HeaderText="Status " />
                        <asp:BoundField DataField="DT" HeaderText="Forward Date" />
                        <asp:CommandField ButtonType="Button" SelectText="Details" ShowSelectButton="True"></asp:CommandField>

                    </Columns>
                    <SelectedRowStyle BackColor="#CCFF99" />
                </asp:GridView>
            </div>

            <table id="Table1" runat="server">
                <tr>
                    <td colspan="2">
                        <img id="imgEmp" runat="server" alt="Image" src="~/images/emp_images/empImage.jpg"
                            style="border: 1px solid #000000; height: 110px; width: 100px;" />
                    </td>
            
                </tr>
                <tr>
                    <th>EMPLOYEE CODE</th>
                    <td>
                        <asp:Label ID="lblCode" runat="server"></asp:Label></td>
                            <th>
APPLY COUNT:
                    </th>
                     <td> <asp:Label ID="lblApplyTime" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <th>NAME OF THE EMPLOYEE</th>
                    <td >
                        <asp:Label ID="lblname" runat="server"></asp:Label></td>

                </tr>
                <tr>
                    <th>FATHER'S/HUSBAND'S NAME</th>
                    <td>
                        <asp:Label ID="lblfather" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <th>DESIGNATION</th>
                    <td>
                        <asp:Label ID="lbldesig" runat="server"></asp:Label></td>

                </tr>
                <tr>
                    <th>DEPARTMENT</th>
                    <td>
                        <asp:Label ID="lbldepart" runat="server"></asp:Label></td>


                </tr>
                <tr>
                    <th>DATE OF JOINING</th>
                    <td>
                        <asp:Label ID="lblDOJ" runat="server"></asp:Label></td>
                </tr>
                <tr>

                    <th>DATE OF BIRTH</th>
                    <td>
                        <asp:Label ID="lblDOB" runat="server"></asp:Label></td>

                </tr>
                <tr>
                    <th>BLOOD GROUP</th>
                    <td>
                        <asp:Label ID="lblBlood" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <th>ADDRESS</th>
                    <td>
                        <asp:Label ID="lblAddress" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <th>Contact No</th>
                    <td>
                        <asp:Label ID="lblContact" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td>
                        <asp:Button ID="BtnApprove" runat="server" Text="Approve" OnClick="Approve_Click"></asp:Button>

                    </td>
                    <td>
                        <asp:Button ID="btnReject" runat="server" Text="Reject" OnClick="btnReject_Click" ></asp:Button>

                    </td>
                </tr>

            </table>
        </div>
    </div>
</asp:Content>

