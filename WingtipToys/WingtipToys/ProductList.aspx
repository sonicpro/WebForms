<%@ Page Title="" Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="ProductList.aspx.cs"
    Inherits="WingtipToys.ProductList"
    ClientIDMode="Static" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div>
            <hgroup>
                <h2><%: Page.Title %></h2>
            </hgroup>

            <!-- "GroupItemCount ListView property defines the number of ItemTemplate elements in the GroupItem -->
            <asp:ListView ID="productList" runat="server"
                DataKeyNames="ProductId"
                GroupItemCount="4" 
                ItemType="WingtipToys.Models.Product"
                SelectMethod="GetProducts">
                <EmptyDataTemplate>
                    <table>
                        <tr>
                            <td>No data was returned</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
                    <td></td>
                </EmptyItemTemplate>
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td runat="server">
                        <table>
                            <tr>
                                <td>
                                    <a href="ProductDetails.aspx?productId=<%#Item.ProductId %>">
                                        <img src="/Catalog/<%#:Item.ImagePath %>"
                                            width="100px"
                                            height="75px"
                                            style="border: solid;" />
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="ProductDetails.aspx?productId=<%#Item.ProductId %>">
                                        <span>
                                            <%#: Item.ProductName %>
                                        </span>
                                    </a>
                                    <br />
                                    <span>
                                        <b>Price: </b><%#:string.Format("{0:c}", Item.UnitPrice) %>
                                    </span>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </ItemTemplate>
                <LayoutTemplate>
                    <table style="width: 100%;">
                        <tbody>
                            <tr>
                                <td>
                                    <table id="groupPlaceholderContainer" runat="server" style="width: 100%;">
                                        <tr id="groupPlaceholder">
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
        </div>
    </section>
</asp:Content>
