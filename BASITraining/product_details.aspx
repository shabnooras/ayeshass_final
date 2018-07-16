<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="product_details.aspx.cs" Inherits="BASITraining.product_details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <%-- using the GetProduct method to connect to products class and database --%>
    <asp:FormView ID="productDetail" runat="server" ItemType="BASITraining.Models.product" SelectMethod="GetProduct" RenderOuterTable="false">
        <ItemTemplate>
            <div>
                <%-- collect information on which product is clicked and display all its details from the "product" database --%>
                <h1><%#:Item.ProductName %></h1>
            </div>
            <br />
            <table>
                <tr>
                    <td>
                        <img src="/Catalog/<%#:Item.ImagePath %>" style="border: solid; height: 200px" alt="<%#:Item.ProductName %>" />
                    </td>
                    <td>&nbsp;</td>
                    <td style="vertical-align: top; text-align: left;">
                        <br />
                        <%-- displays the price of the course in Pounds --%>
                        <span><b>Price:</b>&nbsp;<%#: String.Format("{0:c}", Item.UnitPrice) %></span>
                        <br />
                        <span><b>Product Number:</b>&nbsp;<%#:Item.ProductID %></span>
                        <br />
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
