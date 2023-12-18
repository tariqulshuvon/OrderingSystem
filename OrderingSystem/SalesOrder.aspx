<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SalesOrder.aspx.cs" Inherits="OrderingSystem.SalesOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />

    <div>
        <div class="content">
            <div class="row">

                <div style="padding-block-end: 30px">
                    <h1 style="text-align: center">Sales Order</h1>
                </div>



                <div class="defaultform; col-md-12">

                    <div class="">

                        <div class="row" style="clear: both; padding-bottom: 10px; margin-bottom: 10px">

                            <div class="form-group; ">
                                <asp:Label ID="CustomerName" runat="server" Text="Customer Name:" CssClass="font"></asp:Label>
                                <asp:TextBox ID="TxtName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>


                            <div class="form-group;">
                                <asp:Label ID="vihacle" runat="server" Text="Vihacle Name" CssClass="font"></asp:Label>
                                <asp:TextBox ID="VihacleText" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            
                            <div class="form-group; ">
                                <asp:Label ID="DelivaryDate" runat="server" Text="Delivary Date" CssClass="font"></asp:Label>
                                <asp:TextBox ID="DelivaryDateTxt" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                            </div>

                        </div>


                        <div class="col-md-12">
                            <asp:Button ID="saveAll" runat="server" OnClick="SaveAll_Click" CssClass="button; allign:center; form-control" Text="Save All" />
                            <asp:HyperLink ID="SalesOrderDetailsLink" runat="server" NavigateUrl="~/SalesOrderDetails.aspx" Text="Go to Sales Order Details Page"></asp:HyperLink>

                        </div>
                        <br />
                        <br />
                    </div>
                    <br />
                    <br />
                    <div class="col-md-8">

                        <asp:GridView ID="GridViewSalesOrder" runat="server" AutoGenerateColumns="False" CssClass="table" GridLines="Both" OnRowDeleting="GridViewSalesOrder_RowDeleting"  OnRowEditing="GridViewSalesOrder_RowEditing" OnRowCancelingEdit="GridViewSalesOrder_RowCancelingEdit" OnRowUpdating="GridViewSalesOrder_RowUpdating" DataKeyNames="SalesID">
                            <Columns>
                                <asp:BoundField DataField="SalesID" HeaderText="Sales ID" SortExpression="SalesID" ReadOnly="True" />
                                <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" SortExpression="CustomerName" />
                                <asp:BoundField DataField="Created_At_Converted" HeaderText="Created At" SortExpression="Created_At_Converted" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" />
                                <asp:BoundField DataField="Vihacle_Name" HeaderText="Vihacle Name" SortExpression="Vihacle_Name" />
                                <asp:BoundField DataField="Delivary_Date" HeaderText="Delivery Date" SortExpression="Delivary_Date" />

                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButtonEdit" runat="server" CommandName="Edit" Text="Edit"></asp:LinkButton>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="LinkButtonUpdate" runat="server" CommandName="Update" Text="Update"></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButtonCancel" runat="server" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
                            </Columns>
                        </asp:GridView>



                        <br />
                        <br />

                    </div>
                </div>


            </div>
        </div>
    </div>

</asp:Content>
