using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class WebOnlineVote : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            bindItemList();
        }
    }
    void bindItemList()
    {
        SqlConnection conn = new SqlConnection("Server=.;database=WebVote;uid=sa;pwd=;");
        //打开连接
        conn.Open();
        //建立从数据库中获取数据的命令
        SqlCommand cmd = new SqlCommand("select voteID,item  from votes ", conn);
        //执行数据库命令，并将获取的数据（二维表）作为列表的数据源
        this.gvVoteList.DataSource = cmd.ExecuteReader();
        //设置列表项显示的数据为数据源中的哪个字段
        this.gvVoteList.DataKeyNames = new string[] { "voteID" };
        this.gvVoteList.DataBind();
        //关闭数据库连接
        conn.Close();
    }

    protected void btnSubmitVote_Click(object sender, EventArgs e)
    {
        try
        {
            string voteIDList = "";
            foreach (GridViewRow row in this.gvVoteList.Rows)
            { //查找每个投票项目的选择控件
                CheckBox check = (CheckBox)row.FindControl("cbVote");
                if (check != null)
                { //说明用户已经投票，则需要添加这一票
                    if (check.Checked == true)
                    { //修改数据库中的票数
                        string voteID = this.gvVoteList.DataKeys[row.DataItemIndex].Value.ToString();
                        voteIDList = voteIDList.Equals("") ? voteID : voteIDList + "," + voteID;
                    }
                }
            }
            SqlConnection conn = new SqlConnection("Server=.;database=WebVote;uid=sa;pwd=;");
            conn.Open();
            SqlCommand cmd = new SqlCommand("update votes set votecount=votecount + 1 where voteID in(" + voteIDList + ")", conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            //显示操作结果信息
            this.lblVoteMessage.Visible = true;
            Response.Write("<script>window.alert('投票成功，感谢您的参与！！！')</script>");
        }
        catch
        { //显示修改操作中的失败、错误信息 
            Response.Write("<script>window.alert('投票失败！'),</script>");
            this.lblVoteMessage.Text = "投票失败!!!";
        }
    }

    protected void btnShowVote_Click(object sender, EventArgs e)
    {
        Response.Redirect("ShowVoteInfo.aspx");
    }
}