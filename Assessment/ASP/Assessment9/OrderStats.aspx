<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderStats.aspx.cs" Inherits="Assessment9.OrderStats" %>

<asp:Content ID="Content1"
ContentPlaceHolderID="MainContent"
runat="server">

    <h2>Order Statistics</h2>

    <br />

    <asp:Label ID="lblVisitors"
        runat="server"
        Font-Size="Large">
    </asp:Label>

    <br /><br />

    <asp:Label ID="lblUsers"
        runat="server"
        Font-Size="Large">
    </asp:Label>

</asp:Content>