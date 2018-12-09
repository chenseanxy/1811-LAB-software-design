<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>登录信息管理系统</h1>
        <div>
            <label>用户名：</label>
            <input id="Text1" type="text" />
            <input id="Button1" type="button" value="确定" onclick ="checkform()"/>
        </div>
        <div>
            <label>密码：</label>
            <input id="Text2" type="password" />
            <input id="Button2" type="button" value="确定" onclick ="checkform()"/>
        </div>
        <script type="text/javascript">    
        function checkform(){ 
            if (document.getElementById('Text1').value.length == 0) {
                alert('请先输入用户名！');
                document.getElementById('Text1').focus();
                return false;
            }
            else if (document.getElementById('Text2').value.length == 0) {
                alert('请先输入密码！');
                document.getElementById('Text2').focus();
                return false;
            }

            else
            {
                alert('欢迎使用本系统！');
                return false;
            }
        }
        </script>
        <script type="password/javascript">    
        </script>
    </form>
</body>
</html>
