<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowVoteInfo.aspx.cs" Inherits="ShowVoteInfo" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <table style="width: 400px">
                <tr>
                    <td style="width: 597px" >
                        <asp:GridView ID="gvVoteList" runat="server" AutoGenerateColumns="False" Width="594px" OnRowDataBound="gvVoteList_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="item" HeaderText="投票项目" />
                                <asp:TemplateField HeaderText="票数所占百分比">
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" runat="server"   ImageUrl="~/images/percentage.gif" />
                                        <asp:Label ID="lblVotePercentage" runat="server" Text='<%# Eval("percentage") +"%" %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="voteCount" HeaderText="票数" />
                     
                            </Columns>
                            <HeaderStyle BackColor="Teal" ForeColor="White" />
                        </asp:GridView>
                        &nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="width: 597px">
                        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx">返回到投票页面</asp:LinkButton></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>