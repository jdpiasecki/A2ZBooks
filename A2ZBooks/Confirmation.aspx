<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Confirmation.aspx.cs" Inherits="A2ZBooks.Confirmation" %>

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
        
        <h1><asp:Label ID="confirmationLabel" runat="server" Text ="Confirm Checkout"></asp:Label></h1>
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
        <asp:Button ID="cancelButton" runat="server" Text="Cancel" OnClick="cancelButton_Click" />
        <asp:Button ID="confirmButton" runat="server" Text="Confirm" OnClick="confirmButton_Click" />
     
        <p style ="text-align: center">
            <asp:Label ID="Label9" runat="server" Text="confirmationLabel" Visible="False"></asp:Label>
        </p>
    </form>
</body>
</html>
