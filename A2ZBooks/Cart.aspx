<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="A2ZBooks.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 148px;
            height: 40px;
        }
        .auto-style3 {
            width: 132px;
            height: 40px;
        }
        .auto-style4 {
            width: 190px;
            height: 40px;
        }
        .auto-style6 {
            height: 40px;
        }
        .auto-style7 {
            float: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        
        <h1><asp:Label ID="cartResultsLabel" runat="server" Text ="Shopping Cart"></asp:Label></h1>
        <br />
        <br />
        <table id="results" runat="server" class="auto-style1">
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label1" runat="server" Text="Author"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:Label ID="Label7" runat="server" Text="Title"></asp:Label>
                </td>
                
                <td class="auto-style6">
                    <asp:Label ID="Label5" runat="server" Text="Price"></asp:Label>
                </td>
                <td class="auto-style6">
                    <asp:Label ID="Label6" runat="server" Text="Quantity"></asp:Label>
                </td>
                <td class="auto-style6">
                    <asp:Label ID="Label8" runat="server" Text="Sub-Total"></asp:Label>
                </td>
                
            </tr>
        </table>
        
        <p class="auto-style7">
            <asp:Label ID="itemsInCart" runat="server" ></asp:Label>
        </p>
        <asp:Button ID="btnCheckout" runat="server" Text="Checkout" OnClick="btnCheckout_Click" />
        <asp:Button ID="btnShopping" runat="server" Text="Continue Shopping" OnClick="btnShopping_Click" />
    </form>
</body>
</html>
