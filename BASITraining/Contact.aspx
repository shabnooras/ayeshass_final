<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="BASITraining.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <h2>CONTACT US</h2>

    <span style="font-size: x-large">
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Image ID="Image1" runat="server" Height="69px" ImageUrl="~/images/callph.png" Width="80px" />
        &nbsp;
    1234567890&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Image ID="Image2" runat="server" ImageUrl="~/images/visit.png" Style="margin-right: 0px" Width="78px" />
        &nbsp;<br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; 
        
        <%-- embedding the google map location onto the webform  --%>
        <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2434.075037119482!2d-1.502385984275773!3d52.40531625247459!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x48774bb803de8111%3A0x532d1678b86680d6!2sUnnamed+Road%2C+Coventry+CV1+5DD!5e0!3m2!1sen!2suk!4v1530714702998" width="600" height="450" frameborder="0" style="border: 0" allowfullscreen></iframe>
        <br />
        <br />
    </span>

    <%-- Contact us form with validation controls --%>
    <span style="font-size: large">&nbsp;&nbsp;&nbsp;&nbsp; CONTACT US FORM<br />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#CC3300" HeaderText="Please fix the errors" />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="nameValidator1" runat="server" ControlToValidate="TextBox3" ErrorMessage="Name is required" ForeColor="#CC3300">*</asp:RequiredFieldValidator>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Email:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>

        <%-- checks for email validation - if textbox is not null and email address format are correct --%>
        <asp:RequiredFieldValidator ID="emailValidator1" runat="server" ControlToValidate="TextBox2" ErrorMessage="Email is required" ForeColor="#CC3300">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox2" ErrorMessage="Invalid email format" ForeColor="#CC3300" ToolTip="Invalid email format" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Subject:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="SubjValidator1" runat="server" ControlToValidate="TextBox5" ErrorMessage="Subject is required" ForeColor="#CC3300">*</asp:RequiredFieldValidator>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Message:&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="submitButton" runat="server" Text="Submit" OnClick="Button4_click" />
        <br />
        <br />
    </span>

    <span style="font-size: x-large">
        <br />
        <br />
        &nbsp;<br />
    </span>
</asp:Content>
