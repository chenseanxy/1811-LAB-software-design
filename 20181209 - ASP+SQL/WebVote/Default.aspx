<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <table style="width: 400px; background-color: #ffffcc;">
                <tr>
                    <td style="font-weight: bold; font-size: x-large; color: khaki; height: 32px;
                        background-color: cadetblue">
                        在线投票系统</td>
                </tr>
                <tr>
                    <td style="height: 45px"><asp:HyperLink ID="ItemManageLink" NavigateUrl="~/VoteItemManage.aspx" runat="server" Font-Bold="True">投票项目管理</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td style="height: 45px"><asp:HyperLink ID="OnlineVoteLink" NavigateUrl="~/WebOnlineVote.aspx" runat="server" Font-Bold="True">网站在线投票</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td style="height: 45px" ><asp:HyperLink ID="ViewVoteLink" NavigateUrl="~/ShowVoteInfo.aspx" runat="server" Font-Bold="True">查看投票结果</asp:HyperLink>
                    </td>
                </tr>
            </table>
        </div>

    </form>
</body>
</html>
