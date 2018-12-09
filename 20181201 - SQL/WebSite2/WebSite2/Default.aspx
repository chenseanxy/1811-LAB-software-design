<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h>请输入用户名</h>
            <input id="Text1" type="text" />
            <input id="Button1" type="button" value="确定" onclick ="checkform()"/>
        </div>
    <script type="text/javascript">    
        function checkform(){ 
            if (document.getElementById('Text1').value.length == 0)
            {    
                alert('请先输入用户名！');
                document.getElementById('Text1').focus();
                return false;
            }
            else
            {    
                alert('欢迎使用本系统！');
                document.getElementById('Text1').focus();
                return false;
            }
        }
    </script>
    </form>
</body>
</html>
