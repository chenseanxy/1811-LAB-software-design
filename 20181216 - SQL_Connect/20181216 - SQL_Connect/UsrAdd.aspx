<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UsrAdd.aspx.cs" Inherits="UsrAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 210px;
            height: 45px;
            text-align: right;
        }
        .auto-style2 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style1">姓名: </td>
                    <td>
                        <asp:TextBox ID="UsrAddNameBox" runat="server" MaxLength="16"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">性别: </td>
                    <td>
                        <asp:CheckBox ID="UsrAddGendChk" runat="server" Text="男？"/>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">地址: </td>
                    <td>
                        <asp:TextBox ID="UsrAddAddrBox" runat="server" MaxLength="512"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">电话: </td>
                    <td>
                        <asp:TextBox ID="UsrAddPhoneBox" runat="server" MaxLength="32"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">科室: </td>
                    <td>
                        <asp:TextBox ID="UsrAddUnitBox" runat="server" MaxLength="16"></asp:TextBox>
                    </td>
                </tr>

            </table>
        </div>
        <div class="auto-style2">
            <asp:Button ID="UsrAddSubmit" runat="server" Text="提交" OnClick="UsrAddSubmit_Click" />
        </div>
    </form>
</body>
</html>
