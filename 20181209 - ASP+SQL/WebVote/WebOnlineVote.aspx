<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WebOnlineVote.aspx.cs" Inherits="WebOnlineVote" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <table style="width: 300px">
                <tr>
                    <td >
                        <asp:GridView ID="gvVoteList" runat="server" AutoGenerateColumns="False" BackColor="White"
                            BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="384px">
                            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                            <RowStyle BackColor="White" ForeColor="#330099" />
                            <Columns>
                                <asp:BoundField DataField="item" HeaderText="投票项目" />
                                <asp:TemplateField HeaderText="选择">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbVote" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr><td >
                  <asp:Button ID="btnSubmitVote" runat="server" Text="提交投票" OnClick="btnSubmitVote_Click" />
                  <asp:Button ID="btnShowVote" runat="server" Text="查看结果" OnClick="btnShowVote_Click" /></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="lblVoteMessage" runat="server" ForeColor="Red" Text="投票成功！" Visible="False"></asp:Label></td>
                </tr>
            
            </table>
        </div>
    </form>
</body>
</html>
