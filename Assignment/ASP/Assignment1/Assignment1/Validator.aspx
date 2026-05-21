<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validator.aspx.cs" Inherits="Assignment1.Validator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Validator Page</title>
</head>
<body>
   <form id="form1" runat="server">
    <table>
        <tr>
            <td>Name:</td>
            <td><asp:TextBox ID="txtName" runat="server" /></td>
        </tr>

        <tr>
            <td>Family Name:</td>
            <td><asp:TextBox ID="txtFamily" runat="server" /></td>
        </tr>

        <tr>
            <td></td>
            <td>
                <asp:CustomValidator ID="cvName" runat="server"
                    ErrorMessage="Name and Family Name should be different"
                    OnServerValidate="CheckNames"
                    ForeColor="Red" />
            </td>
        </tr>

        <tr>
            <td>Address:</td>
            <td>
                <asp:TextBox ID="txtAddress" runat="server" />
                <asp:RequiredFieldValidator ID="rfvAddress" runat="server"
                    ControlToValidate="txtAddress"
                    ErrorMessage="Required" ForeColor="Red" />
                <asp:RegularExpressionValidator ID="revAddress" runat="server"
                    ControlToValidate="txtAddress"
                    ValidationExpression=".{2,}"
                    ErrorMessage="Min 2 characters" ForeColor="Red" />
            </td>
        </tr>

        <tr>
            <td>City:</td>
            <td>
                <asp:TextBox ID="txtCity" runat="server" />
                <asp:RegularExpressionValidator ID="revCity" runat="server"
                    ControlToValidate="txtCity"
                    ValidationExpression=".{2,}"
                    ErrorMessage="Min 2 characters" ForeColor="Red" />
            </td>
        </tr>

        <tr>
            <td>Zip Code:</td>
            <td>
                <asp:TextBox ID="txtZip" runat="server" />
                <asp:RegularExpressionValidator ID="revZip" runat="server"
                    ControlToValidate="txtZip"
                    ValidationExpression="^\d{5}$"
                    ErrorMessage="Must be 5 digits" ForeColor="Red" />
            </td>
        </tr>

        <tr>
            <td>Phone:</td>
            <td>
                <asp:TextBox ID="txtPhone" runat="server" />
                <asp:RegularExpressionValidator ID="revPhone" runat="server"
                    ControlToValidate="txtPhone"
                    ValidationExpression="^\d{2,3}-\d{7}$"
                    ErrorMessage="Format: XX-XXXXXXX or XXX-XXXXXXX"
                    ForeColor="Red" />
            </td>
        </tr>

        <tr>
            <td>Email:</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" />
                <asp:RegularExpressionValidator ID="revEmail" runat="server"
                    ControlToValidate="txtEmail"
                    ValidationExpression="^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$"
                    ErrorMessage="Invalid Email" ForeColor="Red" />
            </td>
        </tr>

        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnCheck" runat="server" Text="Check" OnClick="btnCheck_Click" />
            </td>
        </tr>

        <tr>
            <td></td>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1"
                    runat="server"
                    HeaderText="Please Fix"
                    ForeColor="Red"
                    ShowMessageBox="true"
                    ShowSummary="true"
                    DisplayMode="BulletList" />
            </td>
        </tr>
    </table>
</form>

</body>
</html>

