<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <h1>学生基本信息采集</h1>
    <form id="form1" runat="server">
        <div>
            <label>学号</label>
            <input id="Text1" type="text" />
            <br />
            <label>姓名</label>
            <input id="Text2" type="text" />
            <br />
            <label><input name="Sex" type="radio" value="男" />男</label> 
            <br />
            <label><input name="Sex" type="radio" value="女" />女</label>
            <br />
            <label>年龄</label>
            <input id="Text3" type="text" />
            <br />
            <label>政治面貌</label>
            <select id="Select">
                <option>团员</option>
                <option>党员</option>
                <option>群众</option>
            </select>
            <br />
            <p>经常阅读的图书</p>
            <label><input name="Checkbox" type="checkbox" value="政治"/>政治</label>
            <label><input name="Checkbox" type="checkbox" value="经济"/>经济</label>
            <label><input name="Checkbox" type="checkbox" value="文学"/>文学</label>
            <label><input name="Checkbox" type="checkbox" value="其他"/>其他</label>
            <br />
            <input id="Button" type="button" value="提交" onclick ="summary()"/>
            <input id="Reset" type="reset" value="清除" />
            <br />
            <label>基本信息汇总</label>
            <textarea id="TextArea1" cols="50" rows="10"></textarea>
        <script type="text/javascript">    
            function summary() {
                document.getElementById('TextArea1').value = "学号：" + document.getElementById('Text1').value + "\n"
                document.getElementById('TextArea1').value += "姓名：" + document.getElementById('Text2').value + "\n"
                var value1 = ''
                var Sex = document.getElementsByName("Sex")
                for (var i = 0; i < Sex.length; i++) {
                    if (Sex[i].checked == true) {
                        value1 = Sex[i].value
                        break
                    }
                }

                document.getElementById('TextArea1').value += "性别：" + value1 + "\n"
                document.getElementById('TextArea1').value += "年龄：" + document.getElementById('Text3').value + "\n"
                document.getElementById('TextArea1').value += "政治面貌：" + Select.value + "\n"

                var value2=""
                var Box = document.getElementsByName("Checkbox")
                for (var j = 0; j < Box.length; j++)
		        {
                    if (Box[j].checked == true)
                    {
                        value2 += Box[j].value + " "
                    }
                }
                document.getElementById('TextArea1').value += "经常阅读的图书：" + value2 + "\n"

            } 
        </script>
        </div>
    </form>
</body>
</html>
