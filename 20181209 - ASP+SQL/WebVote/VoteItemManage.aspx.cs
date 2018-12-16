using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Default2 : System.Web.UI.Page
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
        //建立数据库连接对象
        SqlConnection conn = new SqlConnection("Server=.;database=WebVote;uid=sa;pwd=;");
        //打开连接
        conn.Open();
        //建立从数据库中获取数据的命令
        SqlCommand cmd = new SqlCommand("select voteID,Item from votes ", conn);
        //执行数据库命令，并将获取的数据（二维表）作为列表的数据源
        this.lbItemList.DataSource = cmd.ExecuteReader();
        //设置列表项显示的数据为数据源中的哪个字段
        this.lbItemList.DataValueField = "voteID";
        //设置列表项代表的数据为数据源中的哪个字段
        this.lbItemList.DataTextField = "item";
        //将数据源中的数据绑定到列表中
        this.lbItemList.DataBind();
        //关闭数据库连接
        conn.Close();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection("Server=.;database=WebVote;uid=sa;pwd=;");
        conn.Open();
        SqlCommand cmd = new SqlCommand("insert into votes (item) values(@item) ", conn);
        SqlParameter par1 = new SqlParameter("@item", SqlDbType.VarChar, 200);
        par1.Value = this.tbItem.Text;
        cmd.Parameters.Add(par1);
        // 上面三行可简化成下面的一行。
        //cmd.Parameters.Add("@item", SqlDbType.VarChar, 200).Value = this.tbItem.Text;
        cmd.ExecuteNonQuery();
        conn.Close();
        //添加后重新绑定列表
        bindItemList();
    }

    protected void ibDelete_Click(object sender, ImageClickEventArgs e)
    {
        if (this.lbItemList.SelectedIndex >= 0)
        {
            SqlConnection conn = new SqlConnection("Server=.;database=WebVote;uid=sa;pwd=;");
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from  votes where voteID=@voteID ", conn);
            SqlParameter par1 = new SqlParameter("@voteID", SqlDbType.Int);
            //将所选中的
            par1.Value = Convert.ToInt32(this.lbItemList.SelectedValue);
            cmd.Parameters.Add(par1);
            // 上面三行可简化成下面的一行。
            //cmd.Parameters.Add("@item", SqlDbType.VarChar, 200).Value = Convert.ToInt32(this.lbItemList.SelectedValue);
            cmd.ExecuteNonQuery();
            conn.Close();
            //添加后重新绑定列表
            bindItemList();
        }
        else
        {
            //显示操作结果信息
            Response.Write("<script>window.alert('请选择操作的数据项！！！ ')</script>");
        }
    }
}