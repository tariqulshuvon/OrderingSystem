<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SalesOrderDetails.aspx.cs" Inherits="OrderingSystem.SalesOrderDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <br />

    <div>
        <div class="content">
            <div class="row">

                <div style="padding-block-end: 30px">
                    <h1 style="text-align: center">Sales Order Details</h1>
                </div>



                <div class="defaultform; col-md-12">

                    <div class="">

                        <div class="row" style="clear: both; padding-bottom: 10px; margin-bottom: 10px">

                            <div class="form-group;">
                                <asp:Label ID="SalesID" runat="server" Text="Sales ID:" CssClass="font"></asp:Label>
                                <asp:DropDownList ID="SalesIDDropDown" runat="server" CssClass="form-control"></asp:DropDownList>

                            </div>

                            <div>
                                <asp:Label ID="ItemName" runat="server" Text="Item Name"></asp:Label>
                                <asp:TextBox ID="ItemNameTxt" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>


                            <div class="form-group;">
                                <asp:Label ID="Quantity" runat="server" Text="Quantity" CssClass="font"></asp:Label>
                                <asp:TextBox ID="QuantityTxt" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            
                            <div class="form-group;">
                                <asp:Label ID="Rate" runat="server" Text="Rate" CssClass="font"></asp:Label>
                                <asp:TextBox ID="RateTxt" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                        </div>


                        <div class="col-md-12">
                        <asp:Button ID="saveAll" runat="server" OnClick="SaveAll_Click" CssClass="button; allign:center; form-control" Text="Save All" />
                            <asp:HyperLink ID="SalesOrderDetailsLink" runat="server" NavigateUrl="~/SalesOrder.aspx" Text="Go to Sales Order Page"></asp:HyperLink>

                        </div>
                        <br />
                        <br />
                    </div>
                    <br />
                    <br />
                    <div class="col-md-8">

                        <asp:GridView ID="GridViewSalesOrder" runat="server" AutoGenerateColumns="False" CssClass="table" GridLines="Both" OnRowDeleting="GridViewSalesOrder_RowDeleting"  OnRowEditing="GridViewSalesOrder_RowEditing" OnRowCancelingEdit="GridViewSalesOrder_RowCancelingEdit" OnRowUpdating="GridViewSalesOrder_RowUpdating" DataKeyNames="SalesID">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" ReadOnly="True" />
                                <asp:BoundField DataField="SalesID" HeaderText="Sales ID" SortExpression="SalesID" ReadOnly="True" />
                                <asp:BoundField DataField="ItemName" HeaderText="Item Name" SortExpression="ItemName" />
                                <asp:BoundField DataField="Qty" HeaderText="Quantity" SortExpression="Qty" />
                                <asp:BoundField DataField="Rate" HeaderText="Rate" SortExpression="Rate" />

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
