<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="Assignment1.Product" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
<title>Product Viewer</title>
    <style>
        body { font-family: Arial; }
        .container { margin: 30px; }
        .row { margin-bottom: 15px; }
        label { display: inline-block; width: 120px; }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    
        <div class="container">

            <div class="row">
                <label>Select Product:</label>
                <asp:DropDownList ID="ddlProducts" runat="server" AutoPostBack="true"
                    OnSelectedIndexChanged="ddlProducts_SelectedIndexChanged">
                </asp:DropDownList>
            </div>

            <div class="row">
                <asp:Image ID="imgProduct" runat="server" Width="200px" Height="200px" />
            </div>

            <div class="row">
                <asp:Button ID="btnPrice" runat="server" Text="Get Price"
                    OnClick="btnPrice_Click" />
            </div>

            <div class="row">
                <asp:Label ID="lblPrice" runat="server" ForeColor="Green" Font-Bold="true" />
            </div>

        </div>
    </form>
</body>
</html>
