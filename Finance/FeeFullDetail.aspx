<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FullLength.master" AutoEventWireup="true" CodeFile="FeeFullDetail.aspx.cs" Inherits="Finance_FeeFullDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div>
        <table>
            <tr>
                <th>Process Rule</th>
             
            </tr>
            <tr>
               
                <td>
                    <asp:DropDownList runat="server" ID="ddlProcess" CssClass="width_200"></asp:DropDownList></td>
                 
                <td>
                    <asp:Button ID="btnView" runat="server" Text="View Old" OnClick="btnView_Click" />
                </td>
                  <td>
                    <asp:Button ID="btnView2018" runat="server" Text="View from 2018" OnClick="btnView2018_Click" />
                </td>
                 <td>
                    <asp:Button ID="btn2018Phd" runat="server" Text="View Ph.D." OnClick="btn2018Phd_Click" />
                </td>
            </tr>
        </table>
        <div></div>
        <div style="overflow-x: auto; width:950px; max-height:450px">
        <table >
            <tr id="tr1" runat="server">
                <th>Fee Details 
              <hr style="color: #ff0000" />
                </th>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr id="trold" runat="server">
                <td>
                    <asp:GridView ID="gvDetail" runat="server" AutoGenerateColumns="False"
                        Height="200px"
                        CssClass="gridDynamic">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No.">
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                .
                                </ItemTemplate>
                                <ItemStyle Width="24px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="INS_VALUE" HeaderText="INSTITUTE" />
                            <asp:BoundField DataField="PGM_SHORT_NAME" HeaderText="COURSE" />
                            <asp:BoundField DataField="BRN_SHORT_NAME" HeaderText="BRANCH" />
                            <asp:BoundField DataField="ACA_BATCH_NAME" HeaderText="BATCH" />
                            <asp:BoundField DataField="ADM_TYPE_VALUE" HeaderText="ADMISSION TYPE" />
                            <asp:BoundField DataField="ENROLLMENT_NO" HeaderText="ENROLLMENT NO" />
                            <asp:BoundField DataField="STU_FULL_NAME" HeaderText="NAME" />                            
                           
                            <asp:BoundField DataField="DEM_TUT" HeaderText="DEM TUTION" />
                             <asp:BoundField DataField="DEM_EXAM" HeaderText="DEM EXAM" />
                             <asp:BoundField DataField="CONCESSION_ACA" HeaderText="CONC ACA" /> 
                             <asp:BoundField DataField="CONC_RMK_ACA" HeaderText="CONC RMK ACA" />   
                                                    
                            <asp:BoundField DataField="ADJ_ACA" HeaderText="ADJ COURSE" />
                             <asp:BoundField DataField="NET_RECVBL_ACA" HeaderText="NET RECVBL COURSE" />
                            <asp:BoundField DataField="RCVD_COURS" HeaderText="RCVD TUT" />
                            <asp:BoundField DataField="RCVD_EXAM" HeaderText="RCVD EXAM" />
                             <asp:BoundField DataField="RCVD_ACA" HeaderText="RCVD ACA" />

                            <asp:BoundField DataField="FACILITY_TYPE" HeaderText="FACILITY TYPE" />
                            <asp:BoundField DataField="DEM_FACILITY" HeaderText="DEM FACILITY" />
                            <asp:BoundField DataField="CONCESSION_FAC" HeaderText="CONC FAC" />  
                            <asp:BoundField DataField="CONC_RMK_FAC" HeaderText="CONC RMK FAC" />  

                           <asp:BoundField DataField="ADJ_FACILITY" HeaderText="ADJ FACILITY" />
                             <asp:BoundField DataField="NET_RCVBL_FAC" HeaderText="NET RCVBL FAC" />
                              <asp:BoundField DataField="RCV_FACILITY" HeaderText=  "RCV FACILITY" />

                             <asp:BoundField DataField="NET_BAL" HeaderText="NET BAL" />
                           
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr id="tr2018" runat="server">
                <td>
                    <asp:GridView ID="gvDetail2018" runat="server" AutoGenerateColumns="False"
                        Height="200px"
                        CssClass="gridDynamic">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No.">
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                .
                                </ItemTemplate>
                                <ItemStyle Width="24px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="INS_VALUE" HeaderText="INSTITUTE" />
                            <asp:BoundField DataField="PGM_SHORT_NAME" HeaderText="COURSE" />
                            <asp:BoundField DataField="BRN_SHORT_NAME" HeaderText="BRANCH" />
                            <asp:BoundField DataField="ACA_BATCH_NAME" HeaderText="BATCH" />
                            <asp:BoundField DataField="ADM_TYPE_VALUE" HeaderText="ADMISSION TYPE" />
                            <asp:BoundField DataField="ENROLLMENT_NO" HeaderText="ENROLLMENT NO" />
                            <asp:BoundField DataField="STU_FULL_NAME" HeaderText="NAME" />                            
                           
                            <asp:BoundField DataField="DEM_TUT" HeaderText="DEM TUTION" />
                             <asp:BoundField DataField="DEM_EXAM" HeaderText="DEM EXAM" />
                             <asp:BoundField DataField="CONCESSION_ACA" HeaderText="CONC ACA" /> 
                             <asp:BoundField DataField="CONC_RMK_ACA" HeaderText="CONC RMK ACA" />   
                                                    
                            <asp:BoundField DataField="ADJ_ACA" HeaderText="ADJ COURSE" />
                             <asp:BoundField DataField="NET_RECVBL_ACA" HeaderText="NET RECVBL COURSE" />
                            <asp:BoundField DataField="RCVD_COURS" HeaderText="RCVD TUT" />
                            <asp:BoundField DataField="RCVD_EXAM" HeaderText="RCVD EXAM" />
                             <asp:BoundField DataField="RCVD_ACA" HeaderText="RCVD ACA" />

                            <asp:BoundField DataField="FACILITY_TYPE" HeaderText="FACILITY TYPE" />
                            <asp:BoundField DataField="DEM_FACILITY" HeaderText="DEM FACILITY" />
                            <asp:BoundField DataField="CONCESSION_FAC" HeaderText="CONC FAC" />  
                            <asp:BoundField DataField="CONC_RMK_FAC" HeaderText="CONC RMK FAC" />  

                           <asp:BoundField DataField="ADJ_FACILITY" HeaderText="ADJ FACILITY" />
                             <asp:BoundField DataField="NET_RCVBL_FAC" HeaderText="NET RCVBL FAC" />
                              <asp:BoundField DataField="RCV_FACILITY" HeaderText=  "RCV FACILITY" />

                             <asp:BoundField DataField="NET_BAL" HeaderText="NET BAL" />
                            <asp:BoundField DataField="MONEY_CR_BAL_AMT" HeaderText="ADVANCE" />
                           
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr id="trPhd" runat="server">
                <td>
                    <asp:GridView ID="gv2018Phd" runat="server" AutoGenerateColumns="False"
                        Height="200px"
                        CssClass="gridDynamic">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No.">
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                .
                                </ItemTemplate>
                                <ItemStyle Width="24px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="INS_VALUE" HeaderText="INSTITUTE" />
                            <asp:BoundField DataField="PGM_SHORT_NAME" HeaderText="COURSE" />
                            <asp:BoundField DataField="BRN_SHORT_NAME" HeaderText="BRANCH" />
                            <asp:BoundField DataField="ACA_BATCH_NAME" HeaderText="BATCH" />
                            <asp:BoundField DataField="ADM_TYPE_VALUE" HeaderText="ADMISSION TYPE" />
                            <asp:BoundField DataField="ENROLLMENT_NO" HeaderText="ENROLLMENT NO" />
                            <asp:BoundField DataField="STU_FULL_NAME" HeaderText="NAME" />                            
                           
                            <asp:BoundField DataField="DEM_Registration_Fee" HeaderText="DEM REG" />
                             <asp:BoundField DataField="DEM_Tution" HeaderText="DEM TUT" />
                             <asp:BoundField DataField="DEM_Course_Work" HeaderText="DEM COURS" /> 
                            
                                                    
                            <asp:BoundField DataField="CONCESSION_ACA" HeaderText="CONC ACA" />
                             <asp:BoundField DataField="CONC_RMK_ACA" HeaderText="CONC REMARK" />
                            <asp:BoundField DataField="ADJ_Registration" HeaderText="ADJ REG" />
                            <asp:BoundField DataField="ADJ_Tution" HeaderText="ADJ TUT" />
                              <asp:BoundField DataField="ADJ_Course_Work" HeaderText="ADJ COURS" />
                             <asp:BoundField DataField="RCVD_REGISTR" HeaderText="RCVD REG" />
                             <asp:BoundField DataField="RCVD_TUTION" HeaderText="RCVD TUT" />
                             <asp:BoundField DataField="RCVD_COURS" HeaderText="RCVD COURS" /> 

                            <asp:BoundField DataField="FACILITY_TYPE" HeaderText="FACILITY TYPE" />
                            <asp:BoundField DataField="DEM_FACILITY" HeaderText="DEM FACILITY" />
                            <asp:BoundField DataField="ADJ_FACILITY" HeaderText="ADJ FACILITY" />
                            <asp:BoundField DataField="CONCESSION_FAC" HeaderText="CONC FAC" />  
                            <asp:BoundField DataField="CONC_RMK_FAC" HeaderText="CONC RMK FAC" />  

                              <asp:BoundField DataField="RCV_FACILITY" HeaderText=  "RCV FACILITY" />

                             <asp:BoundField DataField="NET_BAL" HeaderText="NET BAL" />
                            <asp:BoundField DataField="MONEY_CR_BAL_AMT" HeaderText="ADVANCE" />
                           
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
            </div>
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnExport" runat="server" Text="Export Old" OnClick="btnExport_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnExport2018" runat="server" Text="Export from 2018" OnClick="btnExport2018_Click" />
                    </td>
                     <td>
                        <asp:Button ID="btnPhd" runat="server" Text="Export Ph.D." OnClick="btnPhd_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>

</asp:Content>

