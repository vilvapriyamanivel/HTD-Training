<%@ Page Title="" Language="C#"
MasterPageFile="~/Site.Master"
AutoEventWireup="true"
CodeBehind="AddEditMenu.aspx.cs"
Inherits="Assessment9.AddEditMenu" %>

<asp:Content ID="Content1"
ContentPlaceHolderID="MainContent"
runat="server">

    <h2>Add Food Item</h2>

    <table class="table">

        <tr>
            <td>Item Name</td>
            <td>

                <asp:TextBox ID="txtItemName"
                    runat="server"
                    CssClass="form-control">
                </asp:TextBox>

                <asp:RequiredFieldValidator
                    ID="rfvItem"
                    runat="server"
                    ControlToValidate="txtItemName"
                    ErrorMessage="Item Name Required"
                    ForeColor="Red">
                </asp:RequiredFieldValidator>

            </td>
        </tr>

        <tr>
            <td>Category</td>
            <td>

                <asp:TextBox ID="txtCategory"
                    runat="server"
                    CssClass="form-control">
                </asp:TextBox>

            </td>
        </tr>

        <tr>
            <td>Food Type</td>
            <td>

                <asp:DropDownList ID="ddlFoodType"
                    runat="server"
                    CssClass="form-control">

                    <asp:ListItem>Veg</asp:ListItem>
                    <asp:ListItem>Non-Veg</asp:ListItem>

                </asp:DropDownList>

            </td>
        </tr>

        <tr>
            <td>Price</td>
            <td>

                <asp:TextBox ID="txtPrice"
                    runat="server"
                    CssClass="form-control">
                </asp:TextBox>

                <asp:RangeValidator
                    ID="rvPrice"
                    runat="server"
                    ControlToValidate="txtPrice"
                    MinimumValue="1"
                    MaximumValue="10000"
                    Type="Double"
                    ErrorMessage="Enter Valid Price"
                    ForeColor="Red">
                </asp:RangeValidator>

            </td>
        </tr>

        <tr>
            <td>Quantity</td>
            <td>

                <asp:TextBox ID="txtQty"
                    runat="server"
                    CssClass="form-control">
                </asp:TextBox>

            </td>
        </tr>

        <tr>
            <td>Available</td>
            <td>

                <asp:CheckBox ID="chkAvailable"
                    runat="server" />

            </td>
        </tr>

        <tr>
            <td></td>
            <td>

                <asp:Button ID="btnSave"
                    runat="server"
                    Text="Save"
                    CssClass="btn btn-primary"
                    OnClick="btnSave_Click" />

            </td>
        </tr>

    </table>

    <asp:ValidationSummary
        ID="ValidationSummary1"
        runat="server"
        ForeColor="Red" />

</asp:Content>