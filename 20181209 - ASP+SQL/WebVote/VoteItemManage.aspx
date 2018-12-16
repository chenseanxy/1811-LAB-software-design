<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VoteItemManage.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
         <table style="width: 300px; background-color: #99ccff">
            <tr><td style="width: 107px; height: 97px">
                    <asp:ListBox ID="lbItemList" runat="server" Width="277px"></asp:ListBox></td>
                 <td style="height: 97px">
                    <asp:ImageButton ID="ibDelete" runat="server" ImageUrl="~/images/DEL.gif" OnClick="ibDelete_Click" /></td>
            </tr>
            <tr><td colspan="2">
                  <asp:TextBox ID="tbItem" runat="server" Width="169px"></asp:TextBox>
                  <asp:Button ID="btnAdd" runat="server" Text="增加新的投票项目" Width="112px" OnClick="btnAdd_Click" /></td>
            </tr>
             <tr>
                    <td style="width: 597px">
                        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx">返回到投票页面</asp:LinkButton></td>
                </tr>
             <tr>
                    <td style="width: 597px">
                        <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/Default.aspx">返回到投票页面</asp:LinkButton></td>
                </tr>
          </table>
        </div>
    </form>
</body>
</html>
