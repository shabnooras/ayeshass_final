<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="shoppingcart.aspx.cs" Inherits="BASITraining.shoppingcart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="ShoppingCartTitle" runat="server" class="ContentHead"><h1>Courses Selected</h1></div>
    <asp:GridView ID="CartList" runat="server" AutoGenerateColumns="False" ShowFooter="True"
        ItemType="BASITraining.Models.cartitem" SelectMethod="Getcoursecartitems" 
        CssClass="table table-striped table-bordered" OnSelectedIndexChanged="CartList_SelectedIndexChanged" >   
        <Columns>
        <asp:BoundField DataField="ProductID" HeaderText="ID" SortExpression="ProductID"/>    
        <asp:BoundField DataField="product.ProductName" HeaderText="Name" />        
        <asp:BoundField DataField="product.UnitPrice" HeaderText="Price" DataFormatString="{0:c}"/>      
        
        <asp:TemplateField HeaderText="Remove Item">            
                <ItemTemplate>
                    <asp:CheckBox id="Remove" runat="server"></asp:CheckBox>
                </ItemTemplate>        
        </asp:TemplateField>    
        </Columns>    
    </asp:GridView>
    <div style="margin-left: 40px">
        <p>
            <asp:Button ID="Updatebutton" runat="server" OnClick="updatebutton_Click" Text="Update" />
        </p>
        <strong>
            <asp:Label ID="LabelTotalText" runat="server" Text="Total: "></asp:Label>
            <asp:Label ID="lblTotal" runat="server" EnableViewState="false"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="CheckoutButton" runat="server" Text="CHECKOUT" OnClick="CheckoutButton_Click" />
        </strong> 
    </div>
    <br />
    <br />
</asp:Content>
