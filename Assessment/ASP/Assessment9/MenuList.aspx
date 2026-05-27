
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
AutoEventWireup="true"
CodeBehind="MenuList.aspx.cs"
Inherits="Assessment9.MenuList" %>

<asp:Content ID="Content1"
ContentPlaceHolderID="MainContent"
runat="server">

    <h2>Food Menu List</h2>

<asp:GridView ID="GridView1" runat="server"
    AutoGenerateColumns="False"
    DataKeyNames="MenuId"
    OnRowDeleting="GridView1_RowDeleting">

    <Columns>

        <asp:BoundField DataField="MenuId" HeaderText="ID" />
        <asp:BoundField DataField="ItemName" HeaderText="Item Name" />
        <asp:BoundField DataField="Category" HeaderText="Category" />
        <asp:BoundField DataField="Price" HeaderText="Price" />

        <asp:HyperLinkField
            Text="View"
            DataNavigateUrlFields="MenuId"
            DataNavigateUrlFormatString="MenuDetails.aspx?MenuId={0}" />

        <asp:HyperLinkField
            Text="Edit"
            DataNavigateUrlFields="MenuId"
            DataNavigateUrlFormatString="AddEditMenu.aspx?MenuId={0}" />

        <asp:CommandField ShowDeleteButton="True" />

    </Columns>

</asp:GridView>

</asp:Content>
